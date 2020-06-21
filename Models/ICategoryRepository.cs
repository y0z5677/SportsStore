using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStoreApp.Models.Pages;

namespace SportsStoreApp.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Category { get; }
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);

        PagedList<Category> GetCategories(QueryOptions options);

    }

    public class CategoryRepository : ICategoryRepository
    {
        private DataContext context;

        public CategoryRepository(DataContext ctx) => context = ctx;
        public IEnumerable<Category> Category => context.Category;

        public PagedList<Category> GetCategories(QueryOptions options)
        {
            return new PagedList<Category>(context.Category, options);
        }
        public void AddCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            context.Category.Remove(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            context.Category.Update(category);
            context.SaveChanges();
        }
    }
}
