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
    public class NUnit_Tests_Furniture_Service
    {
        [Test]
        public void FurnitureServisesInstanceShouldCreateCorrectly()
        {
            IApplicationContext context = Mock.Of<IApplicationContext>();
            var act = new FurnitureService(context);
            act.Should().NotBeNull();
        }

        [Test]
        public void FurnitureServisesInstanceShouldThrowExceptionWhenContextIsNull()
        {
            //Assert.Throws<ArgumentNullException>(() => new FurnitureService(null));
            FluentActions.Invoking(() => new FurnitureService(null)).Should().Throw<ArgumentNullException>();
        }
    }
}