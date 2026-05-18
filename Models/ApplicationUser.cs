using Microsoft.AspNetCore.Identity;

namespace ELGlamPOS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
