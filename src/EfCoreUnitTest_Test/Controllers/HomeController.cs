using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;

namespace EfCoreUnitTest_Test.Controllers
{
    public class HomeController : Controller
    {
        readonly MyDbContext context;

        public HomeController(MyDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var item = context.FooBars.Select(f => f.Text).SingleOrDefault();
            var model = new Models.HomeModel
            {
                Foo = item,
            };
            return View(model: model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Save(Models.HomeModel model)
        {
            context.FooBars.RemoveRange(context.FooBars); // Remove any existing

            context.FooBars.Add(new FooBar { Text = model.Foo });
            context.SaveChanges();
            return Content("OK");
        }
    }
}
