using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.DTO
{
    /// <summary>
    /// Validates the inputs during registration
    /// </summary>
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "The first name is required!")]
        [RegularExpression(@"^[A-Z][a-z]*", ErrorMessage = "First name is not valid!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required!")]
        [RegularExpression(@"^[A-Z][a-z]*", ErrorMessage = "Last name is not valid!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }

        [RegularExpression(@"^(\(\+36\)) [0-9]{2}\/[0-9]{3}-[0-9]{4}",
            ErrorMessage = "Phone number is not valid!")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^[A-Z]{1,2}",
            ErrorMessage = "Country is not valid!")]
        public string Country { get; set; }

        [RegularExpression(@"^[A-Z0-9](?:\S.{0,}\S\w)?$",
            ErrorMessage = "Zip code is not valid!")]
        public string ZipCode { get; set; }

        [RegularExpression(@"^[A-Z](?:\S.{0,}\S\w)?$",
            ErrorMessage = "City is not valid!")]
        public string City { get; set; }

        [RegularExpression(@"^[0-9/A-Z]* [A-Z](?:\S.{0,}\S)?$",
            ErrorMessage = "Street is not valid!")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [MinLength(length: 6, ErrorMessage = "The password must be at least {1} characters long!")]
        [MaxLength(length: 20, ErrorMessage = "The password must not be longer than {1} characters!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
