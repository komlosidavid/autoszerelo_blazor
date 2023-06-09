// <copyright file="ICarRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo_backend.Repositories
{
    using autoszerelo_backend.Entities;
    using autoszerelo_backend.Requests;

    /// <summary>
    /// Interface for car repository.
    /// </summary>
    public interface ICarRepository
    {
        /// <summary>
        /// Function to get all cars.
        /// </summary>
        /// <returns>A collection of <see cref="Car"/> entities.</returns>
        Task<IEnumerable<Car>> GetAllCars();

        /// <summary>
        /// Function to get a <see cref="Car"/> entity by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Car"/> entity.</param>
        /// <returns>A <see cref="Car"/> entity.</returns>
        Task<Car?> GetCarById(Guid id);

        /// <summary>
        /// Function to create <see cref="Car"/> entity.
        /// </summary>
        /// <param name="request">Request for creating the <see cref="Car"/> entity.</param>
        /// <returns>A new <see cref="Car"/> entity.</returns>
        Task<Car?> CreateCar(CreateCarRequest request);
    }
}
