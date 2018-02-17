using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarService.DTO;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;

namespace CarService.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/reservations")]
    [Authorize(Roles = "Partner")]
    public class ReservationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReservationsController> _logger;

        public ReservationsController(
            IUnitOfWork unitOfWork,
            ILogger<ReservationsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Reservations/5     
        [HttpGet("{id}")]
        public IActionResult GetReservation([FromRoute] int id)
        {
            try
            { 

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ReservationDTO reservation = _unitOfWork.Reservations.GetReservation(id);

                if (reservation == null)
                    return NotFound("Reservation cannot be found!");                

                return Ok(reservation);

            } catch(Exception ex)
            {
                _logger.LogError("Unexpected error has occured during HTTP request: ", ex.Message);
                return StatusCode(500, $"Unexpected error while getting reservation: {ex.Message}");
            }
        }        

        // POST: api/Reservations     
        [HttpPost]
        public async Task<IActionResult> PostReservation([FromBody] ReservationDTO reservationDTO)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // checking if there is already a reservation at that time with the same mechanic
                Reservation takenReservations = 
                    _unitOfWork.Reservations.Find(res => DateTime.Compare(res.Time, reservationDTO.Time) == 0);
                if (takenReservations != null
                    && reservationDTO.Mechanic.Id.Equals(takenReservations.MechanicId))
                {
                    return BadRequest("This time is already booked at that mechanic!");
                }

                Reservation reservation = _unitOfWork.Reservations.Add(reservationDTO);
                await _unitOfWork.Complete();

                return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation.Id);

            } catch(Exception ex)
            {
                _logger.LogError("Unexpected error has occured during HTTP request: ", ex.Message);
                return StatusCode(500, $"Unexpected error while creating reservation: {ex.Message}");
            }            
        }

        // DELETE: api/Reservations/5       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] int id)
        {
            try
            { 

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Reservation reservation = _unitOfWork.Reservations.Get(id);
                if (reservation == null)                
                    return NotFound("Reservation cannot be found!");                

                _unitOfWork.Reservations.Remove(reservation);
                await _unitOfWork.Complete();

                return Ok(reservation);

            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error has occured during HTTP request: ", ex.Message);
                return StatusCode(500, $"Unexpected error while deleting reservation: {ex.Message}");
            }
        }
    }
}