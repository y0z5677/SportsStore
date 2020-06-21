using SportsStoreApp.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreApp.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        PagedList<Product> GetProducts(QueryOptions options, long category = 0);
        PagedList<Product> GetProducts(QueryOptions options);
        Product GetProduct(long key);
        void AddProduct(Product product);
        void UpdateProduct(Product product);

        void UpdateAll(Product[] products);
        void Delete(Product product);
    }
}
