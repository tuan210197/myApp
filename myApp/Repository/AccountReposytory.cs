using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using myApp.Data;
using myApp.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace myApp.Repository
{
    public class AccountReposytory : IAccountRepoitory
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountReposytory(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IConfiguration configuration) 
        { 
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public async Task<IdentityResult> registerAsync(RegisterModel model)
        {
            if(model.password != model.cfpassword)
            {
                return null;
            }
            var newUser = new AppUser
            {
                firstName = model.firstName,
                lastName = model.lastName,
                Email = model.email,
                UserName = model.email,
                

            };
            
               return await userManager.CreateAsync(newUser,model.password);
            
            
        }

        public async Task<string> userLogin(UserLogin userLogin)
        {
            var result  = await signInManager.PasswordSignInAsync(userLogin.email,  userLogin.password, false, false);
            if(!result.Succeeded)
            {
                return string.Empty;
            }
            var authClaim = new List<Claim>
           {
               new Claim("email", userLogin.email),
               new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
           };

            var authenKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(5),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
