using MoviesLibrary.API.Models;
using MoviesLibrary.Data;
using MoviesLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary.Core.Domain
{
    public class MoviesReader : IMoviesReader
    {
        private readonly IMoviesDataReader _moviesDatReader;
        private readonly IObjectMapper _objectMapper;
        public MoviesReader(
            IMoviesDataReader moviesDatReader,
            IObjectMapper objectMapper)
        {
            _moviesDatReader = moviesDatReader;
            _objectMapper = objectMapper;
        }
        public async Task<List<MoviesModel>> GetAll()
        {
            var model = await _moviesDatReader.GetAll();
            var entry = _objectMapper.Map<List<MoviesEntity>, List<MoviesModel>>(model);
            return entry;
        }
        public async Task<MoviesModel> GetByTitle(string title)
        {
            var model = await _moviesDatReader.GetByTitle(title);
            var entry = _objectMapper.Map<MoviesEntity, MoviesModel>(model);
            return entry;
        }
    }
}
