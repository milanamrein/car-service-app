using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarService.DTO;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace CarService.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/reservationtypes")]
    public class ReservationTypesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReservationTypesController> _logger;

        public ReservationTypesController(
            IUnitOfWork unitOfWork,
            ILogger<ReservationTypesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/ReservationTypes
        /// <summary>
        /// Gets all the reservation types
        /// </summary>
        /// <returns>The reservation types</returns>
        [Authorize(Roles = "Partner")]
        [HttpGet]
        public IActionResult GetReservationTypes()
        {
            try
            {

                IEnumerable<ReservationTypeDTO> reservationTypes = _unitOfWork.ReservationTypes.GetAll();

                if (reservationTypes.Count() == 0)
                    return NotFound("Reservation types cannot be found!");

                return Ok(reservationTypes);

            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error has occured during HTTP request: ", ex.Message);
                return StatusCode(500, $"Unexpected error during HTTP request: {ex.Message}");
            }
        }
    }
}