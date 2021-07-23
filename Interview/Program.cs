using Shared;
using System;
using System.Threading.Tasks;

namespace Interview
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var book = new Book {Author = "Aldous Huxley", Title = "Brave New World"};
            var car = new Car {Make = "VW", Model = "Golf"};

            // Refactor code to:
            //  - extract interfaces from service and repository class and use dependency injection and remove all concrete instantiations 
            //  - using an interface and an extension method remove code duplicated in GarageService and LibraryService
            //  - amend service calls below to run them in parallel 
            //  - Add some unit tests using Xunit 

            var garageService = new GarageService();
            var libraryService = new LibraryService();
            var bookMessage = await libraryService.BorrowBook(book);
            var carMessage = await garageService.BookMot(car);
            //await  garageService.
            Console.WriteLine($"{carMessage}");
            Console.WriteLine($"{bookMessage}");
            Console.ReadLine();
        }
    }
}
