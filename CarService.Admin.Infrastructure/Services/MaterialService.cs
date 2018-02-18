using CarService.Admin.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarService.DTO;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Materials Service
    /// </summary>
    public class MaterialService : IMaterialService
    {
        #region Fields

        /// <summary>
        /// Base Service
        /// </summary>
        private ICarService _carService;

        /// <summary>
        /// Base url
        /// </summary>
        private string _url;

        #endregion

        #region Default Constructor

        public MaterialService(ICarService carService)
        {
            _carService = carService;
            _url = _carService.Client.BaseAddress + "materials/";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all the materials
        /// </summary>
        /// <param name="argToken">The user's token</param>
        /// <returns>All the materials</returns>
        public async Task<List<MaterialDTO>> GetMaterialsAsync(string argToken)
        {
            try
            {

                return await _carService.GetAsync<List<MaterialDTO>>(_url, argToken);

            } catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
