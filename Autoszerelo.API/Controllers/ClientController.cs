// <copyright file="ClientController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo.API.Controllers
{
    using Autoszerelo.API.Repoitories;
    using Autoszerelo.Models.Entities;
    using Autoszerelo.Models.Requests;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class for handleing api calls for clients.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientController"/> class.
        /// </summary>
        /// <param name="repository">Reference to repository.</param>
        public ClientController(IClientRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Function to get all the <see cref="Client"/> entities from the database.
        /// </summary>
        /// <returns>A collection of <see cref="Client"/> entities.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            try
            {
                return this.Ok(await this.repository.GetAllClients());
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to get a <see cref="Client"/> by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Client"/>.</param>
        /// <returns>A <see cref="Client"/> entity.</returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Client>> GetClient([FromRoute] Guid id)
        {
            try
            {
                var client = await this.repository.GetClient(id);
                if (client != null)
                {
                    return this.Ok(client);
                }

                return this.NotFound();
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to get <see cref="Client"/> entities by name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Client"/>.</param>
        /// <returns>A collection of <see cref="Client"/> entities.</returns>
        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientsByName([FromRoute] string name)
        {
            try
            {
                return this.Ok(await this.repository.GetClientsByName(name));
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to get <see cref="Car"/> entites by a client.
        /// </summary>
        /// <param name="id">Id of the <see cref="Client"/>.</param>
        /// <returns>A collection of <see cref="Car"/> entities.</returns>
        [HttpGet]
        [Route("getcarsbyclientid/{id:guid}")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarsByClientId([FromRoute] Guid id)
        {
            try
            {
                return this.Ok(await this.repository.GetCarsByClientId(id));
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to create a <see cref="Client"/>.
        /// </summary>
        /// <param name="request">Request for createing the <see cref="Client"/>.</param>
        /// <returns>A new <see cref="Client"/> entity.</returns>
        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(CreateClientRequest request)
        {
            try
            {
                return this.Ok(await this.repository.CreateClient(request));
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }
    }
}
