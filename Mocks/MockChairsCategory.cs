using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Mocks
{
    public class MockChairsCategory : IChairsCategory
    {
        public IEnumerable<Category> AllCategories()
        {
            return new List<Category>
            {
                new Category{Name = "Компьютерный", Desc = "Стулья для компьютерных столов." },
                new Category{Name = "Кухонный", Desc = "Стулья для кухни." }
            };
        }
    }
}
