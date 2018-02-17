using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Helpers
{
    /// <summary>
    /// Helpers for password validation
    /// </summary>
    public static class PasswordHelpers
    {
        /// <summary>
        /// Converts a secure string into a plain text
        /// </summary>
        /// <param name="securePassword">The secure string</param>
        /// <returns>The plain text</returns>
        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        /// <summary>
        /// Checks if a password is valid
        /// when registering
        /// </summary>
        /// <param name="password">The password</param>
        /// <returns>Whether the password is valid or not</returns>
        public static bool IsPasswordValid(string password)
        {
            return (password.Any(c => char.IsDigit(c)) && password.Any(c => char.IsUpper(c))
                && password.Any(c => char.IsPunctuation(c)) && !password.Any(c => char.IsWhiteSpace(c)));
        }
    }
}
