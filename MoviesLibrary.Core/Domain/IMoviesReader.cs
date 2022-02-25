using MoviesLibrary.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Core.Domain
{
    public interface IMoviesReader
    {
        Task<List<MoviesModel>> GetAll();
    }
}
