using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.Interfaces
{
    public interface IChairs
    {
        IEnumerable<Chair> Chairs();
        IEnumerable<Chair> GetFavouritesChairs();

        Chair GetChair(int chairId);
    }
}
