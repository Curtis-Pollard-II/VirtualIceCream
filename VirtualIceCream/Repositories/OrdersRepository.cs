using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using VirtualIceCream.Models;

namespace VirtualIceCream.Repositories
{
    public class OrdersRepository
    {
        private readonly IDbConnection _db;

        public OrdersRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Order> GetOrders()
        {
            string sql = @"
            SELECT * FROM Orders;
            ";
            List<Order> orders =_db.Query<Order>(sql).ToList();
            return orders;
        }

        internal Order Create(Order newOrder)
        {
            string sql = @"
                INSERT INTO `Orders`
                (name, total, screenshot)
                VALUES
                (@name, @total, @screenshot);
                SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newOrder);
            newOrder.Id = id;
            return newOrder;
        }

        internal Order GetOne(int id)
        {
            string sql = @"
            SELECT 
                o.*,
                a.*
                FROM Orders o 
                JOIN accounts a On a.id = o.creatorId
                Where o.id = @id; 
            ";
            return _db.Query<Order, Profile, Order>(sql, (order, profile) => 
            {
                order.Creator = profile;
                return order;
            }, new { id }).FirstOrDefault();
        }
    }
}