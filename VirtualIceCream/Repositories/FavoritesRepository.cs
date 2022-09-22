using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using VirtualIceCream.Models;

namespace VirtualIceCream.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Hearts> GetHearts(int orderId)
        {
            string sql = @"
            SELECT 
                a.*,
                f.*
                FROM favorites f
                JOIN accounts a ON a.id = f.accountId
                WHERE f.orderId = @orderId;
            ";
            List<Hearts> hearts = _db.Query<Hearts, Favorite, Hearts>(sql, (hearts, f) =>
            {
                hearts.favoritesId = f.Id;
                return hearts;
            }, new { orderId }).ToList(); 
            return hearts;
        }

        internal Favorite Create(Favorite favorite)
        {
            string sql = @"
            INSERT INTO favorites
            (orderId, accountId)
            VALUES
            (@orderId, @accountId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, favorite);
            favorite.Id = id;
            return favorite;
        }

        internal Favorite GetOne(int id)
        {
            string sql = @"
            SELECT * FROM favorites WHERE id = @id
            ";
            return _db.Query<Favorite>(sql, new {id}).FirstOrDefault();
        }

        internal void UnHeart(int id)
        {
            string sql = @"
            DELETE FROM favorites WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
        }
    }
}