using MoviesLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoviesLibrary.Data
{
    public class MoviesDataReader : IMoviesDataReader
    {
        public async Task<List<MoviesEntity>> GetAll()
        {
            List<MoviesEntity> movies = new List<MoviesEntity>();
            using (StreamReader r = new StreamReader("Data/moviedata.json"))
            {
                string json = r.ReadToEnd();
                 movies = JsonSerializer.Deserialize<List<MoviesEntity>>(json);

                movies = movies.OrderByDescending(m => m.info.release_date).Take(10).ToList();

                return movies;
            }
            return movies;

        }
    }
}
