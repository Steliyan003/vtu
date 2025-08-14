using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace FileReaders  
{
    
    public class CarSpecificationMap : ClassMap<CsvMapper>
    {
        public CarSpecificationMap()
        {
            Map(x => x.carName).Name("car name").Default("NO DATA");
            Map(x => x.modelYear).Name("model year").Default(0);
            Map(x => x.Acceleration).Name("acceleration").Default(0);
            Map(x => x.Weight).Name("weight").Default(0);
            Map(x => x.Horsepower).Name("horsepower").Default("NO DATA");
            Map(x => x.Cylinders).Name("cylinders").Default(0);
            Map(x => x.Displacement).Name("displacement").Default(0);
            Map(x => x.Origin).Name("origin").Default(0);
            Map(x => x.Mpg).Name("mpg").Default(0);
        }
    }
}

