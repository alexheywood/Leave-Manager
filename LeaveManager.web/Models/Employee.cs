using Microsoft.AspNetCore.Identity;

namespace LeaveManager.web.Models
{
    public class Employee : IdentityUser
    {
        public String FirstName { get; set; }   
        public String LastName { get; set; }
        public String TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
