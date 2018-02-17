using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DTO
{
    /// <summary>
    /// Material Data Transfer Object class
    /// </summary>
    public class MaterialDTO : INotifyPropertyChanged
    {
        /// <summary>
        /// The material/component/wage ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the material/component/wage
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the material/component/wage
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The used quantity of the material
        /// </summary>
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        #region Implementing INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
