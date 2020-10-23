using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.OutputModels.DishType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quhinja.WebApi.Controllers
{
    public class DishTypeController : ApiController
    {
        private readonly IDishTypeService dishTypeService;

        public DishTypeController(IDishTypeService dishTypeService)
        {
            this.dishTypeService = dishTypeService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DishTypeBasicOutputModel>> GetDishTypeByIdAsync(int id)
        {
            var dishTypeOutputModel = await dishTypeService.GetDishTypeByIdAsync(id);
            return Ok(dishTypeOutputModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ICollection<DishTypeBasicOutputModel>>> GetDishTypesAsync()
        {
            var dishTypeOutputModels = await dishTypeService.GetDishTypesAsync();
            return Ok(dishTypeOutputModels);
        }

    }
}
