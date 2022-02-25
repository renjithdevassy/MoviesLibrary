using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.Web.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoviesLibrary.Web.PI.Test
{
    public class MoviesTest
    {
        private readonly MoviesController _controller;
        [Fact]
        public void Get_Movies()
        {
            // Act
            var okResult = _controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult);

        }

    }
}
