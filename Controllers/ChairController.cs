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
            //using (UsersCintext db = new UsersCintext())
            //{
            //    //User user1 = new User() { Name = "Koctya", FirstName = "Novikov", Gmail = "ivan@gmail.ru" };
            //    Employee employee1 = new Employee() { Name = "Koctya", FirstName = "Nikiforof", NameOrganisation = "AOA", NumberEmp = 8 };

            //    Employee employee2 = new Employee() { Name = "Koctya", FirstName = "Korolev", NumberEmp = 8 };
            //    Employee employee3 = new Employee() { Name = "Maxim", FirstName = "Koctrikov", Gmail = "max@gmail.ru", NumberEmp = 4 };

            //    db.AddRange(employee1, employee2, employee3);

            //    db.SaveChanges();

            //}
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Chair chair = db.Chairs.FirstOrDefault(ch => ch.Id == id);
                if (chair != null)
                    return View(chair);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Chair chair)
        {
            db.Chairs.Update(chair);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
