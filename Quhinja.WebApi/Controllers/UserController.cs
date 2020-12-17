using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Implementations;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.User;
using Quhinja.Services.Models.OutputModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Quhinja.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService userService;
        private readonly IBlobService blobService;

        public UserController(IUserService userService, IBlobService blobService)
        {
            this.userService = userService;
            this.blobService = blobService;
        }
        //admin role
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<UserInfoOutputModel>> GetUsers()
        {
            var users = await userService.GetUsers();

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("todayBirthUsers")]
        public async Task<ActionResult<UserInfoOutputModel>> GetTodayBirthUsers()
        {
            var users = await userService.GetTodayBirthUsers();

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("todayEmplUsers")]
        public async Task<ActionResult<UserInfoOutputModel>> GetTodayEmployeeDateUsers()
        {
            var users = await userService.GetTodayEmployeeDateUsers();

            return Ok(users);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("getRatingForUser/{dishId}")]
        public async Task<ActionResult<int>> GetRatingForUser([FromRoute] int dishId)
        {

            int usersId;
                var userIdstring = this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                 int.TryParse(userIdstring, out usersId);

        var user = await userService.GetUserAsync(usersId);
            int rating = await userService.GetRatingForUser(usersId ,dishId);
                return rating;
    }
    [Authorize(Roles = "admin,user")]

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserInfoOutputModel>> GetUserAsync([FromRoute] int id)
        {
            if (id == 0)
            {
                var userIdstring = this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                int.TryParse(userIdstring, out id);
            }
            var user = await userService.GetUserAsync(id);
            return Ok(user);
        }
        [Produces("application/json-patch+json")]
        [Authorize(Roles = "admin,user")]
        [HttpPost]
        [Route("uploadPicture")]
        public async Task<ActionResult<string>> UploadProfilePicture()
        {
            var files = this.Request.Form.Files;

          //  var resultUrl = await blobService.UploadPictureAsync(files.First(), BlobService.ProfilePicturesContainer);
            var bytes = await blobService.GetBytesFromPicture(files.First());
            var userIdstring = this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            int.TryParse(userIdstring, out int userId);

         //   await userService.UpdateProfilePictureAsync(userId, resultUrl);
            await userService.UpdateProfilePictureBytesAsync(userId, bytes);

            return Ok(bytes);
        }
        [Authorize(Roles = "admin,user")]
        [HttpPut]
        [Route("update-user")]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UserUpdateInputModel userInputModel)
        {
            
            var userIdstring = this.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            
            int.TryParse(userIdstring, out int userId);
            await userService.UpdateUserAsync(userInputModel, userId);
            return Ok();
        }
    }
}
