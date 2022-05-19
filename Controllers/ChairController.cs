using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Interfaces;


namespace Shop.Controllers
{
    public class ChairController: Controller
    {
        private readonly IChairs _chairs;
        private readonly IChairsCategory _chairsCategory;

        public ChairController(IChairs chairs, IChairsCategory chairsCategory)
        {
            _chairs = chairs;
            _chairsCategory = chairsCategory;
        }

        public ViewResult List()
        {
            var chairs = _chairs.Chairs();
            return View(chairs);
        }

        public ViewResult AddChair()
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
    }
}
