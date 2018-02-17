using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Service
{
    /// <summary>
    /// Stores the partners and mechanics in one table called Users
    /// </summary>
    public class User : IdentityUser
    {
        public User()
        {
            this.PartnerReservations = new HashSet<Reservation>();
            this.PartnerWorksheets = new HashSet<Worksheet>();
            this.MechanicReservations = new HashSet<Reservation>();
            this.MechanicWorksheets = new HashSet<Worksheet>();
        }
        /// <summary>
        /// The user's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The partner's address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The partner's reservations
        /// </summary>
        [InverseProperty("Partner")]
        public virtual ICollection<Reservation> PartnerReservations { get; set; }

        /// <summary>
        /// Worksheets made for the partner
        /// </summary>
        [InverseProperty("Partner")]
        public virtual ICollection<Worksheet> PartnerWorksheets { get; set; }

        /// <summary>
        /// The mechanic's reservations
        /// </summary>
        [InverseProperty("Mechanic")]
        public virtual ICollection<Reservation> MechanicReservations { get; set; }

        /// <summary>
        /// Worksheets made for the mechanic
        /// </summary>
        [InverseProperty("Mechanic")]
        public virtual ICollection<Worksheet> MechanicWorksheets { get; set; }
    }
}
