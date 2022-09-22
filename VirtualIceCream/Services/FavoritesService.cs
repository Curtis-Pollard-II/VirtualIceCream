using System;
using System.Collections.Generic;
using VirtualIceCream.Models;
using VirtualIceCream.Repositories;

namespace VirtualIceCream.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _favRepo;
        private readonly OrdersService _ordersService;

        public FavoritesService(FavoritesRepository favRepo, OrdersService ordersService)
        {
            _favRepo = favRepo;
            _ordersService = ordersService;
        }

        internal List<Hearts> GetHearts(int orderId)
        {
            _ordersService.GetOne(orderId);
            return _favRepo.GetHearts(orderId);
        }

        internal Favorite Create(Favorite favorite)
        {
            _ordersService.GetOne(favorite.OrderId);
            return _favRepo.Create(favorite);
        }

        internal string UnHeart(int id, Account user)
        {
            Favorite favorite = _favRepo.GetOne(id);
            if (favorite == null)
            {
                throw new Exception("no favorite by that id");
            }
            Order order = _ordersService.GetOne(favorite.OrderId);
            if (order.CreatorId != user.Id)
            {
                throw new Exception("no no no. can't do that");
            }
            _favRepo.UnHeart(id);
            return "You have unhearted this";
        }
    }
}