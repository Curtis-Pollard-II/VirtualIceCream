using System.Collections.Generic;
using VirtualIceCream.Models;
using VirtualIceCream.Repositories;

namespace VirtualIceCream.Services
{
    public class IngredientsService
    {
        public readonly IngredientsRepository _ingredRepo;
        public IngredientsService(IngredientsRepository ingredRepo)
        {
            _ingredRepo = ingredRepo;
        }
        internal List<Ingredient> getIngredients()
        {
         return _ingredRepo.getIngredients();
        }
    }
}