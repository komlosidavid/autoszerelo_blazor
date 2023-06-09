// <copyright file="CarService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace autoszerelo_frontend_office.Services
{
    using System.Net.Http.Json;
    using autoszerelo_backend.Entities;
    using autoszerelo_backend.Requests;

    /// <summary>
    /// Service for working with API calss.
    /// </summary>
    public class CarService
    {
        private readonly HttpClient http;
        private readonly string url = "https://localhost:7238/api/";

        /// <summary>
        /// Initializes a new instance of the <see cref="CarService"/> class.
        /// </summary>
        /// <param name="http">Http client</param>
        public CarService(HttpClient http)
        {
            this.http = http;
        }

        /// <summary>
        /// Function to get <see cref="Car"/> entities by <see cref="Client"/> id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Client"/> entity.</param>
        /// <returns>A collection of <see cref="Car"/> entities.</returns>
        public async Task<IEnumerable<Car>?> GetCarsByClientId(Guid id)
        {
            return await this.http.GetFromJsonAsync<IEnumerable<Car>>(this.url + "Client/getcarsbyclientid/" + id);
        }

        /// <summary>
        /// Function to create a <see cref="Car"/> entity.
        /// </summary>
        /// <param name="request">Request for the creation.</param>
        /// <returns>An http response message.</returns>
        public async Task<HttpResponseMessage> CreateCar(CreateCarRequest request)
        {
            return await this.http.PostAsJsonAsync(this.url + "Car", request);
        }
    }
}
