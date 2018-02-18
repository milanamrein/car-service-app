using CarService.Admin.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.DTO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Mechanics Service
    /// </summary>
    public class MechanicService : IMechanicService
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

        public MechanicService(ICarService carService)
        {
            _carService = carService;
            _url = _carService.Client.BaseAddress + "users/Mechanic/";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a mechanic
        /// </summary>
        /// <param name="argId">The mechanic's ID</param>
        /// <param name="argToken">The mechanic's token</param>
        /// <returns>Mechanic data</returns>
        public async Task<UserDTO> GetMechanicAsync(string argId, string argToken)
        {
            try
            {

                return await _carService.GetAsync<UserDTO>($"{_url}{argId}", argToken);

            } catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
