﻿using CarService.Admin.Modules.Auth.Attached_Properties;
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
using System.Security;
using CarService.Admin.Infrastructure.Helpers;

namespace CarService.Admin.Modules.Auth.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl, IHavePassword
    {
        public Login()
        {
            InitializeComponent();
        }

        public SecureString Password => passwordBox.SecurePassword;
    }
}
