// <copyright file="CarController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Autoszerelo.API.Controllers
{
    using Autoszerelo.API.Repositories;
    using Autoszerelo.Models.Entities;
    using Autoszerelo.Models.Requests;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class for handleing api calls for cars.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarController"/> class.
        /// </summary>
        /// <param name="repository">Reference to repository.</param>
        public CarController(ICarRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Function to get all <see cref="Car"/> entities from the database.
        /// </summary>
        /// <returns>An enumerable list of <see cref="Car" /> class.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            try
            {
                return this.Ok(await repository.GetAllCars());
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to get a <see cref="Car"/> by id.
        /// </summary>
        /// <param name="id">Id of the car.</param>
        /// <returns>A <see cref="Car"/> entity.</returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Car>> GetCarById([FromRoute] Guid id)
        {
            try
            {
                var car = await repository.GetCarById(id);
                if (car != null)
                {
                    return this.Ok(car);
                }

                return NotFound("Car was not found!");
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }

        /// <summary>
        /// Function to create a <see cref="Car"/> entity.
        /// </summary>
        /// <param name="request">Request for creating the car.</param>
        /// <returns>A <see cref="Car"/> entity.</returns>
        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(CreateCarRequest request)
        {
            try
            {
                var car = await repository.CreateCar(request);
                if (car != null)
                {
                    return this.Ok(car);
                }

                return NotFound("Client was not found!");
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "There was a problem with your request");
            }
        }
    }
}
