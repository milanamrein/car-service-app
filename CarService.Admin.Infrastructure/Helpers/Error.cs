using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Helpers
{
    /// <summary>
    /// The class that gets the error messages as an object from the Json content
    /// </summary>
    public class Error
    {
        /// <summary>
        /// The general error message which comes with the specific error messages
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The errors themselves as a <see cref="Dictionary{string, List}"/> from the Json content
        /// </summary>
        public Dictionary<string, List<string>> ModelState { get; set; }
    }
}
