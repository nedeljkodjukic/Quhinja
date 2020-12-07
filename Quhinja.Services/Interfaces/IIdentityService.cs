using Quhinja.Services.Models.InputModels.User;
using Quhinja.Services.Models.OutputModels;
using Quhinja.Services.Models.OutputModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quhinja.Services.Interfaces
{
    public interface  IIdentityService
    {
          Task<bool> ChangePassword(string cPass, string newP, string email);

        Task<bool> IsEmailOccupied(string email);
        Task LoginAsync(UserLoginInputModel userLoginInputModel);
        Task<UserRegistrationOutputModel> RegisterAsync(UserRegistrationInputModel userRegistrationInputModel);
        Task<int> RegisterAdminAsync(AdminRegistrationInputModel adminRegistrationInputModel);
        Task<string> ForgotPasswordAsync(string email);

        Task<bool> ResetPasswordAsync(string email, string code, string password);
        Task<TokenOutputModel> GenerateToken(string email, string secret, double expiration);
    }
}
