using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Library.WebApplication.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Library.Entities;
using Library.Repositories.Implementation;
using Library.Repositories.Interfaces;

namespace Library.WebApplication.Tests.Controllers
{
    [TestClass]
    public class AuthorsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            var authors = new List<Author>
            {
                new Author{Id = 1, Name = "Adam", Surname = "Mickiewicz"},
                new Author{Id = 2, Name = "Jan", Surname = "Brzechwa"}
            };
            var repository = new Mock<IRepository<Author>>();

            repository
                .Setup(e => e.GetAll())
                .Returns(authors.AsQueryable());

            AuthorsController controller = new AuthorsController(repository.Object);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void DetailsWithSpecifiedIdShouldReturnView()
        {
            //Arrange
            var authors = new List<Author>
            {
                new Author{Id = 1, Name = "Adam", Surname = "Mickiewicz"},
                new Author{Id = 2, Name = "Jan", Surname = "Brzechwa"}
            };
            var repository = new Mock<IRepository<Author>>();

            int id = authors[0].Id;

            repository
                .Setup(e => e.GetById(1))
                .Returns(authors.Find(x => x.Id == id));

            AuthorsController controller = new AuthorsController(repository.Object);

            //Act
            var result = controller.Details(id) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
