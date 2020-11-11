using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Implementations;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.Dish;
using Quhinja.Services.Models.OutputModels.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quhinja.WebApi.Controllers
{
    public class DishController : ApiController
    {
        private readonly IDishService dishService;
        private readonly IBlobService blobService;


        public DishController(IDishService dishService,IBlobService blobService)

        {
            this.dishService = dishService;
            this.blobService = blobService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DishBasicOutputModel>> GetDishByIdAsync(int id)
        {
            var dishOutputModel = await dishService.GetDishByIdAsync(id);
            return Ok(dishOutputModel);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ICollection<DishBasicOutputModel>>> GetDishesAsync()
        {
            var dishOutputModel = await dishService.GetDishesAsync();
            return Ok(dishOutputModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("withRecipes")]
        public async Task<ActionResult<ICollection<DishWithRecipesOutputModel>>> GetDishesWithRecipesAsync()
        {
            var dishOutputModel = await dishService.GetDishesWithRecipesAsync();
            return Ok(dishOutputModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<int>> AddDishAsync([FromBody] DishBasicInputModel dishInputModel)
        {
            if (ModelState.IsValid)
            {
                var id = await dishService.AddDishAsync(dishInputModel);
                return Ok(id);
            }
            else
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult> RemoveDishAsync(int id)
        {
            await dishService.RemoveDishAsync(id);
            return Ok();
        }

        [Produces("application/json-patch+json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("{dishId}/uploadDishPicture")]
        public async Task<ActionResult> uploadDishPicture([FromRoute] int dishId)
        {

            var files = this.Request.Form.Files;
            foreach (var file in files)
            {
                var path = await blobService.UploadPictureAsync(file, BlobService.DishPicturesContainer);

                await dishService.AddImageToDishAsync( dishId, path);
            }

            return Ok();
        }
    }
}
