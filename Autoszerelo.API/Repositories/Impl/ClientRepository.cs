// <copyright file="ClientRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo.API.Repositories.Impl
{
    using System;
    using Autoszerelo.API.Data;
    using Autoszerelo.API.Repoitories;
    using Autoszerelo.Models.Entities;
    using Autoszerelo.Models.Requests;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository for working with <see cref="Client"/> entities.
    /// </summary>
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRepository"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public ClientRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Function to add a <see cref="Car"/> entity to a <see cref="Client"/> entity.
        /// </summary>
        /// <param name="car"><see cref="Car"/> entity.</param>
        /// <param name="clientId">Id of the <see cref="Client"/> entity.</param>
        /// <returns>A <see cref="Client"/> entity.</returns>
        public async Task<Client?> AddCarToClient(Car car, Guid clientId)
        {
            var client = await this.context.Clients.FindAsync(clientId);

            if (client == null)
            {
                return null;
            }

            client.Cars.Add(car);

            await this.context.SaveChangesAsync();

            return client;
        }

        /// <summary>
        /// Function to create a <see cref="Client"/> entity.
        /// </summary>
        /// <param name="request">Request for creation.</param>
        /// <returns>A new <see cref="Client"/> entity.</returns>
        public async Task<Client> CreateClient(CreateClientRequest request)
        {
            var client = new Client()
            {
                Id = default,
                Name = request.Name,
            };

            await this.context.Clients.AddAsync(client);
            await this.context.SaveChangesAsync();

            return client;
        }

        /// <summary>
        /// Function to get all <see cref="Client"/> entities.
        /// </summary>
        /// <returns>A collection of <see cref="Client"/> entities.</returns>
        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await this.context.Clients.Include(c => c.Cars).ToListAsync();
        }

        /// <summary>
        /// Function to get <see cref="Car"/> entities by a <see cref="Client"/> id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Client"/> entity.</param>
        /// <returns>A collection of <see cref="Car"/> entities.</returns>
        public async Task<IEnumerable<Car>?> GetCarsByClientId(Guid id)
        {
            var client = await this.context.Clients.Include(c => c.Cars).FirstOrDefaultAsync(c => c.Id == id);
            if (client != null)
            {
                return client.Cars.ToList();
            }

            return null;
        }

        /// <summary>
        /// Function to get a <see cref="Client"/> entity by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Client"/> entity.</param>
        /// <returns>A <see cref="Client"/> entity.</returns>
        public async Task<Client?> GetClient(Guid id)
        {
            return await this.context.Clients.Include(c => c.Cars).FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Function to get <see cref="Client"/> entities by name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Client"/> entity.</param>
        /// <returns>A collection of <see cref="Client"/> entities.</returns>
        public async Task<IEnumerable<Client>?> GetClientsByName(string name)
        {
            var clients = await this.GetAllClients();

            if (name == null)
            {
                return null;
            }

            clients = clients.Where(c => c.Name.ToLower().Contains(name.ToLower()));

            return clients;
        }
    }
}
