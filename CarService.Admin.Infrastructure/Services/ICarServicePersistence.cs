using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Services
{
    /// <summary>
    /// Interface for base Persistence Service
    /// </summary>
    public interface ICarServicePersistence
    {
        /// <summary>
        /// The HttpClient Service
        /// </summary>
        HttpClient Client { get; }

        Task<T> GetAsync<T>(string url, string argToken = "");
        Task<TResult> CreateAsync<TDTO, TResult>(string url, TDTO dTO, string argToken);
        Task<bool> UpdateAsync<TDTO>(string url, object argId, TDTO dTO, string argToken);
        Task<T> DeleteAsync<T>(string url, object argId, string argToken);
    }
}
