using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows;

namespace CarService.Admin.Modules.Auth.Attached_Properties
{
    /// <summary>
    /// Attached properties of PasswordBox
    /// </summary>
    public static class PasswordBoxAttachedProperties
    {

        /// <summary>
        /// Attached property for binding to the PasswordBox's value - the password
        /// </summary>
        public static string GetEncryptedPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(EncryptedPasswordProperty);
        }

        public static void SetEncryptedPassword(DependencyObject obj, string value)
        {
            obj.SetValue(EncryptedPasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for EncryptedPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EncryptedPasswordProperty =
            DependencyProperty.RegisterAttached("EncryptedPassword", typeof(string), typeof(PasswordBoxAttachedProperties));

    }
}
