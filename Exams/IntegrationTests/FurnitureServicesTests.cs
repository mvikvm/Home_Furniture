using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyLib.DataContext;
using MyLib.Interfaces;
using MyLib.Models;
using MyLib.Services;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests.Integration;

[TestFixture]
public class FurnitureServicesTests
{
    private IApplicationContext context;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
        .Options;
        var dbContext = new ApplicationContext(options);
        dbContext.Database.EnsureCreated();
        context = dbContext;

        context.PieceOfFurnitures.AddRange
            (new PieceOfFurniture { Name = "Стул", Quantity = 4 },
             new PieceOfFurniture { Name = "Шкаф", Quantity = 1 },
             new PieceOfFurniture { Name = "Диван", Quantity = 2 }
            );
        context.SaveChanges();
    }

    [TearDown]
    public void Cleanup()
    {
        ((DbContext)context).Database.EnsureDeleted();
        context.Dispose();
    }

    [Test]
    public void GetAllFurnitureShouldReturnItems()
    {
        // Arrange
        var service = new FurnitureServices(context);

        // Act
        var result = service.GetAllFurniture();

        //Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result.FirstOrDefault(x => x.Name == "Стул" && x.Quantity == 4).Should().NotBeNull();
    }

    //[Test]
    //public void GetAllFurnitureShouldBeEmpty()
    //{
    //    // Arrange
    //    context = default;
   
    //    //Assert
    //    FluentActions.Invoking(() => new FurnitureServices(context)).Should().Throw<ArgumentNullException>();
    //}

    [Test]
    public void CreateShouldAddItem()
    {
        // Arrange
        var exp = new PieceOfFurniture { Name = "Письменный стол", Quantity = 1 };
        var service = new FurnitureServices(context);
        // Act
        var act = service.Create(exp);
        //Assert
        act.Should().NotBeNull();
        act.Name.Should().Be("Письменный стол");
        act.Quantity.Should().Be(1);
        act.Id.Should().BeGreaterThan(3);

        var existedItems = ((ApplicationContext)context).PieceOfFurnitures.ToList();
        existedItems.Should().NotBeNull();
        existedItems.Should().HaveCount(4);
        var existedItem = existedItems[3];

        existedItem.Name.Should().Be("Письменный стол");
        existedItem.Quantity.Should().Be(1);
        existedItem.Id.Should().Be(4);
    }


    [Test]
    public void CreateMustReturnExceptionWhenNameAlreadyExists()
    {
        // Arrange
        PieceOfFurniture exp = new PieceOfFurniture { Name = "Стул", Quantity = 1 };
        var service = new FurnitureServices(context);
       
        //Assert
        FluentActions.Invoking(() => service.Create(exp)).Should().Throw<Exception>();
    }

    [Test]
    public void DeleteShouldDeleteItemCorrectly()
    {
        //Arrange
        int id = 1;
        var service = new FurnitureServices(context);

        //Act
        service.Delete(id);
        //Assert
        var result = service.GetAllFurniture();
        result.Should().HaveCount(2);
        result.FirstOrDefault(x => x.Name == "Стул" && x.Quantity == 4).Should().BeNull();
    }


    [Test]
    public void DeleteShouldReturnExceptionWhenIdIsNotFound()
    {
        //Arrange
        int id = 5;
        var service = new FurnitureServices(context);

        //Assert
        FluentActions.Invoking(() => service.Delete(id)).Should().Throw<Exception>();
    }

    [Test]
    public void UpdateShouldChangeItemCorrectly()
    {
        //Arrange
        PieceOfFurniture exp = new PieceOfFurniture { Name = "Cтакан", Quantity = 5 };
        exp.Id = 1;
        var service = new FurnitureServices(context);

        //Act
        var result = service.Update(exp);
        //Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Cтакан");
        result.Quantity.Should().Be(5);
        result.Id.Should().Be(1);
        result.Name.Equals(exp.Name).Should().Be(true);
        result.Quantity.Equals(exp.Quantity).Should().Be(true);
        result.Id.Equals(exp.Id).Should().Be(true);
    }

    [Test]
    public void UpdateShouldChangeItemCorrectlyWhehNameIsNullOrEmpty()
    {
        //Arrange
        PieceOfFurniture exp = new PieceOfFurniture { Name = "", Quantity = 5 };
        exp.Id = 1;
        var service = new FurnitureServices(context);

        //Act
        var result = service.Update(exp);
        //Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Стул");
        result.Quantity.Should().Be(5);
        result.Id.Should().Be(1);
        result.Quantity.Equals(exp.Quantity).Should().Be(true);
        result.Id.Equals(exp.Id).Should().Be(true);
    }

    [Test]
    public void UpdateShouldReturnExceptionWhenIdIsNotFound()
    {
        //Arrange
        PieceOfFurniture exp = new PieceOfFurniture { Name = "Cтакан", Quantity = 5 };
        exp.Id = 5;
        var service = new FurnitureServices(context);

        //Assert
        FluentActions.Invoking(() => service.Update(exp)).Should().Throw<Exception>();
    }
}