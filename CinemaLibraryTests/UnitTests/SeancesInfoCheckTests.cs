using CinemaLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CinemaLibraryTests.UnitTests
{
    [TestClass]
    public class SeancesInfoCheckTests
    {
        SeancesInfoCheck seancesInfoCheck = new SeancesInfoCheck();
        [TestMethod]
        public void CheckCostInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(seancesInfoCheck.CheckCostInfo(entry));
        }

        [TestMethod]
        public void CheckCostInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(seancesInfoCheck.CheckCostInfo(entry));
        }

        [TestMethod]
        public void CheckCostInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "латин";
            Assert.IsFalse(seancesInfoCheck.CheckCostInfo(entry));
        }

        [TestMethod]
        public void CheckCostInfo_WrongEntry_ReturnFalse()
        {
            string entry = "0000";
            Assert.IsFalse(seancesInfoCheck.CheckCostInfo(entry));
        }

        [TestMethod]
        public void CheckCostInfo_RightEntry_ReturnTrue()
        {
            string entry = "200";
            Assert.IsTrue(seancesInfoCheck.CheckCostInfo(entry));
        }

        //CheckTimeInfo

        [TestMethod]
        public void CheckTimeInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(seancesInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(seancesInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "латин";
            Assert.IsFalse(seancesInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_WrongEntry_ReturnFalse()
        {
            string entry = "25:00";
            Assert.IsFalse(seancesInfoCheck.CheckTimeInfo(entry));
        }

        [TestMethod]
        public void CheckTimeInfo_RightEntry_ReturnTrue()
        {
            string entry = "23:00";
            Assert.IsTrue(seancesInfoCheck.CheckTimeInfo(entry));
        }
    }
}
