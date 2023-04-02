using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyLib.DataContext;
using MyLib.Interfaces;
using MyLib.Models;
using MyLib.Services;
using NUnit.Framework;
using Moq;

namespace Test_NUnit_Project
{
    [TestFixture]
    public class NUnit_Tests_Furniture_Services
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //    //Arrange
            //    var mock = new Mock<IApplicationContext>();
            //    mock.Setup()
            //    //Act
            //    //Assert

            //    var db = Mock.Of<IApplicationContext>();
            //    mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>());
            //    var furniture = Mock.Of<IFurnitureServices>(u => u.GetAllFurniture = list);
            //    var uowFactory = Mock.Of<IUnitOfWorkFactory>(f => f.Create() == uow);

            //    var service = new SomeService() { UoWFactory = uowFactory };

            //    var result = service.GetAllEntitiesList();

            //    CollectionAssert.AreEqual(list, result);
            //}

            //private List<PieceOfFurniture> list = new List<PieceOfFurniture> 
            //    { 
            //        new PieceOfFurniture() { Name = "Стол", Quantity = 1 },
            //        new PieceOfFurniture() { Name = "Стул", Quantity = 4 },
            //        new PieceOfFurniture() { Name = "Шкаф", Quantity = 2 },
            //        new PieceOfFurniture() { Name = "Диван", Quantity = 1 }
            //    };

            //    // Arrange
            //    var mock = new ApplicationContext();
            //    mock.Setup(a => a.PieceOfFurnitures.GetAllFurniture().Returns(list));
            //    IFurnitureServices controller = new FurnitureServices(mock);

            //    // Act
            //    var result = controller.GetAllFurniture()//as IEnumerable<PieceOfFurniture>;

            //    // Assert
            //    result.Should().NotBeNull();
            //    result.Should().HaveCount(1);
            //}

            //private List<PieceOfFurniture> list = new List<PieceOfFurniture>
            //        {
            //            new PieceOfFurniture() { Name = "Стол", Quantity = 1 },
            //            new PieceOfFurniture() { Name = "Стул", Quantity = 4 },
            //            new PieceOfFurniture() { Name = "Шкаф", Quantity = 2 },
            //            new PieceOfFurniture() { Name = "Диван", Quantity = 1 }
            //        };
        }
    }
}