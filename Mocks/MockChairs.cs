using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Interfaces;
using Shop.Models;

namespace Shop.Mocks
{
    public class MockChairs : IChairs
    {
        readonly IChairsCategory _categoryChairs = new MockChairsCategory();
        public IEnumerable<Chair> Chairs()
        {
            Chair chair1 = new Chair
            {
                Name = "Супер гейм стул",
                Desc = "Компьютерный стул по последним технологиям",
                Img = "https://img.joomcdn.net/e9a1fdf4df8261c4429c57b06b907e56b87bab84_1024_1024.jpeg",
                IsFavourite = true,
                Price = 15000,
                Category = _categoryChairs.AllCategories().First()
            };

            Chair chair2 = new Chair
            {
                Name = "Удобный стул для кухни",
                Desc = "Очень удобный стул для обеденного стола.",
                Img = "https://img.joomcdn.net/acfe1bcc3b1404c3060b39519102b0c09ba630a0_original.jpeg",
                IsFavourite = false,
                Price = 2000,
                Category = _categoryChairs.AllCategories().Last()
            };

            List<Chair> chairsList = new List<Chair> { chair1, chair2 };

            return chairsList;
        }

        public Chair GetChair(int chairId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Chair> GetFavouritesChairs()
        {
            throw new NotImplementedException();
        }
    }
}
