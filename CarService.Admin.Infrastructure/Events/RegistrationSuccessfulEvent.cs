using Prism.Events;
using System;

namespace CarService.Admin.Infrastructure.Events
{
    /// <summary>
    /// Event which triggers on successful registration
    /// </summary>
    public class RegistrationSuccessfulEvent : PubSubEvent<string>
    {
    }
}
