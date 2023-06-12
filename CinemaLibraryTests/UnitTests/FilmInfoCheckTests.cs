using CinemaLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CinemaLibraryTests.UnitTests
{
    [TestClass]
    public class FilmInfoCheckTests
    {
        FilmInfoCheck filmInfoCheck = new FilmInfoCheck();

        [TestMethod]
        public void CheckNameInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(filmInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "#$#$";
            Assert.IsFalse(filmInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_LatinEntry_ReturnTrue()
        {
            string entry = "azazlo";
            Assert.IsTrue(filmInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_LatinUpperEntry_ReturnTrue()
        {
            string entry = "Azazlo";
            Assert.IsTrue(filmInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_LatinUpperNumbersEntry_ReturnTrue()
        {
            string entry = "Azazlo1";
            Assert.IsTrue(filmInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_LatinUpperNumbersSpaceEntry_ReturnTrue()
        {
            string entry = "Azazlo 1";
            Assert.IsTrue(filmInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_CyrillicEntry_ReturnTrue()
        {
            string entry = "аватар";
            Assert.IsTrue(filmInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_CyrillicUpperEntry_ReturnTrue()
        {
            string entry = "Аватар";
            Assert.IsTrue(filmInfoCheck.CheckNameInfo(entry));
        }
        [TestMethod]
        public void CheckNameInfo_CyrillicUpperNumbersEntry_ReturnTrue()
        {
            string entry = "Аватар2";
            Assert.IsTrue(filmInfoCheck.CheckNameInfo(entry));
        }

        [TestMethod]
        public void CheckNameInfo_CyrillicUpperNumbersSpaceEntry_ReturnTrue()
        {
            string entry = "Аватар 2";
            Assert.IsTrue(filmInfoCheck.CheckNameInfo(entry));
        }


        //CheckDescriptionInfo 

        [TestMethod]
        public void CheckDescriptionInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(filmInfoCheck.CheckDescriptionInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "$%^";
            Assert.IsFalse(filmInfoCheck.CheckDescriptionInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfo_LatinEntry_ReturnTrue()
        {
            string entry = "latin";
            Assert.IsTrue(filmInfoCheck.CheckDescriptionInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfo_LatinUpperEntry_ReturnTrue()
        {
            string entry = "Latin";
            Assert.IsTrue(filmInfoCheck.CheckDescriptionInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfo_LatinUpperCyrillicEntry_ReturnTrue()
        {
            string entry = "Latin латин";
            Assert.IsTrue(filmInfoCheck.CheckDescriptionInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfo_LatinUpperCyrillicUpperEntry_ReturnTrue()
        {
            string entry = "Latin Латин";
            Assert.IsTrue(filmInfoCheck.CheckDescriptionInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfo_LatinUpperCyrillicUpperNumbersEntry_ReturnTrue()
        {
            string entry = "Latin Латин 43";
            Assert.IsTrue(filmInfoCheck.CheckDescriptionInfo(entry));
        }

        [TestMethod]
        public void CheckDescriptionInfo_LatinUpperCyrillicUpperNumbersRightSymbolsEntry_ReturnTrue()
        {
            string entry = "Latin Латин, 43. Латин - не латин";
            Assert.IsTrue(filmInfoCheck.CheckDescriptionInfo(entry));
        }


        //CheckDurationInfo 

        [TestMethod]
        public void CheckDurationInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(filmInfoCheck.CheckDurationInfo(entry));
        }

        [TestMethod]
        public void CheckDurationInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(filmInfoCheck.CheckDurationInfo(entry));
        }

        [TestMethod]
        public void CheckDurationInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "латин";
            Assert.IsFalse(filmInfoCheck.CheckDurationInfo(entry));
        }

        [TestMethod]
        public void CheckDurationInfo_WrongEntry_ReturnFalse()
        {
            string entry = "03:94";
            Assert.IsFalse(filmInfoCheck.CheckDurationInfo(entry));
        }

        [TestMethod]
        public void CheckDurationInfo_RightEntry_ReturnTrue()
        {
            string entry = "3:59";
            Assert.IsTrue(filmInfoCheck.CheckDurationInfo(entry));
        }
    }
}
