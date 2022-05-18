using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Data.Repository
{
    public class ChairRepository : IChairs
    {

        private readonly AppDBContent dBContent;

        public ChairRepository(AppDBContent appDBContent)
        {
            dBContent = appDBContent;
        }

        public IEnumerable<Chair> Chairs()
        {
            return dBContent.Chairs.Include(c => c.Category);
        }

        public Chair GetChair(int chairId)
        {
            return dBContent.Chairs.FirstOrDefault(ch => ch.Id == chairId);
        }

        public IEnumerable<Chair> GetFavouritesChairs()
        {
            return dBContent.Chairs.Where(p => p.IsFavourite).Include(c => c.Category);
        }
    }
}
