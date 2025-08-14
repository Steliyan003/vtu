

using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Context;
using FileReaders;
using Tables.Models;
namespace CarsSpecification    
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Car> cars=new Dictionary<string, Car>();
            CarSpecificationDbContext dbContext = new CarSpecificationDbContext();
            StreamReader reader = new StreamReader($"C:\\Users\\rumen\\source\\repos\\CarsSpecification\\cars specifications.csv");
            CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ","
            });

            CsvMapper manager = new CsvMapper();
            using (dbContext)
            {
                dbContext.Database.EnsureCreated();
                using (reader)
                {
                    using (csv)
                    {

                        csv.Context.RegisterClassMap<CarSpecificationMap>();
                        var records = csv.GetRecords<CsvMapper>().ToList();
                        foreach (var item in records)
                        {
                            Car? car = null;
                            if(!cars.ContainsKey(item.carName))
                            {
                                if(item.Horsepower=="?")
                                {
                                    item.Horsepower = "0";
                                }
                                car = new Car
                                {
                                    carName = item.carName,
                                    modelYear = item.modelYear,
                                    Acceleration = item.Acceleration,
                                    Weight = item.Weight,
                                    Horsepower = int.Parse(item.Horsepower),
                                    Cylinders = item.Cylinders,
                                    Displacement = item.Displacement,
                                    Origin = item.Origin,
                                    Mpg = item.Mpg
                                };
                                cars.Add(item.carName, car); 
                            }
                            else
                            {
                                car = cars[item.carName];
                            }
                        }
                        foreach (var car in cars)
                        {
                            dbContext.Cars.Add(car.Value);
                        }
                    }
                }
                dbContext.SaveChanges();
            }
        }
    }
}
