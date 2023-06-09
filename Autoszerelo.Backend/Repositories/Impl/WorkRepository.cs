// <copyright file="WorkRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo_backend.Repositories.Impl
{
    using Autoszerelo_backend.Data;
    using autoszerelo_backend.Entities;
    using autoszerelo_backend.Requests;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository for work with <see cref="Work"/> entities.
    /// </summary>
    public class WorkRepository : IWorkRepository
    {
        private readonly AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkRepository"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public WorkRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Function to create a <see cref="Work"/> entity.
        /// </summary>
        /// <param name="request">Request of the creation.</param>
        /// <returns>A new <see cref="Work"/> entity.</returns>
        public async Task<Work?> CreateWork(CreateWorkRequest request)
        {
            var client = await this.context.Clients.FindAsync(request.ClientId);
            if (client == null)
            {
                return null;
            }

            var car = await this.context.Cars.FindAsync(request.CarId);
            if (car == null)
            {
                return null;
            }

            var work = new Work()
            {
                Id = default(Guid),
                Client = client,
                Car = car,
                Status = Status.REGISTERED,
            };

            try
            {
                work.WorkHours = await this.CalculateWorkHours(car.Id);
            }
            catch (Exception)
            {
                return null;
            }

            await this.context.Works.AddAsync(work);
            await this.context.SaveChangesAsync();

            return work;
        }

        /// <summary>
        /// Function to delete a <see cref="Work"/> entity.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>The result of the deletion.</returns>
        public async Task<bool> DeleteWork(Guid id)
        {
            var work = await this.context.Works.FindAsync(id);

            if (work == null)
            {
                return false;
            }

            this.context.Works.Remove(work);
            await this.context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Function to get all <see cref="Work"/> entities.
        /// </summary>
        /// <returns>A collection of <see cref="Work"/> entities.</returns>
        public async Task<IEnumerable<Work>> GetAllWorks()
        {
            return await this.context.Works.Include(w => w.Car).Include(w => w.Client).ToListAsync();
        }

        /// <summary>
        /// Function to get a <see cref="Work"/> entity by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>A <see cref="Work"/> entity.</returns>
        public async Task<Work?> GetWorkById(Guid id)
        {
            return await this.context.Works.Include(w => w.Car).Include(w => w.Client)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        /// <summary>
        /// Function to search for <see cref="Work"/> entities.
        /// </summary>
        /// <param name="param">Search parameter.</param>
        /// <returns>A collection of <see cref="Work"/> entities.</returns>
        public async Task<IEnumerable<Work>?> SearchWorks(string param)
        {
            var works = await this.GetAllWorks();

            if (param == null)
            {
                return null;
            }
            else
            {
                works = works.Where(w => w.Client.Name.ToLower().Contains(param.ToLower()) ||
                    w.Car.Type.ToLower().Contains(param.ToLower()) ||
                    w.Car.Licence.ToLower().Contains(param.ToLower()));
                return works;
            }
        }

        /// <summary>
        /// Function to update a <see cref="Work"/> entity.
        /// </summary>
        /// <param name="request">Request for update.</param>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>An updated <see cref="Work"/> entity.</returns>
        public async Task<Work?> UpdateWork(UpdateWorkRequest request, Guid id)
        {
            var client = await this.context.Clients.Include(c => c.Cars).FirstOrDefaultAsync(c => c.Id == request.ClientId);
            if (client == null)
            {
                return null;
            }

            var car = await this.context.Cars.FindAsync(request.CarId);
            if (car == null)
            {
                return null;
            }

            var work = await this.context.Works.Include(w => w.Client).Include(w => w.Client)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (work == null)
            {
                return null;
            }

            work.Client = client;
            work.Car = car;

            try
            {
                work.WorkHours = await this.CalculateWorkHours(car.Id);
            }
            catch (Exception)
            {
                return null;
            }

            this.context.Works.Update(work);
            await this.context.SaveChangesAsync();

            return work;
        }

        /// <summary>
        /// Functio to update the <see cref="Status"/> of the <see cref="Work"/> entity.
        /// </summary>
        /// <param name="request">Request for the update.</param>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>An updated <see cref="Work"/> entity.</returns>
        public async Task<Work?> UpdateWorkStatus(UpdateWorkStatusRequest request, Guid id)
        {
            var work = await this.context.Works.FindAsync(id);

            if (work == null)
            {
                return null;
            }

            work.Status = request.Status;

            if (request.Status == Status.REPAIRED)
            {
                work.WorkHours = 0;
            }

            this.context.Works.Update(work);
            await this.context.SaveChangesAsync();

            return work;
        }

        /// <summary>
        /// Function to calculate work hours.
        /// </summary>
        /// <param name="id">Id of the <see cref="Word"/> entity.</param>
        /// <returns>A float value.</returns>
        public async Task<float> CalculateWorkHours(Guid id)
        {
            float result = 0;

            var car = await this.context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return -1f;
            }

            int age = DateTime.Now.Year - car.BuiltYear;

            switch (car.WorkCategory)
            {
                case WorkCategory.BODY:
                    result += 3f;
                    break;
                case WorkCategory.ENGINE:
                    result += 8f;
                    break;
                case WorkCategory.LANDING_GEAR:
                    result += 6f;
                    break;
                case WorkCategory.BRAKE:
                    result += 4f;
                    break;
                default:
                    throw new Exception("Illegal work category agrument!");
            }

            if (age > 0 && age <= 5)
            {
                result *= 0.5f;
            }
            else if (age > 5 && age <= 10)
            {
                result *= 1f;
            }
            else if (age > 10 && age <= 20)
            {
                result *= 1.5f;
            }
            else if (age > 20)
            {
                result *= 2f;
            }

            if (car.FaultWeight >= 1 && car.FaultWeight <= 2)
            {
                result *= 0.2f;
            }
            else if (car.FaultWeight >= 2 && car.FaultWeight <= 4)
            {
                result *= 0.4f;
            }
            else if (car.FaultWeight >= 5 && car.FaultWeight <= 7)
            {
                result *= 0.6f;
            }
            else if (car.FaultWeight >= 8 && car.FaultWeight <= 9)
            {
                result *= 0.8f;
            }
            else
            {
                result *= 1f;
            }

            await Task.Delay(1000);
            return result;
        }
    }
}
