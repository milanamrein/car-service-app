using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarService.DTO;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace CarService.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/worksheets")]
    public class WorksheetsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WorksheetsController> _logger;

        public WorksheetsController(
            IUnitOfWork unitOfWork,
            ILogger<WorksheetsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Worksheets/5
        /// <summary>
        /// Gets a worksheet
        /// </summary>
        /// <param name="id">The worksheet's ID</param>
        /// <returns>The worksheet</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetWorksheet([FromRoute] int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WorksheetDTO worksheet = _unitOfWork.Worksheets.GetWorksheet(id);

                if (worksheet == null)
                {
                    return NotFound("Workheet cannot be found!");
                }

                return Ok(worksheet);

            } catch(Exception ex)
            {
                _logger.LogError("Unexpected error has occured during HTTP request: ", ex.Message);
                return StatusCode(500, $"Unexpected error while getting worksheet: {ex.Message}");
            }            
        }        

        // POST: api/Worksheets
        /// <summary>
        /// Creates a new worksheet
        /// </summary>
        /// <param name="worksheetDTO">The new worksheet</param>
        /// <returns>Whether the creation was successful or not</returns>
        [Authorize(Roles = "Mechanic")]
        [HttpPost]
        public async Task<IActionResult> PostWorksheet([FromBody] WorksheetDTO worksheetDTO)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // check if there's any material added
                if (worksheetDTO.Materials.Count <= 0)
                    return BadRequest("The worksheet has to have at least one material!");                

                Worksheet worksheet = _unitOfWork.Worksheets.Add(worksheetDTO);               
                await _unitOfWork.Complete();

                return CreatedAtAction("GetWorksheet", new { id = worksheet.Id }, worksheet.Id);

            } catch(Exception ex)
            {
                _logger.LogError("Unexpected error has occured during HTTP request: ", ex.Message);
                return StatusCode(500, $"Unexpected error while creating worksheet: {ex.Message}");
            }            
        }
    }
}