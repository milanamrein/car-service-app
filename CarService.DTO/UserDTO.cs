using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DTO
{
    /// <summary>
    /// User Data Transfer Object class
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// The user's ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The user's username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user's full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The partner's address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The partner's reservations
        /// </summary>
        public virtual ICollection<ReservationDTO> PartnerReservations { get; set; }

        /// <summary>
        /// The partner's worksheets
        /// </summary>
        public virtual ICollection<WorksheetDTO> PartnerWorksheets { get; set; }

        /// <summary>
        /// The mechanic's reservations
        /// </summary>
        public virtual ICollection<ReservationDTO> MechanicReservations { get; set; }

        /// <summary>
        /// The mechanic's worksheets
        /// </summary>
        public virtual ICollection<WorksheetDTO> MechanicWorksheets { get; set; }

        /// <summary>
        /// The user's JSON Web Token
        /// </summary>
        public string Token { get; set; }
    }
}
