using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Interfaces;
using Shop.Models;
using Shop.Data;


namespace Shop.Controllers
{
    public class ChairController: Controller
    {
        private readonly IChairs _chairs;
        private readonly IChairsCategory _chairsCategory;
        private AppDBContent db;

        public ChairController(IChairs chairs, IChairsCategory chairsCategory, AppDBContent context)
        {
            _chairs = chairs;
            _chairsCategory = chairsCategory;
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var chairs = _chairs.Chairs();
            return View(chairs);
        }

        public IActionResult AddChair()
        {
            return View();
        }

        public void SaveChair()
        {

        }

        public IActionResult Edit(int? id)
        {
            var categories = DBObjects.ListCategories(db);
            List<SelectListItem> mySelectItems = new List<SelectListItem>();

            if (id != null)
            {
                //ChairCard chairCard = new ChairCard(db, (int)id);

                //ViewBag.nameCategories = chairCard.nameCategories;

                //if (chairCard.chair != null)
                //    return View(chairCard);

                Chair chairCard = db.Chairs.FirstOrDefault(ch => ch.Id == id);

                foreach (var item in categories)
                {
                    //if (chairCard.Category.Name != item.Name)
                        mySelectItems.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

                }

                ViewBag.mySelectItems = mySelectItems;

                if (chairCard != null)
                    return View(chairCard);

            }

            foreach (var item in categories)
                mySelectItems.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

            ViewBag.mySelectItems = mySelectItems;
            var defaultCategories = db.Categories.FirstOrDefault();

            return View(new Chair() { Category = defaultCategories, CategoryId = defaultCategories.Id }); ;
        }

        [HttpPost]
        public IActionResult Edit(Chair chairCard, int chooseCategoryID)
        {

            chairCard.Category = db.Categories.FirstOrDefault(cat => cat.Id == chooseCategoryID);
            db.Chairs.Update(chairCard);
            db.SaveChanges();

            return RedirectToAction("List");
        }

    }
}
