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

namespace CarService.Admin.Modules.Worksheet.Views.Partials
{
    /// <summary>
    /// Interaction logic for WorksheetTable.xaml
    /// </summary>
    public partial class WorksheetTable : UserControl
    {
        public WorksheetTable()
        {
            InitializeComponent();
            MaterialsComboBox.SelectedItem = null;
        }

        private void MaterialsComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (MaterialsComboBox.SelectedItem != null
                && AddButton.Visibility == Visibility.Collapsed)
                AddButton.Visibility = Visibility.Visible;
        }
    }
}
