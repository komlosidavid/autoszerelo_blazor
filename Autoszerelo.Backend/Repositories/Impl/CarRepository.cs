// <copyright file="CarRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo_backend.Repositories.Impl
{
    using Autoszerelo_backend.Data;
    using autoszerelo_backend.Entities;
    using autoszerelo_backend.Requests;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository to work with <see cref="Car"/> entities.
    /// </summary>
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext context;
        private readonly IClientRepository clientRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarRepository"/> class.
        /// </summary>
        /// <param name="context"><see cref="AppDbContext"/> context.</param>
        /// <param name="clientRepository">Repository reference.</param>
        public CarRepository(AppDbContext context, IClientRepository clientRepository)
        {
            this.context = context;
            this.clientRepository = clientRepository;
        }

        /// <summary>
        /// Function to create <see cref="Car"/> entity.
        /// </summary>
        /// <param name="request">Request for creating the <see cref="Car"/> entity.</param>
        /// <returns>A new <see cref="Car"/> entity.</returns>
        public async Task<Car?> CreateCar(CreateCarRequest request)
        {
            var owner = await this.context.Clients.FindAsync(request.OwnerId);

            if (owner == null)
            {
                return null;
            }

            var car = new Car()
            {
                Id = default(Guid),
                BuiltYear = request.BuiltYear,
                FaultWeight = request.FaultWeight,
                Licence = request.Licence,
                ProblemDescription = request.ProblemDescription,
                Type = request.Type,
                WorkCategory = request.WorkCategory,
            };

            await this.context.Cars.AddAsync(car);

            await this.clientRepository.AddCarToClient(car, owner.Id);

            await this.context.SaveChangesAsync();

            return car;
        }

        /// <summary>
        /// Function to get all cars.
        /// </summary>
        /// <returns>A collection of <see cref="Car"/> entities.</returns>
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await this.context.Cars.ToListAsync();
        }

        /// <summary>
        /// Function to get a <see cref="Car"/> entity by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Car"/> entity.</param>
        /// <returns>A <see cref="Car"/> entity.</returns>
        public async Task<Car?> GetCarById(Guid id)
        {
            return await this.context.Cars.FindAsync(id);
        }
    }
}
