using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service
{
    public class WorksheetMaterial
    {
        public int Id { get; set; }

        public int WorksheetId { get; set; }
        [ForeignKey("WorksheetId")]
        [InverseProperty("WorksheetMaterials")]
        public virtual Worksheet Worksheet { get; set; }

        public int MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        [InverseProperty("MaterialWorksheets")]
        public virtual Material Material { get; set; }

        public int Quantity { get; set; }
    }
}
