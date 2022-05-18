using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Data.Repository
{
    public class CategoryRepository : IChairsCategory
    {
        private readonly AppDBContent dBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            dBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories()
        {
            return dBContent.Categories;
        }
    }
}
