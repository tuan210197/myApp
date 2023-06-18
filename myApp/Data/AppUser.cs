using Microsoft.AspNetCore.Identity;

namespace myApp.Data
{
    public class AppUser :IdentityUser
    {

        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;


    }
}
