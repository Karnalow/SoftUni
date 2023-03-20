using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

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

            string importUserInput = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\09. XML Processing\ProductShop\ProductShop\Datasets\users.xml");

            string importProductsInput = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\09. XML Processing\ProductShop\ProductShop\Datasets\products.xml");

            string importCategoriesInput = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\09. XML Processing\ProductShop\ProductShop\Datasets\categories.xml");

            string importCategoryProductsInput = File.ReadAllText(@"D:\Repositories\SoftUni\Entity Framework Core\09. XML Processing\ProductShop\ProductShop\Datasets\categories-products.xml");

            //Import
            Console.WriteLine(ImportUsers(db, importUserInput));
            Console.WriteLine(ImportProducts(db, importProductsInput));
            Console.WriteLine(ImportCategories(db, importCategoriesInput));
            Console.WriteLine(ImportCategoryProducts(db, importCategoryProductsInput));

            //Export
            Console.WriteLine(GetProductsInRange(db));
            Console.WriteLine(GetSoldProducts(db));
            Console.WriteLine(GetCategoriesByProductsCount(db));
            Console.WriteLine(GetUsersWithProducts(db));
        }

        private static void InitiazeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }

        //P01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitiazeMapper();

            const string rootElement = "Users";

            var userDTOs = XMLConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            var users = mapper.Map<IEnumerable<User>>(userDTOs);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //P02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitiazeMapper();

            const string rootElement = "Products";

            var productDTOs = XMLConverter.Deserializer<ImportProductDto>(inputXml, rootElement);

            var products = mapper.Map<IEnumerable<Product>>(productDTOs);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //P03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitiazeMapper();

            const string rootElement = "Categories";

            var categoryDTOs = XMLConverter.Deserializer<ImportCategoryDto>(inputXml, rootElement)
                .Where(x => x.Name != null);

            var categories = mapper.Map<IEnumerable<Category>>(categoryDTOs);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //P04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitiazeMapper();

            const string rootElement = "CategoryProduct";

            var categoryProductDTOs = XMLConverter.Deserializer<ImportCategoryProductDto>(inputXml, rootElement)
                .Where(x => context.Categories.Any(c => c.Id == x.CategoryId)
                && context.Products.Any(p => p.Id == x.ProductId));

            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProductDTOs);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        //P05
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            var xml = XMLConverter.Serialize(products, rootElement);

            return xml;
        }

        //P06
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new ExportUserSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(p => p.BuyerId != null)
                    .Select(p => new ExportSoldProductsDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var xml = XMLConverter.Serialize(users, rootElement);

            return xml;
        }

        //P07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categories = context.Categories
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var xml = XMLConverter.Serialize(categories, rootElement);

            return xml;
        }

        //P08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToArray()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new ExportUserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new ExportProductCountDto
                    {
                        Count = x.ProductsSold.Count(),
                        Products = x.ProductsSold.Select(p => new ExportProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToArray();

            var resultObj = new ExportUserCountDto
            {
                Count = users.Length,
                Users = users.Take(10).ToArray()
            };

            var xml = XMLConverter.Serialize(resultObj, rootElement);

            return xml;
        }
    }
}