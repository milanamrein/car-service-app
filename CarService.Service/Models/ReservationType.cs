using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service
{
    public class ReservationType
    {
        public ReservationType()
        {
            this.Reservations = new HashSet<Reservation>();
        }

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
        [InverseProperty("Type")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
