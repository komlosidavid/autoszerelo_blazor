// <copyright file="WorkService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo.Client.Mechanic.Services
{
    using System.Net.Http.Json;
    using Autoszerelo.Models.Entities;
    using Autoszerelo.Models.Requests;

    /// <summary>
    /// Service for working with <see cref="Work"/> entities.
    /// </summary>
    public class WorkService
    {
        private readonly HttpClient http;
        private readonly string url = "https://localhost:7176/api/";

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkService"/> class.
        /// </summary>
        /// <param name="http">Http client.</param>
        public WorkService(HttpClient http)
        {
            this.http = http;
        }

        /// <summary>
        /// Function to get all <see cref="Work"/> entities.
        /// </summary>
        /// <returns>A collection of <see cref="Work"/> entities.</returns>
        public async Task<IEnumerable<Work>?> GetAllWorks()
        {
            return await this.http.GetFromJsonAsync<IEnumerable<Work>>(this.url + "work");
        }

        /// <summary>
        /// Function to search for <see cref="Work"/> entities.
        /// </summary>
        /// <param name="param">Searching parameter.</param>
        /// <returns>A collections of <see cref="Work"/> entities.</returns>
        public async Task<IEnumerable<Work>?> SearchForWorks(string param)
        {
            return await this.http.GetFromJsonAsync<IEnumerable<Work>>(this.url + "work/" + param);
        }

        /// <summary>
        /// Function to update a <see cref="Work"/> status.
        /// </summary>
        /// <param name="request">Request for the update.</param>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>An updated <see cref="Work"/> entity.</returns>
        public async Task<HttpResponseMessage> UpdateStatus(UpdateWorkStatusRequest request, Guid id)
        {
            return await this.http.PutAsJsonAsync(this.url + "Work/updatestatus/" + id, request);
        }
    }
}
