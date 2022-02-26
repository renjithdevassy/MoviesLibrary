using MoviesLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Data
{
    public interface IMoviesDataReader
    {
        Task<List<MoviesEntity>> GetAll();
        Task<MoviesEntity> GetByTitle(string title);
    }
}
