using Microsoft.AspNetCore.Identity;
using myApp.Model;

namespace myApp.Repository
{
    public interface IAccountRepoitory
    {
        public  Task<IdentityResult> registerAsync(RegisterModel model);
        public Task<string> userLogin(UserLogin userLogin);
    }
}
