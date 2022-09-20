using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VirtualIceCream.Models;
using VirtualIceCream.Services;

namespace VirtualIceCream.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientService;

        public IngredientsController(IngredientsService ingredientsService)
        {
            _ingredientService = ingredientsService;
        }

    [HttpGet]

    public ActionResult<List<Ingredient>> getIngredients()
    {
        try 
        {
          List<Ingredient> ingredients = _ingredientService.getIngredients();
          return Ok(ingredients);
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }

    }




    }
}