using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quhinja.Data.Entities;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.User;
using Quhinja.Services.Models.OutputModels;
using Quhinja.Services.Models.OutputModels.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Implementations
{
   public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly IMapper mapper;

        public IdentityService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.mapper = mapper;

        }

        public async Task<bool> IsEmailOccupied(string email)
        {
            return await userManager.FindByEmailAsync(email) != null;
        }

        public async Task LoginAsync(UserLoginInputModel userLoginInputModel)
        {
            var user = await userManager.FindByEmailAsync(userLoginInputModel.Email);

            if (user == null)
            {
                throw new InvalidOperationException("Ne postoji korisnik sa datom email adresom");
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, userLoginInputModel.Password, false, true);

            if (signInResult.IsLockedOut)
            {
                throw new InvalidOperationException("Pokušali ste da se logujete neuspešno 5 puta, molimo sačekaje 5 minuta");
            }

            if (!signInResult.Succeeded)
            {
                throw new InvalidOperationException("Pogrešna šifra");
            }
        }

        public async Task<UserRegistrationOutputModel> RegisterAsync(UserRegistrationInputModel userRegistrationInputModel)
        {
            var user = mapper.Map<User>(userRegistrationInputModel);

            string pass = userRegistrationInputModel.Name + "." + userRegistrationInputModel.Surname + 1;

            var result = await userManager.CreateAsync(user, pass);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(string.Join(" ", result.Errors.Select(x => x.Description)));
            }

            var roles = userRegistrationInputModel.Admin ? new string[] { "Admin", "User" } : new string[] { "User" };

            await userManager.AddToRolesAsync(user, roles);

            return new UserRegistrationOutputModel
            {
                Id = user.Id,
                Password = pass
            };
        }

        public async Task<TokenOutputModel> GenerateToken(string email, string secret, double expiration)
        {

            var user = await userManager.FindByEmailAsync(email);

            var roles = await userManager.GetRolesAsync(user);

            var claims = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                });

            foreach (var role in roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var expires = DateTime.UtcNow.AddDays(expiration);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return new TokenOutputModel
            {
                AccessToken = encryptedToken,
                Expires = expires,
                Name = user.Name,
                Surname = user.Surname,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Image = user.Image
            };
        }

        public async Task<string> ForgotPasswordAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new Exception("Korisnik sa traženom email adresom ne postoji u sistemu");
            }
            var code = await userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            return code;
        }
        public async Task<bool> ChangePassword( string cPass, string newP,  string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new Exception("Korisnik sa traženom email adresom ne postoji u sistemu");
            }

          
            var result = await userManager.ChangePasswordAsync(user, cPass,newP);

            return result.Succeeded;
        }


        public async Task<bool> ResetPasswordAsync(string email, string code, string password)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new Exception("Korisnik sa traženom email adresom ne postoji u sistemu");
            }

            var decoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ResetPasswordAsync(user, decoded, password);

            return result.Succeeded;
        }

        public async Task<int> RegisterAdminAsync(AdminRegistrationInputModel adminRegistrationInputModel)
        {
            var user = mapper.Map<User>(adminRegistrationInputModel);

            var result = await userManager.CreateAsync(user, adminRegistrationInputModel.Password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(string.Join(" ", result.Errors.Select(x => x.Description)));
            }


            await userManager.AddToRoleAsync(user, "admin");

            return user.Id;
        }

       
    }
}
    

