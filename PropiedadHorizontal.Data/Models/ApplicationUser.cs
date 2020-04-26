using Microsoft.AspNetCore.Identity;

namespace PropiedadHorizontal.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}