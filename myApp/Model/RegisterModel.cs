using System.ComponentModel.DataAnnotations;

namespace myApp.Model
{
    public class RegisterModel
    {
        [Required]
        public string firstName { get; set; } = null!;
        [Required]
        public string lastName { get; set; } = null!;
        [Required]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public string? cfpassword { get; set; }

    }
}
