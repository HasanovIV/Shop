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
    }
}
