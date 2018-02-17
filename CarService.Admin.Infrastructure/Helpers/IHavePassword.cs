using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Helpers
{
    /// <summary>
    /// Interface for handling password at login
    /// </summary>
    public interface IHavePassword
    {
        SecureString Password { get; }        
    }
}
