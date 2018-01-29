using System.ComponentModel.DataAnnotations;

namespace AuthNetCore.Resources
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}