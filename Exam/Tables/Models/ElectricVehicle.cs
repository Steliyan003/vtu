using System.ComponentModel.DataAnnotations;

namespace Tables.Models
{
    public class ElectricVehicle
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50)]
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

        [Required]
        public Country Country { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        public PostalCode PostalCode { get; set; }


    }
}
