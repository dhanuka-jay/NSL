using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSL.Data
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
