using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace App_Simple.Models
{
    public class Form
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "name must be between 4 and 10 character")]
        public string StudentName { get; set; }
        [Required]
        [Range(18, 100, ErrorMessage = "age is should be above 18")]
        public int Age { get; set; }


        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "phone number must be of 10 digits")]
        public int Mobile { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "email must be of proper format")]
        public string Email { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "password {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}