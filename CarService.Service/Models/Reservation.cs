using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service
{
    public class Reservation
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
        /// The user who made the reservation
        /// </summary>
        public string PartnerId { get; set; }
        [ForeignKey("PartnerId")]
        [InverseProperty("PartnerReservations")]
        public virtual User Partner { get; set; }

        /// <summary>
        /// The mechanic who should deal with the reservation
        /// </summary>
        public string MechanicId { get; set; }
        [ForeignKey("MechanicId")]
        [InverseProperty("MechanicReservations")]
        public virtual User Mechanic { get; set; }

        /// <summary>
        /// Type of the reservation
        /// </summary>
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        [InverseProperty("Reservations")]
        public virtual ReservationType Type { get; set; }

        /// <summary>
        /// The reservation's worksheet
        /// </summary>
        [InverseProperty("Reservation")]
        public virtual Worksheet Worksheet { get; set; }

        /// <summary>
        /// Partners allowed to make a comment in a reservation
        /// </summary>
        public string Comment { get; set; }
    }
}