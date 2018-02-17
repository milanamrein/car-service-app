using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DTO
{
    /// <summary>
    /// Data Transfer Object class for Reservation types
    /// </summary>
    public class ReservationTypeDTO
    {
        /// <summary>
        /// The ID of the reservation type
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the reservation type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The reservations associated with a type
        /// </summary>
        public virtual ICollection<ReservationDTO> Reservations { get; set; }
    }
}
