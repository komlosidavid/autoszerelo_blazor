// <copyright file="IWorkRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Autoszerelo.Models.Entities;
using Autoszerelo.Models.Requests;

namespace Autoszerelo.API.Repositories
{
    /// <summary>
    /// Interface for work repository.
    /// </summary>
    public interface IWorkRepository
    {
        /// <summary>
        /// Function to get all <see cref="Work"/> entities.
        /// </summary>
        /// <returns>A collection of <see cref="Work"/> entities.</returns>
        Task<IEnumerable<Work>> GetAllWorks();

        /// <summary>
        /// Function to get a <see cref="Work"/> entity by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>A <see cref="Work"/> entity.</returns>
        Task<Work?> GetWorkById(Guid id);

        /// <summary>
        /// Function to create a <see cref="Work"/> entity.
        /// </summary>
        /// <param name="request">Request of the creation.</param>
        /// <returns>A new <see cref="Work"/> entity.</returns>
        Task<Work?> CreateWork(CreateWorkRequest request);

        /// <summary>
        /// Function to update a <see cref="Work"/> entity.
        /// </summary>
        /// <param name="request">Request for update.</param>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>An updated <see cref="Work"/> entity.</returns>
        Task<Work?> UpdateWork(UpdateWorkRequest request, Guid id);

        /// <summary>
        /// Function to delete a <see cref="Work"/> entity.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>The result of the deletion.</returns>
        Task<bool> DeleteWork(Guid id);

        /// <summary>
        /// Functio to update the <see cref="Status"/> of the <see cref="Work"/> entity.
        /// </summary>
        /// <param name="request">Request for the update.</param>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>An updated <see cref="Work"/> entity.</returns>
        Task<Work?> UpdateWorkStatus(UpdateWorkStatusRequest request, Guid id);

        /// <summary>
        /// Function to search for <see cref="Work"/> entities.
        /// </summary>
        /// <param name="param">Search parameter.</param>
        /// <returns>A collection of <see cref="Work"/> entities.</returns>
        Task<IEnumerable<Work>?> SearchWorks(string param);

        /// <summary>
        /// Function to calculate work hours.
        /// </summary>
        /// <param name="id">Id of the <see cref="Word"/> entity.</param>
        /// <returns>A float value.</returns>
        Task<float> CalculateWorkHours(Guid id);
    }
}
