// <copyright file="WorkService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace autoszerelo_frontend_office.Services
{
    using System.Net.Http.Json;
    using autoszerelo_backend.Entities;
    using autoszerelo_backend.Requests;

    /// <summary>
    /// Service for handleing API calls.
    /// </summary>
    public class WorkService
    {
        private readonly HttpClient http;
        private readonly string url = "https://localhost:7238/api/";

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkService"/> class.
        /// </summary>
        /// <param name="http">Http client.</param>
        public WorkService(HttpClient http)
        {
            this.http = http;
        }

        /// <summary>
        /// Function to get all <see cref="Work"/>s.
        /// </summary>
        /// <returns>A collection of <see cref="Work"/>.</returns>
        public async Task<IEnumerable<Work>?> GetAllWorks()
        {
            return await this.http.GetFromJsonAsync<IEnumerable<Work>>(this.url + "work");
        }

        /// <summary>
        /// Function to search for <see cref="Work"/>s by parameter.
        /// </summary>
        /// <param name="param">Search parameter.</param>
        /// <returns>A collection of <see cref="Work"/>.</returns>
        public async Task<IEnumerable<Work>?> SearchForWorks(string param)
        {
            return await this.http.GetFromJsonAsync<IEnumerable<Work>>(this.url + "work/" + param);
        }

        /// <summary>
        /// Function to get a <see cref="Work"/> by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/>.</param>
        /// <returns>A <see cref="Work"/>.</returns>
        public async Task<Work?> GetWorkById(string id)
        {
            return await this.http.GetFromJsonAsync<Work>(this.url + "Work/" + id);
        }

        /// <summary>
        /// Function to calculate work hours.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/>.</param>
        /// <returns>A float result.</returns>
        public async Task<float> CalculateWorkHours(Guid id)
        {
            return await this.http.GetFromJsonAsync<float>(this.url + "Work/calculateworkhours/" + id);
        }

        /// <summary>
        /// Function to update a <see cref="Work"/>.
        /// </summary>
        /// <param name="request">Request for update.</param>
        /// <param name="id">Id of the <see cref="Work"/>.</param>
        /// <returns>An http request message.</returns>
        public async Task<HttpResponseMessage> UpdateWork(UpdateWorkRequest request, Guid id)
        {
           return await this.http.PutAsJsonAsync(this.url + "Work/" + id, request);
        }

        /// <summary>
        /// Function to create a <see cref="Work"/>.
        /// </summary>
        /// <param name="request">Request for creation.</param>
        /// <returns>An http response message.</returns>
        public async Task<HttpResponseMessage> CreateWork(CreateWorkRequest request)
        {
            return await this.http.PostAsJsonAsync(this.url + "Work/", request);
        }

        /// <summary>
        /// Function to delete a <see cref="Work"/>.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/>.</param>
        /// <returns>An http response message.</returns>
        public async Task<HttpResponseMessage> DeleteWork(Guid id)
        {
            return await this.http.DeleteAsync(this.url + "Work/" + id);
        }
    }
}
