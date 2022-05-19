using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.Data
{
    public class ChairCard
    {
        private AppDBContent db;

        public Chair chair;
        public IEnumerable<Category> categories;

        public ChairCard()
        {
            chair = new Chair();
        }

        public ChairCard(AppDBContent appDB, int idChair)
        {
            db = appDB;
            chair = db.Chairs.FirstOrDefault(ch => ch.Id == idChair);
            categories = DBObjects.ListCategories(db);
        }

    }
}
