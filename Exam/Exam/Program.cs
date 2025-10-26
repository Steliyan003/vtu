using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Globalization;
using Context;
using CsvMap;
using Tables.Models;
using System.Linq;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Country> countries = new Dictionary<string, Country>();
            Dictionary<string, State> states = new Dictionary<string, State>();
            Dictionary<string, City> cities = new Dictionary<string, City>();
            ExamDbContext context = new ExamDbContext();
            StreamReader reader = new StreamReader($"C:\\Users\\rumen\\source\\repos\\Exam\\Electric_Vehicle_Population_Data.csv");
            CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ","
            });
            CsvMapper manager = new CsvMapper();
            using (context)
            {
                context.Database.EnsureCreated();
                using (reader)
                {
                    using (csv)
                    {
                        csv.Context.RegisterClassMap<ExamMap>();
                        var records = csv.GetRecords<CsvMapper>().ToList();
                        foreach (var item in records)
                        {
                            City? city = null;

                            State? state = null;

                            Country? country = null;


                            if (!states.ContainsKey(item.State))
                            {
                                state = new State { stateName = item.State };
                                states.Add(item.State, state);
                            }
                            else
                            {
                                state = states[item.State];
                            }

                            if (!countries.ContainsKey(item.Country))
                            {
                                country = new Country { countryName = item.Country };
                                countries.Add(item.Country, country);
                            }
                            else
                            {
                                country = countries[item.Country];
                            }
                            if (!cities.ContainsKey(item.City))
                            {
                                city = new City { CityName = item.City };
                                cities.Add(item.City, city);
                            }
                            else
                            {
                                city = cities[item.City];
                            }

                            var car = new ElectricVehicle
                            {
                                VIN = item.VIN,
                                ModelYear = item.ModelYear,
                                Make = item.Make,
                                Model = item.Model,
                                ElectricVehicleType = item.ElectricVehicleType,
                                CleanAlternativeFuelVehicle = item.CleanAlternativeFuelVehicle,
                                ElectricRange = item.ElectricRange,
                                BaseMSRP = item.BaseMSRP,
                                LegislativeDistrict = item.LegislativeDistrict,
                                DOLVehicleID = item.DOLVehicleID,
                                VehicleLocation = item.VehicleLocation,
                                ElectricUtility = item.ElectricUtility,
                                CensusTract = item.CensusTract,
                                Country = country,
                                State = state,
                                City = city,
                                PostalCode = new PostalCode { postalCode = item.PostalCode }
                            };
                            context.ElectricVehicle.Add(car);


                        }
                        foreach (var item in countries)
                        {
                            context.Country.Add(item.Value);
                        }

                        foreach (var item in states)
                        {
                            context.State.Add(item.Value);
                        }

                        foreach (var item in cities)
                        {
                            context.City.Add(item.Value);
                        }
                    }
                }
                context.SaveChanges();
            }
            
        }
    }
}
