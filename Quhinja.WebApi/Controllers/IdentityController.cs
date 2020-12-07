using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Quhinja.Services.Implementations;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.User;
using Quhinja.Services.Models.OutputModels;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Quhinja.WebApi.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService identityService;
        private readonly IConfiguration configuration;
        private readonly IEmailSender emailSender;

        public IdentityController(
            IIdentityService identityService,
            IConfiguration configuration, IEmailSender emailSender
          )
        {
            this.identityService = identityService;
            this.configuration = configuration;
            this.emailSender = emailSender;
        }


        [AllowAnonymous]
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("login")]
        public async Task<ActionResult<TokenOutputModel>> Login([FromBody] UserLoginInputModel userLoginInputModel)
        {
            await identityService.LoginAsync(userLoginInputModel);

            var key = configuration["Authorization:SecretKey"];

            var token = await identityService.GenerateToken(userLoginInputModel.Email, key, 7);

            this.Response.Cookies.Delete(".AspNetCore.Identity.Application");

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("registerAdmin")]
        public async Task<ActionResult<int>> RegisterAdmin([FromBody] AdminRegistrationInputModel adminRegistrationInputModel)
        {
            if (ModelState.IsValid)
            {
                var id = await identityService.RegisterAdminAsync(adminRegistrationInputModel);

                return Ok(id);
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<int>> Register([FromBody] UserRegistrationInputModel userRegistrationInputModel)
        {
            if (ModelState.IsValid)

            {
                var result = await identityService.RegisterAsync(userRegistrationInputModel);

                await emailSender.SendEmailAsync(userRegistrationInputModel.Email, "Quhinja Admin", "Vaša lozinka je: " + result.Password);

                return Ok(result.Id);
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("isEmailOccupied")]
        public async Task<ActionResult<bool>> IsEmailOccupied([FromQuery] string email)
        {
            var result = await identityService.IsEmailOccupied(email);

            return Ok(result);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("forgotPassword")]
        public async Task<ActionResult<bool>> ForgotPassword([FromQuery, BindRequired] string email)
        {
            var resetCode = await identityService.ForgotPasswordAsync(email);

            var emailContent = GenerateResetPasswordEmailContent(email, resetCode);

            await emailSender.SendEmailAsync(email, "Resetovanje šifre", emailContent);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("resetPassword")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordInputModel resetPasswordInputModel)
        {
            //var result = await identityService.ResetPasswordAsync(
            //    resetPasswordInputModel.Email,
            //    resetPasswordInputModel.Code,
            //    resetPasswordInputModel.Password);

            //if (result)
            //{
            //    return Ok();
            //}

            return Conflict("Nažalost, šifra je neuspešno resetovana");
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("changePassword")]
        public async Task<ActionResult> ChangePassword([FromBody] ResetPasswordInputModel resetPasswordInputModel)
        {
            var result = await identityService.ChangePassword(
                resetPasswordInputModel.cPass,
                resetPasswordInputModel.Password,
                                resetPasswordInputModel.Email
);

            if (result)
            {
                await emailSender.SendEmailAsync(resetPasswordInputModel.Email, "Quhinja Admin", "Vaša nova lozinka je: " + resetPasswordInputModel.Password);

                return Ok();
            }

            return Conflict("Nažalost, šifra je neuspešno promenjena");
        }
        private string GenerateResetPasswordEmailContent(string email, string resetCode)
        {
            var clientUrl = configuration["Client:Url"].ToString();

            clientUrl = $"{clientUrl}/resetPassword?email={email}&code={resetCode}";

            return $"Molimo vas da resetujete vašu šifru klikom na sledeći " +
                $"<a href='{clientUrl}'>link</a>";
        }


    }

}
