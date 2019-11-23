using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputXml = File.ReadAllText("./../../../Datasets/categories-products.xml");

                var result = GetSoldProducts(db);
                Console.WriteLine(result);

            }
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportUserDto>), new XmlRootAttribute("Users"));
            var usersDto = (List<ImportUserDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<User> users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportProductDto>),
                new XmlRootAttribute("Products"));

            var productsDto = (List<ImportProductDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportCategoryDto>),
                new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                var category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportCategoryProductDto>),
                new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto = ((List<ImportCategoryProductDto>)xmlSerializer.Deserialize(new StringReader(inputXml)));

            var categoryProducts = new List<CategoryProduct>();

            foreach (var cpDto in categoryProductsDto)
            {
                var existingCategory = context.Categories.Find(cpDto.CategoryId);
                var existingProduct = context.Products.Find(cpDto.ProductId);

                if (existingCategory != null && existingProduct != null)
                {
                    var categoryProduct = Mapper.Map<CategoryProduct>(cpDto);
                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProductDto[]),
                new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new UserSoldDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold = u.ProductsSold.Select(p => new ProductSoldDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToList();

            var xmlSerializer = new XmlSerializer(typeof(List<UserSoldDto>),
                new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}