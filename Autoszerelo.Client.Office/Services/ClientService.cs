// <copyright file="ClientService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo.Client.Office.Services
{
    using System.Net.Http.Json;
    using Autoszerelo.Models.Entities;
    using Autoszerelo.Models.Requests;

    /// <summary>
    /// Service for handleing API calls.
    /// </summary>
    public class ClientService
    {
        private readonly HttpClient http;
        private readonly string url = "https://localhost:7176/api/";

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        /// <param name="http">Http client.</param>
        public ClientService(HttpClient http)
        {
            this.http = http;
        }

        /// <summary>
        /// Function to get a collection of <see cref="Client"/>s by id.
        /// </summary>
        /// <param name="name">Name of the <see cref="Client"/>.</param>
        /// <returns>A collection of <see cref="Client"/>.</returns>
        public async Task<IEnumerable<Client>?> GetClientsByName(string name)
        {
            return await this.http.GetFromJsonAsync<IEnumerable<Client>>(this.url + "Client/" + name);
        }

        /// <summary>
        /// Function to get a <see cref="Client"/> by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Client"/>.</param>
        /// <returns>A <see cref="Client"/> entity.</returns>
        public async Task<Client?> GetClientById(Guid id)
        {
            return await this.http.GetFromJsonAsync<Client>(this.url + "Client/" + id);
        }

        /// <summary>
        /// Function to create a <see cref="Client"/>.
        /// </summary>
        /// <param name="request">Request for creation.</param>
        /// <returns>A http response message.</returns>
        public async Task<HttpResponseMessage> CreateClient(CreateClientRequest request)
        {
            return await this.http.PostAsJsonAsync(this.url + "Client/", request);
        }
    }
}
