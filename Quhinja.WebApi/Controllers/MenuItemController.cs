using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Implementations;
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
        [HttpGet]
        [Route("twoWeeks")]
        public async Task<ActionResult<ICollection<TwoWeekDay>>> GetTwoWeeks()
        {
            var menuItemOtuputModel = await menuItemService.GetTwoWeeks();

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


        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult> RemoveMenuItemAsync(int id)
        {
            await menuItemService.RemoveMenuItemAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("addMenuItem")]

        public async Task<ActionResult> AddMenuItem(MenuItemBasicInputModel id)
        {
            string s = id.ToString();
            await menuItemService.AddMenuItem(id);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("deleteByDate")]

        public async Task<ActionResult> RemoveMenuItemAByDateAsync(MenuItemBasicInputModel id)
        {
            string s = id.ToString();
           await menuItemService.removeMenuItemByDate(id);
            return Ok();
        }

    }
}

