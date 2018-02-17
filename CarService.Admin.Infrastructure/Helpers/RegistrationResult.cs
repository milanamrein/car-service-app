using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CarService.Admin.Infrastructure.Helpers
{
    /// <summary>
    /// The class that gets the result of the registration process
    /// </summary>
    public class RegistrationResult
    {
        /// <summary>
        /// Indicates whether the registration process was successful or not
        /// </summary>
        public bool RegistrationWasSuccessful { get; set; }

        /// <summary>
        /// The registration messages
        /// </summary>
        public ObservableCollection<string> Messages { get; set; }
    }
}
