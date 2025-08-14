using System.ComponentModel.DataAnnotations;

namespace Tables.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string carName { get; set; }
        public int modelYear { get; set; }
        public double Acceleration { get; set; }
        public int Weight { get; set; }
        public int Horsepower { get; set; }
        public int Cylinders { get; set; }
        public double Displacement { get; set; }
        public int Origin { get; set; }
        public double Mpg { get; set; }
    }
}
