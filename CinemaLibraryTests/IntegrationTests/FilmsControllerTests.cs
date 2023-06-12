using CinemaLibraryTests.Controllers;
using CinemaLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CinemaLibraryTests.IntegrationTests
{
    [TestClass]
    public class FilmsControllerTests
    {
        FilmsController filmsController = new FilmsController();
        [TestMethod]
        public void AddFilm_AddNewFilm_ReturnTrue()
        {
            Films films = new Films()
            {
                FilmName = "Тест",
                FilmDuration = new TimeSpan(0,0,0),
                FirmId = 1,
                CountryId = 1,
                AgeLimitId = 1,
                FilmDescription = ""

            };
            Assert.IsTrue(filmsController.AddFilm(films));
        }

        [TestMethod]
        public void UpdateFilm_UpdateNewFilm_ReturnTrue()
        {
            Films films = filmsController.GetLastAddedFilm();
            films.FilmName = "Супер тест";
            Assert.IsTrue(filmsController.UpdateFilm(films));
        }

        [TestMethod]
        public void DeleteFilm_DeleteNewFilm_ReturnTrue()
        {
            Films films = filmsController.GetLastAddedFilm();
           
            Assert.IsTrue(filmsController.DeleteFilm(films));
        }
    }
}
