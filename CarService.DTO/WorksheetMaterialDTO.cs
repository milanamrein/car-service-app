using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DTO
{
    /// <summary>
    /// WorksheetMaterial Data Transfer Object Class
    /// </summary>
    public class WorksheetMaterialDTO
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int WorksheetId { get; set; }
        public int Quantity { get; set; }
    }
}
