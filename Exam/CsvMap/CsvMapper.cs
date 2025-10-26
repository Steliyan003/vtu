using CsvHelper.Configuration.Attributes;

namespace CsvMap
{
    public class CsvMapper
    {
//[Name("VIN (1-10)")]    
        public string VIN { get; set; }
        public int ModelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ElectricVehicleType { get; set; }
        public string CleanAlternativeFuelVehicle { get; set; }
        public int ElectricRange { get; set; }
        public int BaseMSRP { get; set; }
        public int LegislativeDistrict { get; set; }
        public string DOLVehicleID { get; set; }
        public string VehicleLocation { get; set; }
        public string ElectricUtility { get; set; }
        public string CensusTract { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }

    }
}
