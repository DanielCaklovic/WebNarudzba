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
using AutoMapper;
using Repository.Interface;

using WebNarudzba.Controllers;

namespace WebNarudzbe.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IUnitOfWork> IUnitOfWork;
        private Mock<IGenericRepository<Dobavljac>> genericRepository;
        private Mock<DobavljacRepository> dobavljacRepository;

        private DobavljacController dobavljacController;

        [TestInitialize]
        public void Init() 
        {
                IUnitOfWork = new Mock<IUnitOfWork>();
                dobavljacRepository = new Mock<DobavljacRepository>();
                

        }

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
        public void TestControllerDobavljac()
        {
            //Arrange
            dobavljacController = new DobavljacController(IUnitOfWork.Object, dobavljacRepository.Object);
            Dobavljac dobavljac = new Dobavljac();
            dobavljac.ID = 1;
            dobavljac.Adresa = "test adress";
            dobavljac.Naziv = "test naziv";
            dobavljac.Telefon = "test broj";
            //TASK.FromResult == ReturnsAsync
            IUnitOfWork.Setup(x => x.Dobavljac.GetByIdAsync(dobavljac.ID)).ReturnsAsync(dobavljac);

            //Act
            var dobavljacDetailResult = dobavljacController.Details(dobavljac.ID);

            //Assert
            Assert.IsInstanceOfType(dobavljacDetailResult, typeof(Task<ActionResult>));
            Assert.AreEqual(1,dobavljacDetailResult.Id);
 


            
           
          

          
        }

        [TestMethod]
        public void TestInsertDobavljac()
        {
            //Arrange
            dobavljacController = new DobavljacController(IUnitOfWork.Object, dobavljacRepository.Object);
            Dobavljac dobavljac = new Dobavljac();
            dobavljac.ID = 100;
            dobavljac.Adresa = "test adress";
            dobavljac.Naziv = "test naziv";
            dobavljac.Telefon = "test broj";
            //TASK.FromResult == ReturnsAsync
            IUnitOfWork.Setup(x => x.Dobavljac.InsertAsync(dobavljac)).Returns(Task.FromResult(dobavljac));

            //Act
            var dobavljacCreateResult = dobavljacController.Create();

            //Assert
            Assert.IsInstanceOfType(dobavljacCreateResult, typeof(ActionResult));
           
          
            
      

        }



    }
}
