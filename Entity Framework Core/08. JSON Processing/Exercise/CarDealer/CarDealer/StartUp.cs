using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();


            //Imports
            //string suppliesJson = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08.JSON Processing\Exercise\CarDealer\CarDealer\Datasets\suppliers.json");

            //string partsJson = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08.JSON Processing\Exercise\CarDealer\CarDealer\Datasets\parts.json");

            //string carsJson = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08. JSO Processing\Exercise\CarDealer\CarDealer\Datasets\cars.json");

            //string customersJson = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08 JSON Processing\Exercise\CarDealer\CarDealer\Datasets\customers.json");

            //string salesJson = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08. JSON Processing\Exercise\CarDealer\CarDealer\Datasets\sales.json");

            //Console.WriteLine("--P01--");
            //ImportSuppliers(db, suppliesJson);
            //Console.WriteLine("--P02--");
            //ImportParts(db, partsJson);
            //Console.WriteLine("--P03--");
            //ImportCars(db, carsJson);
            //Console.WriteLine("--P04--");
            //ImportCustomers(db, customersJson);
            //Console.WriteLine("--P05--");
            //ImportSales(db, salesJson);

            //Exports
            //Console.WriteLine("--P06--");
            //Console.WriteLine(GetOrderedCustomers(db));
            //Console.WriteLine("--P07--");
            //Console.WriteLine(GetCarsFromMakeToyota(db));
            //Console.WriteLine("--P08--");
            //Console.WriteLine(GetLocalSuppliers(db));
            //Console.WriteLine("--P09--");
            //Console.WriteLine(GetCarsWithTheirListOfParts(db));
            //Console.WriteLine("--P10--");
            //Console.WriteLine(GetTotalSalesByCustomer(db));
            //Console.WriteLine("--P11--");
            //Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        private static void InitliazeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

        //P01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var supplierDTOs = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(supplierDTOs);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        //P02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var partsDTOs = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson)
                .Where(x => context.Suppliers.Any(y => y.Id == x.SupplierId));

            var parts = mapper.Map<IEnumerable<Part>>(partsDTOs);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //P03
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var carsDTOs = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            var cars = mapper.Map<IEnumerable<Car>>(carsDTOs);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        //P04
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var customersDTOs = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDTOs);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        //P05
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitliazeMapper();

            var salesDTO = JsonConvert.DeserializeObject<IEnumerable<SaleInputModel>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(salesDTO);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        //P06
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    x.IsYoungDriver
                })
                .ToList();

            string result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }

        //P07
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        //P08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            string result = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return result;
        }

        //P09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarPartsDto
                {
                    Car = new ExportCarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    Parts = c.PartCars
                            .Select(p => new ExportPartDto
                            {
                                Name = p.Part.Name,
                                Price = $"{p.Part.Price:f2}"
                            }).ToList()
                }).ToList();

            string result = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return result;
        }

        //P10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any(s => s.Car != null))
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(x => x.Car != null),
                    SpentMoney = c.Sales
                                .SelectMany(s => s.Car.PartCars)
                                .Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            var setting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            string result = JsonConvert.SerializeObject(customers, setting);

            return result;
        }

        //P11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new ExportSaleDiscountDto
                {
                    Car = new ExportCarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    CustomerName = x.Customer.Name,
                    Discount = $"{x.Discount:f2}",
                    Price = $"{x.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    PriceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price)
                    - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100).ToString("F2")

                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}