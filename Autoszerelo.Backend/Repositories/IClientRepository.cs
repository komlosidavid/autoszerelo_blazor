// <copyright file="IClientRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo_backend.Repositories
{
    using autoszerelo_backend.Entities;
    using autoszerelo_backend.Requests;

    /// <summary>
    /// Interface for client repository.
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Function to get all <see cref="Client"/> entities.
        /// </summary>
        /// <returns>A collection of <see cref="Client"/> entities.</returns>
        Task<IEnumerable<Client>> GetAllClients();

        /// <summary>
        /// Function to get a <see cref="Client"/> entity by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Client"/> entity.</param>
        /// <returns>A <see cref="Client"/> entity.</returns>
        Task<Client?> GetClient(Guid id);

        /// <summary>
        /// Function to get <see cref="Client"/> entities by name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Client"/> entity.</param>
        /// <returns>A collection of <see cref="Client"/> entities.</returns>
        Task<IEnumerable<Client>?> GetClientsByName(string name);

        /// <summary>
        /// Function to get <see cref="Car"/> entities by a <see cref="Client"/> id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Client"/> entity.</param>
        /// <returns>A collection of <see cref="Car"/> entities.</returns>
        Task<IEnumerable<Car>?> GetCarsByClientId(Guid id);

        /// <summary>
        /// Function to create a <see cref="Client"/> entity.
        /// </summary>
        /// <param name="request">Request for creation.</param>
        /// <returns>A new <see cref="Client"/> entity.</returns>
        Task<Client> CreateClient(CreateClientRequest request);

        /// <summary>
        /// Function to add a <see cref="Car"/> entity to a <see cref="Client"/> entity.
        /// </summary>
        /// <param name="car"><see cref="Car"/> entity.</param>
        /// <param name="clientId">Id of the <see cref="Client"/> entity.</param>
        /// <returns>A <see cref="Client"/> entity.</returns>
        Task<Client?> AddCarToClient(Car car, Guid clientId);
    }
}
