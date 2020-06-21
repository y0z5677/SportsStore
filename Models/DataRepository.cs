using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using SportsStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsStoreApp.Models.Pages;

namespace SportsStoreApp.Models
{
    public class DataRepository : IRepository 
    {
        //private List<Product> data = new List<Product>();
        private DataContext context;

        public DataRepository(DataContext ctx) => context = ctx;
        public IEnumerable<Product> Products => context.Product
            .Include(p=>p.Category).ToArray();

        public PagedList<Product> GetProducts(QueryOptions options,
                long category = 0)
        {
            IQueryable<Product> query = context.Product.Include(p => p.Category);
            if (category != -0)
            {
                query = query.Where(p => p.CategoryId == category);
            }
            return new PagedList<Product>(query, options);
        }

        public PagedList<Product> GetProducts (QueryOptions options)
        {
            return new PagedList<Product>(context.Product.
                Include(prop => prop.Category), options);
        }
        public Product GetProduct(long key) => context.Product
            .Include(p=>p.Category).First(p=>p.Id == key);

        public void AddProduct(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product p = GetProduct(product.Id);
            p.Name = product.Name;
            p.Category = product.Category;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;
            //context.Product.Update(product);
            context.SaveChanges();
        }

        public void UpdateAll(Product[] products)
        {
            //context.Product.UpdateRange(products);

            Dictionary<long, Product> data = products.ToDictionary(p => p.Id);
            IEnumerable<Product> baseline =
                context.Product.Where(p => data.Keys.Contains(p.Id));

            foreach (Product databaseProduct in baseline )
            {
                Product requestProduct = data[databaseProduct.Id];
                databaseProduct.Name = requestProduct.Name;
                databaseProduct.Category = requestProduct.Category;
                databaseProduct.PurchasePrice = requestProduct.PurchasePrice;
                databaseProduct.RetailPrice = requestProduct.RetailPrice;
            }
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Product.Remove(product);
            context.SaveChanges();
        }
    }
}
