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
    public class NUnit_Tests_Products_Service
    {
        [Test]
        public void ProductsServiceInstanceShouldCreateCorrectly()
        {
            IApplicationContext context = Mock.Of<IApplicationContext>();
            var act = new ProductsService(context);
            act.Should().NotBeNull();
        }

        [Test]
        public void ProductsServiceInstanceShouldThrowExceptionWhenContextIsNull()
        {
            //Assert.Throws<ArgumentNullException>(() => new FurnitureService(null));
            FluentActions.Invoking(() => new ProductsService(null)).Should().Throw<ArgumentNullException>();
        }
    }
}