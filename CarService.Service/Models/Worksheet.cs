using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service
{
    public class Worksheet
    {
        public Worksheet()
        {
            this.WorksheetMaterials = new HashSet<WorksheetMaterial>();
        }

        /// <summary>
        /// The worksheet's ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The partner who the worksheet was made for
        /// </summary>
        public string PartnerId { get; set; }
        [ForeignKey("PartnerId")]
        [InverseProperty("PartnerWorksheets")]
        public virtual User Partner { get; set; }

        /// <summary>
        /// The mechanic who created the worksheet
        /// </summary>
        public string MechanicId { get; set; }
        [ForeignKey("MechanicId")]
        [InverseProperty("MechanicWorksheets")]
        public virtual User Mechanic { get; set; }

        /// <summary>
        /// Reservation which the worksheet was created for
        /// </summary>
        public int ReservationId { get; set; }
        [ForeignKey("ReservationId")]
        [InverseProperty("Worksheet")]
        public virtual Reservation Reservation { get; set; }

        /// <summary>
        /// The materials needed to work
        /// </summary>
        [InverseProperty("Worksheet")]
        public virtual ICollection<WorksheetMaterial> WorksheetMaterials { get; set; }
    }
}
