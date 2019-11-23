using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

                var inputXml = File.ReadAllText("./../../../Datasets/categories.xml");

                var result = ImportCategories(db, inputXml);
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

            var categoriesDto = (List<ImportCategoryDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

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
    }
}