using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

            using (var db = new CarDealerContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputXml = File.ReadAllText("./../../../Datasets/sales.xml");
                var result = GetCarsWithDistance(db);

                Console.WriteLine(result);
            }
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<SupplierDto>),
                new XmlRootAttribute("Suppliers"));

            var suppliers = new List<Supplier>();

            var suppliersDto = (List<SupplierDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            var countChanges = context.SaveChanges();

            return $"Successfully imported {countChanges}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<PartDto>),
                new XmlRootAttribute("Parts"));

            var parts = new List<Part>();

            var partsDto = (List<PartDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            foreach (var partDto in partsDto)
            {
                var part = Mapper.Map<Part>(partDto);
                parts.Add(part);
            }

            context.AddRange(parts
                .Where(p => context.Suppliers.Find(p.SupplierId) != null));

            var countChanges = context.SaveChanges();

            return $"Successfully imported {countChanges}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<CarDto>),
                new XmlRootAttribute("Cars"));

            var cars = new List<Car>();

            var carsDto = (List<CarDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            foreach (var carDto in carsDto)
            {
                var car = Mapper.Map<Car>(carDto);
                context.Cars.Add(car);

                foreach (var part in carDto.Parts.PartsIdDto)
                {
                    if (context.Parts.Find(part.PartId) != null &&
                        car.PartCars.FirstOrDefault(pc => pc.PartId == part.PartId) == null)
                    {
                        var partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = part.PartId
                        };

                        car.PartCars.Add(partCar);
                        context.PartCars.Add(partCar);
                    }
                }

                cars.Add(car);
            }

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<CustomerDto>),
                new XmlRootAttribute("Customers"));

            var customersDto = (List<CustomerDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<SaleDto>),
                new XmlRootAttribute("Sales"));

            var salesDto = (List<SaleDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                var sale = Mapper.Map<Sale>(saleDto);

                if (context.Cars.FirstOrDefault(c => c.Id == saleDto.CarId) != null)
                {
                    sales.Add(sale);
                }
            }

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var xmlSerializer = new XmlSerializer(typeof(CarWithDistanceDto[]),
                new XmlRootAttribute("cars"));

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new CarWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty});
            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}