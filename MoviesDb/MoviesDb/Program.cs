using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Globalization;
using Context;
using CsvMap;
using Tables.Models;
using System.Linq;

namespace MoviesDb
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Genre> genres = new Dictionary<string, Genre>();
            Dictionary<string, Director> directors = new Dictionary<string, Director>();
            Dictionary<string, Cast> actors = new Dictionary<string, Cast>();
            MoviesDbContext context = new MoviesDbContext();
            StreamReader reader = new StreamReader($"C:\\Users\\rumen\\source\\repos\\MoviesDb\\imdb_top_2000_movies.csv");
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
                        csv.Context.RegisterClassMap<MovieMap>();
                        var records = csv.GetRecords<CsvMapper>().ToList();
                        foreach (var item in records)
                        {
                            Genre? genre = null;
                            Director? director = null;
                            Cast? cast = null;
                            if (!actors.ContainsKey(item.Cast))
                            {
                                cast = new Cast { Name = item.Cast };
                                actors.Add(cast.Name, cast);
                            }
                            else
                            {
                                cast = actors[item.Cast];
                            }
                            if (!directors.ContainsKey(item.Director))
                            {
                                director = new Director { Name = item.Director };
                                directors.Add(director.Name, director);
                            }
                            else
                            {
                                director = directors[item.Director];
                            }
                            var splittedGenres = item.Genre.Split(",", StringSplitOptions.TrimEntries);
                            foreach (var gr in splittedGenres)
                            {
                                if (!genres.ContainsKey(gr))
                                {
                                    genre = new Genre { Type = gr };
                                    genres.Add(genre.Type, genre);
                                }
                                else
                                {
                                    genre = genres[gr];
                                }
                            }

                            long gross = manager.ParseGross(item.Gross);
                            if (item.ReleaseYear.Contains('–'))
                            {
                                string tempYear = item.ReleaseYear.Substring(5);
                                item.ReleaseYear = tempYear;
                            }
                            if (item.ReleaseYear.Contains('I'))
                            {
                                string tempYear = item.ReleaseYear.Substring(2);
                                item.ReleaseYear = tempYear;
                            }
                            if (item.ReleaseYear.Contains('V'))
                            {
                                string tempYear = item.ReleaseYear.Substring(0, 4);
                                item.ReleaseYear = tempYear;
                            }
                            if (item.ReleaseYear.Contains(' '))
                            {
                                string tempYear = item.ReleaseYear.Replace(" ", "");
                                item.ReleaseYear = tempYear;
                            }
                            var movie = new Movies
                            {
                                MovieName = item.MovieName,
                                ReleaseYear = int.Parse(item.ReleaseYear),
                                Duration = item.Duration,
                                Rating = item.Rating,
                                Metascore = item.Metascore,
                                Votes = int.Parse(item.Votes.ToString().Replace(",", "").Replace('"', '\0')),
                                Gross = gross,
                                Genre = genre,
                                Director = director,
                                Cast = cast
                            };

                            context.Movie.Add(movie);
                        }
                        foreach (var item in actors)
                        {
                            context.Cast.Add(item.Value);
                        }
                        foreach (var item in directors)
                        {
                            context.Director.Add(item.Value);
                        }
                        foreach (var item in genres)
                        {
                            context.Genre.Add(item.Value);
                        }
                    }
                }
                context.SaveChanges();
            }


        }    
    }
}
