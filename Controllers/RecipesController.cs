using System.Collections.Generic;
using csharp_allspice.Models;
using csharp_allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp_allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _recipesService;
    private readonly IngredientsService _ingredientsService;
    public RecipesController(RecipesService recipesService, IngredientsService ingredientsService)
    {
      _recipesService = recipesService;
      _ingredientsService = ingredientsService;

    }

    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> Get()
    {
      try
      {
        return Ok(_recipesService.Get());
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> Get(int recipeId)
    {
      try
      {
        return Ok(_recipesService.Get(recipeId));
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}/ingredients")]
    public ActionResult<IEnumerable<Ingredient>> GetIngredients(int id)
    {
      try
      {
        IEnumerable<Ingredient> data = _ingredientsService.GetByRecipeId(id);
        return Ok(data);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Recipe> Create([FromBody] Recipe newRecipe)
    {
      try
      {
        return Ok(_recipesService.Create(newRecipe));
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpPut("{recipeId}")]
    public ActionResult<Recipe> Edit([FromBody] Recipe editedRecipe, int recipeId)
    {
      try
      {
        editedRecipe.Id = recipeId;
        return Ok(_recipesService.Edit(editedRecipe));
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{recipeId}")]
    public ActionResult<string> Delete(int recipeId)
    {
      try
      {
        return Ok(_recipesService.Delete(recipeId));
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }
  }
}