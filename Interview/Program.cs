using Interview.Configuration;
using Interview.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using System;
using System.Collections.Generic;
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
            //  - Add some unit tests use Xunit 

            //Services dependency injection
            var services = new ServiceCollection();
            services.AddTransient<IGarageService, GarageService>();
            services.AddTransient<ILibraryService, LibraryService>();
            services.AddTransient<IGarageServiceConfiguration, GarageServiceConfiguration>();
            services.AddTransient<ILibraryServiceConfiguration, LibraryServiceConfiguration>();
            var serviceProvider = services.BuildServiceProvider();

            //Garage service instantiation
            var garageService = serviceProvider.GetRequiredService<IGarageService>();

            //Library service instantiation
            var libraryService = serviceProvider.GetRequiredService<ILibraryService>();

            //Run both methods parallelly
            var bookMessageTask =   libraryService.BorrowBook(book);
            var carMessageTask =   garageService.BookMot(car);      
            await  Task.WhenAll(bookMessageTask, carMessageTask);

            Console.WriteLine($"{bookMessageTask.Result}");
            Console.WriteLine($"{carMessageTask.Result}");
            Console.ReadLine();
        }
    }
}
