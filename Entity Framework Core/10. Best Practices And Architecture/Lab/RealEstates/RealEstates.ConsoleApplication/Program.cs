using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace RealEstates.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("3. Average price per square meter");
                Console.WriteLine("0. EXIT");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);

                if (parsed && option == 0)
                {
                    break;
                }

                if (parsed && (option >= 1 && option <= 3))
                {
                    switch (option)
                    {
                        case 1: 
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                        case 3:
                            AveragePricePerSquareMeter(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void AveragePricePerSquareMeter(ApplicationDbContext db)
        {
            IPropertiesService propertiesService = new PropertiesServices(db);
            Console.WriteLine($"Average price per square meter: {propertiesService.AveragePricePerSquareMeter():f2}€/m²");
        }

        private static void MostExpensiveDistricts(ApplicationDbContext db)
        {
            IDistrictsService districtsService = new DistrictsService(db);

            Console.Write("Districts count: ");
            int districtsCount = int.Parse(Console.ReadLine());

            var districts = districtsService.GetMostExpensiveDistricts(districtsCount);

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePricePerSquareMeter:f2}€/m²  ({district.PropertiesCount})");
            }
        }

        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.Write("Min price: ");
            int minPrice = int.Parse(Console.ReadLine());

            Console.Write("Max price: ");
            int maxPrice = int.Parse(Console.ReadLine());
            
            Console.Write("Min size: ");
            int minSize = int.Parse(Console.ReadLine());

            Console.Write("Max size: ");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesServices(db);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);
            
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictsName}; {property.BuildingType}; {property.PropertyType} => {property.Price}€ => {property.Size}m²");
            }
        }
    }
}