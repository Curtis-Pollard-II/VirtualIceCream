using System;
using System.Collections.Generic;
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
    public class OrderController : ControllerBase
    {
        private readonly OrdersService _ordersService;
        private readonly FavoritesService _favoritesService;

        public OrderController(OrdersService ordersService, FavoritesService favoritesService)
        {
            _ordersService = ordersService;
            _favoritesService = favoritesService;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            try 
            {
              List<Order> orders = _ordersService.GetOrders();
              return Ok(orders);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Order>> Create([FromBody] Order newOrder)
        {
          try 
          {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            newOrder.CreatorId = userInfo.Id;
            Order order = _ordersService.Create(newOrder);
            order.Creator = userInfo;
            return Ok(order);
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          }
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOne(int id)
        {
          try 
          {
            Order order = _ordersService.GetOne(id);
            return Ok(order);
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          }
        }

        [HttpGet("{id}/favorites")]

        public ActionResult<List<Hearts>> GetHearts(int id)
        {
          try 
          {
            List<Hearts> hearts = _favoritesService.GetHearts(id);
            return Ok(hearts);
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          }
        }
        





    }
}