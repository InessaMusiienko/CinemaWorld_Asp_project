using CinemaWorld.Data.Models;
using CinemaWorld.Models.Film;
using CinemaWorld.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWorld.Tests.Mocks.Services
{
    public class FilmServiceTest
    {
       public void FilmShouldReturnViewWithCorrectModel()
       {
            //Arrange
            const int filmId = 1;
            using var data = DatabaseMock.Instance;

            data.Films.Add(new Film {Id = 1}); 
            data.SaveChanges();

            var filmService = new FilmService(data);

            //Act
            var result = filmService.GetFilmByIdAsync(1);

            //Assert
       }
    }
}
