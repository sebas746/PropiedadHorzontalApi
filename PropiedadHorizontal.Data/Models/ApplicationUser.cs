using Microsoft.AspNetCore.Identity;

namespace PropiedadHorizontal.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add additional profile data for application users by adding properties to this class
        public string Name { get; set; }
    }
}
