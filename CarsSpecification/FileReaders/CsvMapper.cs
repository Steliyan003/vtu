using CsvHelper.Configuration;

namespace FileReaders
{
    public class CsvMapper
    {
        public string carName { get; set; }
        public int modelYear { get; set; }
        public double Acceleration { get; set; }
        public int Weight { get; set; }
        public string Horsepower { get; set; }
        public int Cylinders { get; set; }
        public double Displacement { get; set; }
        public int Origin { get; set; }
        public double Mpg { get; set; }
    }
}
