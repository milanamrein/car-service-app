using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Events
{
    /// <summary>
    /// An event that sends an error message 
    /// when worksheet creation fails
    /// </summary>
    public class CreateWorksheetFailedEvent : PubSubEvent<string>
    {
    }
}
