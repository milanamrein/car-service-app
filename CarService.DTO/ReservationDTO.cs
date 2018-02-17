using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DTO
{
    /// <summary>
    /// Data Transfer Object class for Reservations
    /// </summary>
    public class ReservationDTO
    {
        /// <summary>
        /// The reservation's ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The time of the appointment
        /// </summary>        
        public DateTime Time { get; set; }

        /// <summary>
        /// The partner who made the reservation
        /// </summary>
        public virtual UserDTO Partner { get; set; }

        /// <summary>
        /// The mechanic who should deal with the reservation
        /// </summary>
        public virtual UserDTO Mechanic { get; set; }

        /// <summary>
        /// The reservation's worksheet
        /// </summary        
        public virtual WorksheetDTO Worksheet { get; set; }

        /// <summary>
        /// Type of the reservation
        /// </summary>
        public virtual ReservationTypeDTO Type { get; set; }

        /// <summary>
        /// Partners allowed to make a comment in a reservation
        /// </summary>
        public string Comment { get; set; }
    }
}
