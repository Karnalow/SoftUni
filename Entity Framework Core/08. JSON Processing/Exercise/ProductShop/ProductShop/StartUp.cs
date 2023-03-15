using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            string usersJsonPath = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08. JSON Processing\Exercise\ProductShop\ProductShop\Datasets\users.json");

            string productsJsonPath = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08. JSON Processing\Exercise\ProductShop\ProductShop\Datasets\products.json");

            string categoriesJsonPath = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08. JSON Processing\Exercise\ProductShop\ProductShop\Datasets\categories.json");

            string categoryProducts = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08. JSON Processing\Exercise\ProductShop\ProductShop\Datasets\categories-products.json");

            string usersProducts = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\08. JSON Processing\Exercise\ProductShop\ProductShop\Datasets\users-and-products.json");

            Console.WriteLine("--P01");
            Console.WriteLine(ImportUsers(db, usersJsonPath));
            Console.WriteLine("--P02");
            Console.WriteLine(ImportProducts(db, productsJsonPath));
            Console.WriteLine("--P03");
            Console.WriteLine(ImportCategories(db, categoriesJsonPath));
            Console.WriteLine("--P04");
            Console.WriteLine(ImportCategoryProducts(db, categoryProducts));
            Console.WriteLine("--P05");
            Console.WriteLine(GetProductsInRange(db));
            Console.WriteLine("--P06");
            Console.WriteLine(GetSoldProducts(db));
            Console.WriteLine("--P07");
            Console.WriteLine(GetCategoriesByProductsCount(db));
            Console.WriteLine("--P08");
            Console.WriteLine(GetUsersWithProducts(db));
        }

        private static void InitliazeMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }

        //P01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitliazeMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //P02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitliazeMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //P03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitliazeMapper();

            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson);

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //P04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitliazeMapper();

            var dtoCategoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        //P05
        public static string GetProductsInRange(ProductShopContext context)
        { 
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.Price)
                .ToList();

            string result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        //P06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(pc => new
                        {
                            Name = pc.Name,
                            Price = pc.Price,
                            BuyerFirstName = pc.Buyer.FirstName,
                            BuyerLastName = pc.Buyer.LastName
                        }).ToList()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToList();

            string result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }

        //P07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    ProductsCount = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    TotalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                })
                .OrderByDescending(x => x.ProductsCount)
                .ToList();

            string result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result;
        }

        //P08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Product = x.ProductsSold.Select(p => new
                    {
                        ProductName = p.Name,
                        ProductPrice = p.Price
                    })
                })
                .ToList();

            var settings = new JsonSerializerSettings
                           {
                                Formatting = Formatting.Indented,
                                NullValueHandling = NullValueHandling.Ignore
                           };

            string result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }
    }
}