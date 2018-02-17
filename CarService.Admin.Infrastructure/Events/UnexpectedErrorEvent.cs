using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Events
{
    /// <summary>
    /// An event which triggers when an unexpected error
    /// is occured
    /// </summary>
    public class UnexpectedErrorEvent : PubSubEvent<string>
    {
    }
}
