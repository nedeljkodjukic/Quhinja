using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Implementations;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.Dish;
using Quhinja.Services.Models.InputModels.Recipe;
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
        public async Task<ActionResult<DishWithRecipesOutputModel>> GetDishByIdAsync(int id)
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
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("changeSelectedRecipe")]

        public async Task<ActionResult<int>> SelectRecipe([FromBody] DishSelectedRecipeInput input)
        {
            if (ModelState.IsValid)
            {
                var id = await dishService.selectRecipe(input);
                return Ok(id);
            }
            else
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
        }

        [Authorize(Roles = "user")]

        [HttpPost]
        [Route("rateDish")]

        public async Task<ActionResult<float>> RateDishAsync([FromBody] UsersRatingForDishInputModel ratingInput)
        {
            if (ModelState.IsValid)
            {
                var id = await dishService.RateDishAsync(ratingInput);
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

            var files= this.Request.Form.Files;

            //   var path = await blobService.UploadPictureAsync(files.First(), BlobService.DishPicturesContainer);
            var bytes = await blobService.GetBytesFromPicture(files.First());
            await dishService.AddImageBytesAsync(dishId, bytes);


            //    await dishService.AddImageToDishAsync( dishId, path);
            

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("dishTypes")]
        public async Task<ActionResult<ICollection<string>>> GetDishTypesAsync()
        {
            var dishTypes = await dishService.GetDishTypesAsync();
            return Ok(dishTypes);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getSortedDishes")]
        public async Task<ActionResult<ICollection<DishBasicOutputModel>>> GetSortedDishesAsync()
        {
            var dishOutputModel = await dishService.GetSortedDishesAsync();
            return Ok(dishOutputModel);
        }
    }
}
