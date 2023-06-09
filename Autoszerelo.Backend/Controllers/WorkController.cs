// <copyright file="WorkController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo_backend.Controllers
{
    using autoszerelo_backend.Entities;
    using Autoszerelo_backend.Repositories;
    using autoszerelo_backend.Requests;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.OpenApi.Any;

    /// <summary>
    /// Class for handleing api calls for works.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkController"/> class.
        /// </summary>
        /// <param name="repository">Reference of repository.</param>
        public WorkController(IWorkRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Function to get all <see cref="Work"/> entities.
        /// </summary>
        /// <returns>A collection of <see cref="Work"/> entities.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> GetAllWorks()
        {
            return this.Ok(await this.repository.GetAllWorks());
        }

        /// <summary>
        /// Function to get a <see cref="Work"/> entity by id.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>A <see cref="Work"/> entity.</returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Work>> GetWorkById([FromRoute] Guid id)
        {
            try
            {
                var work = await this.repository.GetWorkById(id);

                if (work != null)
                {
                    return this.Ok(work);
                }

                return this.NotFound("Work was not found!");
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to search for <see cref="Work"/> entities.
        /// </summary>
        /// <param name="param">Searching parameter.</param>
        /// <returns>A collections of <see cref="Work"/> entities.</returns>
        [HttpGet]
        [Route("{param}")]
        public async Task<ActionResult<IEnumerable<Work>>> SearchWorks([FromRoute] string param)
        {
            try
            {
                return this.Ok(await this.repository.SearchWorks(param));
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to calculate work hours.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>A float as work hour.</returns>
        [HttpGet]
        [Route("calculateworkhours/{id:guid}")]
        public async Task<ActionResult<float>> CalculateWorkHours([FromRoute] Guid id)
        {
            try
            {
                var result = await this.repository.CalculateWorkHours(id);
                if (result != -1)
                {
                    return this.Ok(result);
                }

                return this.NotFound("Car was not found!");
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to create a <see cref="Work"/> entity.
        /// </summary>
        /// <param name="request">Request for the creation.</param>
        /// <returns>A new <see cref="Work"/> entity.</returns>
        [HttpPost]
        public async Task<ActionResult<Work>> CreateWork([FromBody] CreateWorkRequest request)
        {
            try
            {
                var work = await this.repository.CreateWork(request);

                if (work != null)
                {
                    return this.Ok(work);
                }

                return this.NotFound("Client or car were not found!");
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to update a <see cref="Work"/> entity.
        /// </summary>
        /// <param name="request">Request for update.</param>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>An updated <see cref="Work"/> entity.</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Work>> UpdateWork(
            [FromBody] UpdateWorkRequest request,
            [FromRoute] Guid id)
        {
            try
            {
                var work = await this.repository.UpdateWork(request, id);

                if (work != null)
                {
                    return this.Ok(work);
                }

                return this.NotFound("Client, car or work were not found!");
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to delete a <see cref="Work"/> entity.
        /// </summary>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>A boolean of the result.</returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<bool>> DeleteWork([FromRoute] Guid id)
        {
            try
            {
                bool work = await this.repository.DeleteWork(id);

                if (work)
                {
                    return this.Ok(work);
                }

                return this.NotFound("Work was not found!");
            }
            catch (Exception)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to update a <see cref="Work"/> status.
        /// </summary>
        /// <param name="request">Request for the update.</param>
        /// <param name="id">Id of the <see cref="Work"/> entity.</param>
        /// <returns>An updated <see cref="Work"/> entity.</returns>
        [HttpPut]
        [Route("updatestatus/{id:guid}")]
        public async Task<ActionResult<Work>> UpdateWorkStatus(
            [FromBody] UpdateWorkStatusRequest request,
            [FromRoute] Guid id)
        {
            try
            {
                var work = await this.repository.UpdateWorkStatus(request, id);

                if (work != null)
                {
                    return this.Ok(work);
                }

                return this.NotFound("Work was not found!");
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
