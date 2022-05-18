using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.Interfaces
{
    public interface IChairsCategory
    {
        IEnumerable<Category> AllCategories();
    }
}
