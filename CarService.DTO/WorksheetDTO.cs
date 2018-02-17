using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DTO
{
    /// <summary>
    /// Data Transfer Object class for Worksheets
    /// </summary>
    public class WorksheetDTO
    {
        /// <summary>
        /// The worksheet's ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The partner who the worksheet was made for
        /// </summary>
        public virtual UserDTO Partner { get; set; }

        /// <summary>
        /// The mechanic who created the worksheet
        /// </summary>
        public virtual UserDTO Mechanic { get; set; }

        /// <summary>
        /// Reservation which the worksheet was created for
        /// </summary>
        public virtual ReservationDTO Reservation { get; set; }

        /// <summary>
        /// The materials needed to work
        /// </summary>
        public virtual ICollection<MaterialDTO> Materials { get; set; }
    }
}
