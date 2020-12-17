using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quhinja.Services.Implementations;
using Quhinja.Services.Interfaces;
using Quhinja.Services.Models.InputModels.Recipe;
using Quhinja.Services.Models.OutputModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quhinja.WebApi.Controllers
{
    public class RecipeController : ApiController
    {
        private readonly IRecipeService recipeService;
        private readonly IBlobService blobService;


        public RecipeController(IRecipeService recipeService, IBlobService blobService)

        {
            this.recipeService = recipeService;
            this.blobService = blobService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RecipeBasicOutputModel>> GetDishByIdAsync(int id)
        {
            var recipeOutputModel = await recipeService.GetRecipeById(id);
            return Ok(recipeOutputModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ICollection<RecipeBasicOutputModel>>> GetRecipesAsync()
        {
            var recipeOutputModel = await recipeService.GetRecipesAsync();
            return Ok(recipeOutputModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("withDish")]
        public async Task<ActionResult<ICollection<RecipeWithDishOutputModel>>> GetRecipeWithDishAsync()
        {
            var recipeOutputModel = await recipeService.GetRecipesWithDishAsync();
            return Ok(recipeOutputModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<int>> AddRecipeAsync([FromBody] RecipeWithDishInputModel recipeInputModel)
        {
            if (ModelState.IsValid)
            {
                var id = await recipeService.AddRecipeAsync(recipeInputModel);
                return Ok(id);
            }
            else
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult> RemoveRecipeAsync(int id)
        {
            await recipeService.RemoveRecipeAsync(id);
            return Ok();
        }

        [Produces("application/json-patch+json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("{recipeId}/uploadRecipePicture")]
        public async Task<ActionResult> uploadRecipePicture([FromRoute] int recipeId)
        {

            var files = this.Request.Form.Files;

            //                var path = await blobService.UploadPictureAsync(files.First(), BlobService.RecipePicturesContainer);
            var bytes = await blobService.GetBytesFromPicture(files.First());
            await recipeService.AddImageBytesAsync(recipeId, bytes);
               // await recipeService.AddImageToRecipeAsync(recipeId, path);
            

            return Ok();
        }
    
    }
}
