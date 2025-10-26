using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvMap
{
    public class ExamMap:ClassMap<CsvMapper>
    {
        public ExamMap()
        {
            Map(x => x.VIN).Name("VIN (1-10)").Default("NO DATA");
            Map(x=> x.Country).Index(1).Default("NO DATA");
            Map(x => x.City).Name("City").Default("NO DATA");
            Map(x => x.State).Name("State").Default("NO DATA");
            Map(x => x.PostalCode).Name("Postal Code").Default(0);
            Map(x => x.ModelYear).Name("Model Year").Default(0);
            Map(x => x.Make).Name("Make").Default("NO DATA");
            Map(x => x.Model).Name("Model").Default("NO DATA");
            Map(x => x.ElectricVehicleType).Name("Electric Vehicle Type").Default("NO DATA");
            Map(x => x.CleanAlternativeFuelVehicle).Name("Clean Alternative Fuel Vehicle (CAFV) Eligibility").Default("NO DATA");
            Map(x => x.ElectricRange).Name("Electric Range").Default(0);
            Map(x => x.BaseMSRP).Name("Base MSRP").Default(0);
            Map(x => x.LegislativeDistrict).Name("Legislative District").Default(0);
            Map(x => x.DOLVehicleID).Name("DOL Vehicle ID").Default("NO DATA");
            Map(x => x.VehicleLocation).Name("Vehicle Location").Default("NO DATA");
            Map(x => x.ElectricUtility).Name("Electric Utility").Default("NO DATA");
            Map(x => x.CensusTract).Name("2020 Census Tract").Default("NO DATA");
        }
    }
}
