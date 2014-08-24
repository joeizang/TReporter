using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;
using TripodReporter.Domain.Entities;
using TripodReporter.Domain.Repositories;
using TripodReporter.Web.Controllers;

namespace TripodReporter.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_List_Insurers()
        {
            //Arrange
            Mock<IRepository<Insurer>> mock = new Mock<IRepository<Insurer>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Insurer>{
                new Insurer { Name="FakeInsurer1"},
                new Insurer { Name="FakeInsurer2"},
                new Insurer { Name="FakeInsurer3"},
                new Insurer { Name="FakeInsurer4"},
                new Insurer { Name="FakeInsurer5"}
            }.AsQueryable());

            mock.Setup(n => n.GetById(It.Is<int>(o => o == 1 || o == 2 || o == 3 || o == 4 || o == 5))
                                        ).Returns<int>(p => new Insurer { InsurerId = p, Name = string.Format("Fake Moqs", p) });
            InsurersController insure = new InsurersController(mock.Object);
            
        }
    }
}
