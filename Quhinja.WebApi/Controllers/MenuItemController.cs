using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Interfaces;
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
        public async Task<ActionResult<ICollection<MenuItemBasicOutputModel>>> GetMenuItemsAsync()
        {
            var menuItemOtuputModel = await menuItemService.GetMenuItemsAsync();
            return Ok(menuItemOtuputModel);
        }

  
    }
}
