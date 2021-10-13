using Data;
using Shared;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Interview
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ILibraryService, LibraryService>()
                .AddScoped<IGarageService, GarageService>()
                .BuildServiceProvider(); ;

            var libraryService = serviceProvider.GetService<ILibraryService>();
            var garageService = serviceProvider.GetService<IGarageService>();

            Console.WriteLine("Hello World!");

            var book = new Book {Author = "Aldous Huxley", Title = "Brave New World"};
            var car = new Car {Make = "VW", Model = "Golf"};

            // Refactor code to:
            //  - extract interfaces from service and repository class and use dependency injection and remove all concrete instantiations 
            //  - using an interface and an extension method remove code duplicated in GarageService and LibraryService
            //  - amend service calls below to run them in parallel 
            //  - Add some unit tests use Xunit 

            var bookMessage =  libraryService.BorrowBook(book);
            var carMessage =  garageService.BookMot(car);
            await Task.WhenAll(bookMessage, carMessage);

            //await  garageService.
            Console.WriteLine($"{carMessage}");
            Console.WriteLine($"{bookMessage}");
            Console.ReadLine();
        }
    }
}
