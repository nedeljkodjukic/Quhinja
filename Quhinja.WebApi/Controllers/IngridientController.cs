using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.Ingridient;
using Quhinja.Services.Models.OutputModels.Ingridient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quhinja.WebApi.Controllers
{
    public class IngridientController :ApiController
    {
        private readonly IIngridientService ingridientService;

        public IngridientController(IIngridientService ingridientService)
        {
            this.ingridientService = ingridientService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IngridientBasicOutputModel>> GetIngridientByIdAsync(int id)
        {
            var ingridientOutputModel = await ingridientService.GetIngridientByIdAsync(id);
            return Ok(ingridientOutputModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ICollection<IngridientBasicOutputModel>>> GetIngridientsAsync()
        {
            var ingridientOutputModel = await ingridientService.GetIngridientsAsync();
            return Ok(ingridientOutputModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<int>> AddIngrdientAsync([FromBody] IngridientBasicInputModel ingridientInputModel)
        {
            if (ModelState.IsValid)
            {
                var id = await ingridientService.AddIngridientAsync(ingridientInputModel);
                return Ok(id);
            }
            else
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("addIngridient")]
        public async Task<ActionResult<int>> AddIngrdientToRecipeAsync([FromBody] IngridientsInRecipeBasicInputModel ingridientInputModel)
        {
            if (ModelState.IsValid)
            {
                var id = await ingridientService.AddIngridientToRecipeAsync(ingridientInputModel);
                return Ok(id);
            }
            else
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult> RemoveIngridientAsync(int id)
        {
            await ingridientService.RemoveIngridientAsync(id);
            return Ok();
        }

    }
}
