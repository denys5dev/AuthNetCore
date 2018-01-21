using System.ComponentModel.DataAnnotations;

namespace AuthNetCore.Resources
{
    public class UserResource
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}