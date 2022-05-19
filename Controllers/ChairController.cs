using Microsoft.AspNetCore.Mvc;
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
            if (id != null)
            {
                ChairCard chairCard = new ChairCard(db, (int)id);
                
                if (chairCard.chair != null)
                    return View(chairCard);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(ChairCard chairCard)
        {
            
            //chairCard.chair.CategoryId = chairCard.chair.Category.Id;
            //db.Chairs.Update(chairCard.chair);
            //db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
