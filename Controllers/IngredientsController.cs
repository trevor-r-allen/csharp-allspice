using System.Collections.Generic;
using csharp_allspice.Models;
using csharp_allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp_allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ingredientsService;
    public IngredientsController(IngredientsService ingredientsService)
    {
      _ingredientsService = ingredientsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Ingredient>> Get()
    {
      try
      {
        return Ok(_ingredientsService.Get());
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpGet("{ingredientId}")]
    public ActionResult<Ingredient> Get(int ingredientId)
    {
      try
      {
        return Ok(_ingredientsService.Get(ingredientId));
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Ingredient> Create([FromBody] Ingredient newIngredient)
    {
      try
      {
        return Ok(_ingredientsService.Create(newIngredient));
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpPut("{ingredientId}")]
    public ActionResult<Ingredient> Edit([FromBody] Ingredient editedIngredient, int ingredientId)
    {
      try
      {
        editedIngredient.Id = ingredientId;
        return Ok(_ingredientsService.Edit(editedIngredient));
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{ingredientId}")]
    public ActionResult<string> Delete(int ingredientId)
    {
      try
      {
        return Ok(_ingredientsService.Delete(ingredientId));
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }
  }
}