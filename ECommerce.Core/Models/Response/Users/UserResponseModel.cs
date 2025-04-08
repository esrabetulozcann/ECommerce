using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Models.Response.Users
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PhoneNumber1 { get; set; }
        public int PhoneNumber2 { get; set; }
    }
}
