using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Interfaces;
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
    }
}
