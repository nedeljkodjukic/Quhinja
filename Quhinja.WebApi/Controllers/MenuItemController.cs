using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.MenuItem;
using Quhinja.Services.Models.OutputModels.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quhinja.WebApi.Controllers
{
    public class MenuItemController : ApiController
    {
        private readonly IMenuItemService menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            this.menuItemService = menuItemService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<MenuItemBasicOutputModel>> GetMenuItemByIdAsync(int id)
        {
            var menuItemOtuputModel = await menuItemService.GetMenuItemByIdAsync(id);
            return Ok(menuItemOtuputModel);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("todaysRecipe")]
        public async Task<ActionResult<MenuItemBasicOutputModel>> GetTodaysRecipe()
        {
            var menuItemOtuputModel = await menuItemService.GetTodayMenuItem();
            return Ok(menuItemOtuputModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("addMissedDate")]
        public async Task<ActionResult<int>> AddMissedDate(MissedLunchBasicInputModel input)
        {
            var id = await menuItemService.AddMissedDate(input);
            return id;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ICollection<MenuItemBasicOutputModel>>> GetMenuItemsAsync()
        {
            var menuItemOtuputModel = await menuItemService.GetMenuItemsAsync();
            return Ok(menuItemOtuputModel);
        }

  
    }
}
