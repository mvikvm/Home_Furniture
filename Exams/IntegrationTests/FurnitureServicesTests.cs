using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyLib.DataContext;
using MyLib.Interfaces;
using MyLib.Models;
using MyLib.Services;
using NUnit.Framework;

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
        var exp = new PieceOfFurniture { Name = "Test", Quantity = 1 };
        context.PieceOfFurnitures.Add(exp);
        context.SaveChanges();

        var service = new FurnitureServices(context);
        var act = service.GetAllFurniture();
        act.Should().NotBeNull();
        act.Should().HaveCount(1);
        act.FirstOrDefault(x => x.Name == "Test" && x.Quantity == 1).Should().NotBeNull();
    }

    [Test]
    public void AddShouldAddItem()
    {
        var exp = new PieceOfFurniture { Name = "Test", Quantity = 1 };

        var service = new FurnitureServices(context);
        var act = service.Create(exp);
        act.Should().NotBeNull();
        act.Name.Should().Be("Test");
        act.Quantity.Should().Be(1);
        act.Id.Should().BeGreaterThan(0);
        var existedItems = ((ApplicationContext)context).PieceOfFurnitures.ToList();
        existedItems.Should().NotBeNull();
        existedItems.Should().HaveCount(1);
        var existedItem = existedItems[0];

        existedItem.Name.Should().Be("Test");
        existedItem.Quantity.Should().Be(1);
        existedItem.Id.Should().Be(1);
    }
}