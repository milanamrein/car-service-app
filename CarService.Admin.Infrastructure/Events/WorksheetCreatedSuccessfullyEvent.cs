using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Events
{
    /// <summary>
    /// Event which triggers when a worksheet
    /// is created successfully
    /// </summary>
    public class WorksheetCreatedSuccessfullyEvent : PubSubEvent<string>
    {
    }
}
