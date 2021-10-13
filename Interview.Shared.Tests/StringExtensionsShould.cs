using System.Threading.Tasks;
using Shared;
using Xunit;

namespace Interview.Shared.Tests
{
    public class StringExtensionsShould
    {
        [Fact]
        public async Task ReturnExpectedHttpContentWhenGivenACar()
        {
            //Arrange
            var car = new Car {Make = "Porche", Model = "920"};
            var expectedValue = @"{""make"":""Porche"",""model"":""920""}";
            //Act
            var httpcontent = car.ToHttpContent();
            var actualValue = await httpcontent.ReadAsStringAsync();

            //Assert
            Assert.NotNull(httpcontent);
            
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public async Task ReturnExpectedHttpContentWhenGivenABook()
        {
            //Arrange
            var car = new Book { Title = "Foundation", Author = "Isaac Asimov" };
            var expectedValue = @"{""title"":""Foundation"",""author"":""Isaac Asimov""}";
            //Act
            var httpcontent = car.ToHttpContent();
            var actualValue = await httpcontent.ReadAsStringAsync();

            //Assert
            Assert.NotNull(httpcontent);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}