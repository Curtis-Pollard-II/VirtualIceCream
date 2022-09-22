using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
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

        internal List<Ingredient> getIngredients()
        {
            string sql = @"
            SELECT
            i.*,
            a.*
            FROM Ingredients i
            JOIN accounts a ON a.id = i.creatorId;
            ";
            List<Ingredient> ingredients = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
            {
                ingredient.Creator = profile;
                return ingredient;
            }).ToList();
            return ingredients;
        }
    }
}