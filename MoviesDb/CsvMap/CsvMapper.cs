namespace CsvMap
{
    public class CsvMapper
    {
        public string MovieName { get; set; }
        public string ReleaseYear { get; set; }
        public int Duration { get; set; }
        public double Rating { get; set; }
        public string Metascore { get; set; }
        public double Votes { get; set; }
        public string Genre { get; set; }
        public string Gross { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }


        public long ParseGross(string gross)
        {
            gross = gross.Replace("$", "").Replace(".", "").Replace("M", "");
            if (long.TryParse(gross, out long result) == true)
            {
                result *= 10000;
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}
