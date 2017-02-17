using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using EfCoreUnitTest_Test.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using EfCoreUnitTest_Test.Models;

namespace UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "MyTestMethod")
                .Options;

            // Run the test against one instance of the context
            using (var context = new MyDbContext(options))
            {
                var myController = new HomeController(context);
                var indexResult = myController.Index();
                var viewResult = indexResult.Should().BeOfType<ViewResult>();
                var model = viewResult.Subject.Model.Should().BeOfType<HomeModel>();
                model.Subject.Foo.Should().BeNull();

            }
        }

        [TestMethod]
        public void SaveAndReload()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                  .UseInMemoryDatabase(databaseName: "SaveAndReload")
                  .Options;

            // Run the test against one instance of the context
            using (var context = new MyDbContext(options))
            {
                var myController = new HomeController(context);
                myController.Save(new EfCoreUnitTest_Test.Models.HomeModel
                {
                    Foo = "Hello"
                });
            }

            using (var context = new MyDbContext(options))
            {
                var myController = new HomeController(context);
                var indexResult = myController.Index();
                var viewResult = indexResult.Should().BeOfType<ViewResult>();
                var model = viewResult.Subject.Model.Should().BeOfType<HomeModel>();
                model.Subject.Foo.Should().Be("Hello");
            }
        }
    }
}
