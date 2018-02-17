using CarService.Admin.Modules.Auth.Attached_Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarService.Admin.Modules.Auth.Views
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        // sets the PasswordBox's value to the attached property
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            PasswordBoxAttachedProperties.SetEncryptedPassword(passwordBox, passwordBox.Password);
        }

        // sets the Password again PasswordBox's value to the attached property
        private void PasswordAgainBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordAgainBox = sender as PasswordBox;
            PasswordBoxAttachedProperties.SetEncryptedPassword(passwordAgainBox, passwordAgainBox.Password);
        }
    }
}
