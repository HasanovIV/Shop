using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        private AppDBContent db;
        public CategoryController(AppDBContent content)
        {
            db = content;
        }
        public IActionResult List()
        {
            var list = db.Categories.ToList();
            return View(list);
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var category = db.Categories.FirstOrDefault(cat => cat.Id == id);
                if (category != null)
                {
                    return View(category);
                }
            }
            return View( new Category());
        }

        [HttpPost]
        public IActionResult Edit (Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();

            return Redirect("List");
        }
    }
}
