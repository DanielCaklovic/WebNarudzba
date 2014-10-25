using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebNarudzbe;
using WebNarudzbe.Controllers;
using Moq;
using Repository.Repository;
using Repository;
using DAL;
using DAL.Model;
using System.Threading.Tasks;

namespace WebNarudzbe.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IUnitOfWork> IUnitOfWork = new Mock<IUnitOfWork>();

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDobavljac()
        {
            Dobavljac dobavljac = new Dobavljac();

            dobavljac.ID = 1;
            dobavljac.Adresa = "test adress";
            dobavljac.Naziv = "test naziv";
            dobavljac.Telefon = "test broj";


            //TASK.FromResult == ReturnsAsync
            var test1 = IUnitOfWork.Setup(x => x.Dobavljac.GetByIdAsync(1)).Returns(Task.FromResult(dobavljac));
            var test2 = IUnitOfWork.Setup(x => x.Dobavljac.GetByIdAsync(10)).ReturnsAsync(dobavljac);
        //    Assert.IsNull(test2);
            Assert.IsNotNull(test1);

        }

        [TestMethod]
        public void TestProizvod()
        {
            Proizvod proizvod = new Proizvod();

            proizvod.ID = 100;
            proizvod.Naziv = "testproizvod";

            IUnitOfWork.Setup(x => x.Proizvod.GetByIdAsync(1)).Returns(Task.FromResult(proizvod));


        }

    }
}
