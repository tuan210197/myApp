using System.ComponentModel.DataAnnotations;

namespace myApp.Model
{
    public class UserLogin
    {
        [Required, EmailAddress]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }

        
    }
}
