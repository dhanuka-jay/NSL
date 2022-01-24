using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSL.Models
{   
    public class CreatePlayerDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "FirstName is Too Long !")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "LastName is Too Long !")]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "PhoneNumber is Too Long!, Please limit it to 10 digits")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class PlayerDTO : CreatePlayerDTO
    {
        public int Id { get; set; }

    }

}
