using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreApp.Models
{
    public class OrdersRepository : IOrdersRepository
    {
        private DataContext context;
        public OrdersRepository(DataContext ctx) => context = ctx;
        public IEnumerable<Order> Order
            => context.Order.Include(o => o.Lines).ThenInclude(l => l.Product);


        public void AddOrder(Order order)
        {
            context.Order.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            context.Order.Remove(order);
            context.SaveChanges();
        }

        public Order GetOrder(long key)
            => context.Order.Include(o => o.Lines).First(o => o.Id == key);
       
        public void UpdateOrder(Order order)
        {
            context.Order.Update(order);
            context.SaveChanges();
        }
    }
}
