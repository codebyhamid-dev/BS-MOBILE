using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BS_MOBILE.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
