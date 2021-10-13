using Moq;
using System;
using Xunit;
using Interview.Interfaces;
using Shared;
using FluentAssertions;
using System.Threading.Tasks;

namespace Interview.Tests
{
    public class TestGarageService
    {
        [Fact]
        public void TestBookMot_successfully()
        {
            //Arrange
            var mockGarageServiceConfiguration = new Mock<IGarageServiceConfiguration>();
            mockGarageServiceConfiguration.SetupGet(x => x.BaseUrl).Returns("https://localhost:44321");
            mockGarageServiceConfiguration.SetupGet(x => x.ServiceEndpoint).Returns("/api/garage/bookmot");
            var garageService = new GarageService(mockGarageServiceConfiguration.Object);
            var car = new Car
            {
                Make = "Audi",
                Model = "2021"
            };

            //Act
            var actualResult = garageService.BookMot(car).Result;

            //Assert
            Assert.Contains(car.Make,actualResult);
            Assert.Contains(car.Model, actualResult);
        }
        [Fact]
        public void TestBookMot_failure()
        {
            //Arrange
            var mockGarageServiceConfiguration = new Mock<IGarageServiceConfiguration>();
            mockGarageServiceConfiguration.SetupGet(x => x.BaseUrl).Returns("https://localhost:44323");
            mockGarageServiceConfiguration.SetupGet(x => x.ServiceEndpoint).Returns("/api/garage/bookmot");
            var garageService = new GarageService(mockGarageServiceConfiguration.Object);
            var car = new Car
            {
                Make = "Audi",
                Model = "2021"
            };

            //Act
            //Assert
            Func<Task> f = async () => { await garageService.BookMot(car); };
            f.Should().ThrowAsync<Exception>();
        }
        [Fact]
        public void TestBookMot_failure_should_throw_exception()
        {
            //Arrange
            var mockGarageServiceConfiguration = new Mock<IGarageServiceConfiguration>();
            mockGarageServiceConfiguration.SetupGet(x => x.BaseUrl).Returns("https://localhost:44321");
            mockGarageServiceConfiguration.SetupGet(x => x.ServiceEndpoint).Returns("/api/garage/bookmot");
            var garageService = new GarageService(mockGarageServiceConfiguration.Object);

            //Act
            //Assert
            Func<Task> f = async () => { await garageService.BookMot(null); };
            f.Should().ThrowAsync<Exception>();
        }
    }
}
