using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CarService.DTO;
using AutoMapper;

namespace CarService.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/materials")]
    public class MaterialsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MaterialsController> _logger;

        public MaterialsController(
            IUnitOfWork unitOfWork,
            ILogger<MaterialsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Materials
        /// <summary>
        /// Gets all the materials
        /// </summary>
        /// <returns>All the materials</returns>
        [Authorize(Roles = "Mechanic")]
        [HttpGet]
        public IActionResult GetMaterials()
        {
            try
            {

                IEnumerable<MaterialDTO> materials = _unitOfWork.Materials.GetAll();

                if (materials.Count() == 0)
                    return NotFound("Materials cannot be found!");

                return Ok(materials);

            } catch(Exception ex)
            {
                _logger.LogError("Unexpected error has occured during HTTP request: ", ex.Message);
                return StatusCode(500, $"Unexpected error during HTTP request: {ex.Message}");
            }
        }     
    }
}