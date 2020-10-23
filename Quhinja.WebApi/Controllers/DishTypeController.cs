using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.DishType;
using Quhinja.Services.Models.OutputModels;
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<int>> AddDishTypeAsync([FromBody] DishTypeBasicInputModel dishTypeInputModel)
        {
            if (ModelState.IsValid)
            {
                var id = await dishTypeService.AddDishTypeAsync(dishTypeInputModel);
                return Ok(id);
            }
            else
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult> DeleteDishTypeAsync(int id)
        {
            await dishTypeService.DeleteDishTypeAsync(id);
            return Ok();
        }

    }
}
