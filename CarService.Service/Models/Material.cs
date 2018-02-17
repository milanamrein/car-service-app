using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service
{
    public class Material
    {
        public Material()
        {
            this.MaterialWorksheets = new HashSet<WorksheetMaterial>();
        }

        /// <summary>
        /// The material ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the material
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the material
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The worksheets using this material
        /// </summary>
        [InverseProperty("Material")]
        public virtual ICollection<WorksheetMaterial> MaterialWorksheets { get; set; }
    }
}
