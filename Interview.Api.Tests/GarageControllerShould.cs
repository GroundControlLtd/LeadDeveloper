using System;
using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Xunit;

namespace Interview.Api.Tests
{
    public class GarageControllerShould
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("Unknown", "Unknown")]
        [InlineData("Nissan", "Primera")]
        [InlineData("Lotus", "Espirit")]
        public void ReturnExpectedDateWhenBookingMotGivenACar(string carMake, string carModel)
        {
            //Arrange
            var controller = new GarageController();
            var car = new Car { Make=carMake,Model=carModel };
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 15, 0).AddDays(3);

            if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            {
                date = date.AddDays(2);
            }
            var expectedValue = $"{car.Make} {car.Model} MOT booked for {date} ";

            //Act
            var response = controller.BookMot(car);
            var actualValue = ((ObjectResult)response).Value;
            //Assert
            Assert.NotNull(actualValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
