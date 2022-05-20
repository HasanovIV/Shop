using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Models;

namespace Shop.Data
{
    public class ChairCard
    {
        private AppDBContent db;

        public Chair chair;
        public IEnumerable<Category> categories;
        public string[] nameCategories;

        public List<SelectListItem> mySelectItems;

        public ChairCard()
        {
            chair = new Chair();
        }

        public ChairCard(AppDBContent appDB, int idChair)
        {
            db = appDB;
            chair = db.Chairs.FirstOrDefault(ch => ch.Id == idChair);
            categories = DBObjects.ListCategories(db);

            nameCategories = new string[categories.Count()];
            mySelectItems = new List<SelectListItem>();

            int index = 0;
            foreach (var item in categories)
            {
                nameCategories[index] = item.Name;
                mySelectItems.Add(new SelectListItem { Text = item.Name, Value = index.ToString() });
                index++;
            }


        }

    }
}
