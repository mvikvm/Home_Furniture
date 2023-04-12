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
public class ProductsServiceTests
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
    }

    [TearDown]
    public void Cleanup()
    {
        ((DbContext)context).Database.EnsureDeleted();
        context.Dispose();
    }

    [Test]
    public void GetAllShouldReturnItems()
    {
        // Arrange
        var item = new PieceOfFurniture { Name = "Стул", Quantity = 4 };
        context.Set<PieceOfFurniture>().Add(item);
        context.SaveChanges();
        var service = new ProductsService(context);

        // Act
        var result = service.GetAll<PieceOfFurniture>();

        //Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.FirstOrDefault(x => x.Name == "Стул" && x.Quantity == 4).Should().NotBeNull();
    }

    [Test]
    public void CreateShouldAddItem()
    {
        // Arrange
        var exp = new PieceOfFurniture { Name = "Письменный стол", Quantity = 1 };
        var service = new ProductsService(context);
        // Act
        var act = service.Create(exp);
        //Assert
        act.Should().NotBeNull();
        act.Name.Should().Be("Письменный стол");
        act.Quantity.Should().Be(1);
        act.Id.Should().BeGreaterThan(0);

        var existedItems = ((ApplicationContext)context).Set<PieceOfFurniture>().ToList();
        existedItems.Should().NotBeNull();
        existedItems.Should().HaveCount(1);
        var existedItem = existedItems[0];

        existedItem.Name.Should().Be("Письменный стол");
        existedItem.Quantity.Should().Be(1);
        existedItem.Id.Should().Be(1);
    }


    //[Test]
    //public void CreateShouldThrowExceptionWhenSpecifiedNameAlreadyExists()
    //{
    //    // Arrange
    //    var item = new PieceOfFurniture { Name = "Стул", Quantity = 4 };
    //    context.Set<PieceOfFurniture>().Add(item);
    //    context.SaveChanges();
    //    PieceOfFurniture exp = new PieceOfFurniture { Name = "Стул", Quantity = 1 };
    //    var service = new ProductsService(context);
       
    //    //Assert
    //    FluentActions.Invoking(() => service.Create(exp)).Should().Throw<Exception>();
    //}

    [Test]
    public void DeleteShouldDeleteItemWhenSpecifiedIdIsFound()
    {
        //Arrange
        var item = new PieceOfFurniture() { Name = "Test", Quantity = 1 };
        context.Set<PieceOfFurniture>().Add(item);
        context.SaveChanges();
        var service = new ProductsService(context);

        //Act
        service.Delete<PieceOfFurniture>(item.Id);
        //Assert
        var act = context.Set<PieceOfFurniture>().ToList();
        act.Should().HaveCount(0);
    }


    [Test]
    public void DeleteShouldThrowExceptionWhenIdIsNotFound()
    {
        //Arrange
        var service = new ProductsService(context);

        //Assert
        FluentActions.Invoking(() => service.Delete<PieceOfFurniture>(1)).Should().Throw<Exception>();
    }

    //[Test]
    //public void UpdateShouldChangeItemWhenSpecifiedNameAndQuantityIsCorrectly()
    //{
    //    //Arrange
    //    var item = new PieceOfFurniture() { Name = "Cтакан", Quantity = 1 };
    //    context.Set<PieceOfFurniture>().Add(item);
    //    context.SaveChanges();
    //    PieceOfFurniture exp = new PieceOfFurniture { Name = "Cтакан", Quantity = 5, Id = item.Id };
    //    var service = new ProductsService(context);

    //    //Act
    //    var act = service.Update(exp);
    //    //Assert
    //    act.Should().NotBeNull();
    //    act.Name.Should().Be("Cтакан");
    //    act.Quantity.Should().Be(5);
    //    act.Id.Should().Be(1);
    //    act.Name.Equals(exp.Name).Should().Be(true);
    //    act.Quantity.Equals(exp.Quantity).Should().Be(true);
    //    act.Id.Equals(exp.Id).Should().Be(true);
    //}

    //[Test]
    //public void UpdateShouldChangeOnlyQuantityWhehSpecifiedNameIsNullOrEmpty()
    //{
    //    //Arrange
    //    var item = new PieceOfFurniture { Name = "Стул", Quantity = 5 };
    //    context.Set<PieceOfFurniture>().Add(item);
    //    context.SaveChanges();
    //    PieceOfFurniture exp = new PieceOfFurniture { Name = "", Quantity = 5, Id = item.Id };
    //    var service = new ProductsService(context);

    //    //Act
    //    var act = service.Update(exp);
    //    //Assert
    //    act.Should().NotBeNull();
    //    act.Name.Should().Be("Стул");
    //    act.Quantity.Should().Be(5);
    //    act.Id.Should().Be(1);
    //    act.Quantity.Equals(exp.Quantity).Should().Be(true);
    //    act.Id.Equals(exp.Id).Should().Be(true);
    //}

    [Test]
    public void UpdateShouldThrowExceptionWhenItemWhithSpecifiedIdIsNotFound()
    {
        //Arrange
        var item = new PieceOfFurniture { Name = "Стул", Quantity = 5 };
        context.Set<PieceOfFurniture>().Add(item);
        context.SaveChanges();
        PieceOfFurniture exp = new PieceOfFurniture { Name = "Полка", Quantity = 3, Id = 5 };
        var service = new ProductsService(context);

        //Assert
        FluentActions.Invoking(() => service.Update(exp)).Should().Throw<Exception>();
    }
}