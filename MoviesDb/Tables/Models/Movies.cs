using System.ComponentModel.DataAnnotations;

namespace Tables.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string  MovieName { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public double Rating { get; set; }
        public string Metascore { get; set; }
        public double Votes { get; set; }
        

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Director Director { get; set; }

        [Required]
        public Cast Cast { get; set; }
        public long Gross { get; set; }
    }
}
