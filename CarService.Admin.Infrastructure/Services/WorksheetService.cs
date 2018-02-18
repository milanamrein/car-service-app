using CarService.Admin.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.DTO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Worksheet Service
    /// </summary>
    public class WorksheetService : IWorksheetService
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

        public WorksheetService(ICarService carService)
        {
            _carService = carService;
            _url = _carService.Client.BaseAddress + "worksheets/";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new worksheet
        /// </summary>
        /// <param name="worksheetDTO">The new worksheet</param>
        /// <param name="argToken">The user's token</param>
        /// <returns>The created worksheet's ID</returns>
        public async Task<int> CreateWorksheetAsync(WorksheetDTO worksheetDTO, string argToken)
        {
            try
            {

                return await _carService.CreateAsync<WorksheetDTO, int>(_url, worksheetDTO, argToken);

            } catch(Exception ex)
            {
                throw ex;
            }
        }        

        #endregion
    }
}
