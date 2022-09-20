using System.Collections.Generic;
using System.Data;
using VirtualIceCream.Models;

namespace VirtualIceCream.Repositories
{
    public class IngredientsRepository
    {
     private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Ingredient> getIngredientsByOrder()
        {
            
        }
    }
}