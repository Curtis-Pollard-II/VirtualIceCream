using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualIceCream.Models;
using VirtualIceCream.Services;

namespace VirtualIceCream.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;

        public FavoritesController(FavoritesService favoritesService)
        {
            _favoritesService = favoritesService;
        }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Hearts>> Create([FromBody] Favorite favorite)
    {
        try 
        {
          Hearts user = await HttpContext.GetUserInfoAsync<Hearts>();
          favorite.AccountId = user.Id;
          Favorite newFavorite = _favoritesService.Create(favorite);
          user.favoritesId = newFavorite.Id;
          return user;
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> UnHeart(int id)
    {
        try 
        {
          Account user = await HttpContext.GetUserInfoAsync<Account>();
          string message = _favoritesService.UnHeart(id, user);
          return Ok(message);
        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
    }


    }
}