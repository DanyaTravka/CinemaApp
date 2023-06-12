using CinemaLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CinemaLibraryTests
{
    [TestClass]
    public class EmployeesInfoCheckTests
    {
        EmployeesInfoCheck employeesInfoCheck = new EmployeesInfoCheck();
        [TestMethod]
        public void CheckFIOInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(employeesInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(employeesInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_NumbersEntry_ReturnFalse()
        {
            string entry = "123";
            Assert.IsFalse(employeesInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_SymbolsEntry_ReturnFalse()
        {
            string entry = "$%^";
            Assert.IsFalse(employeesInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_WrongEntry_ReturnFalse()
        {
            string entry = "игорь";
            Assert.IsFalse(employeesInfoCheck.CheckFIOInfo(entry));
        }

        [TestMethod]
        public void CheckFIOInfo_RightEntry_ReturnTrue()
        {
            string entry = "Игорь";
            Assert.IsTrue(employeesInfoCheck.CheckFIOInfo(entry));
        }

        //AgeInfo

        [TestMethod]
        public void CheckAgeInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(employeesInfoCheck.CheckAgeInfo(entry));
        }

        [TestMethod]
        public void CheckAgeInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(employeesInfoCheck.CheckAgeInfo(entry));
        }

        [TestMethod]
        public void CheckAgeInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "кирдл";
            Assert.IsFalse(employeesInfoCheck.CheckAgeInfo(entry));
        }

        [TestMethod]
        public void CheckAgeInfo_WrongEntry_ReturnFalse()
        {
            string entry = "00";
            Assert.IsFalse(employeesInfoCheck.CheckAgeInfo(entry));
        }

        [TestMethod]
        public void CheckAgeInfo_RightEntry_ReturnTrue()
        {
            string entry = "18";
            Assert.IsTrue(employeesInfoCheck.CheckAgeInfo(entry));
        }

        //AdressInfo

        [TestMethod]
        public void CheckAdressInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(employeesInfoCheck.CheckAdressInfo(entry));
        }

        [TestMethod]
        public void CheckAdressInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(employeesInfoCheck.CheckAdressInfo(entry));
        }

        [TestMethod]
        public void CheckAdressInfo_RightEntrySimple_ReturnTrue()
        {
            string entry = "Бадинских";
            Assert.IsTrue(employeesInfoCheck.CheckAdressInfo(entry));
        }

        [TestMethod]
        public void CheckAdressInfo_RightEntryNumber_ReturnTrue()
        {
            string entry = "Бадинских33";
            Assert.IsTrue(employeesInfoCheck.CheckAdressInfo(entry));
        }

        [TestMethod]
        public void CheckAdressInfo_RightEntryNumberSpace_ReturnTrue()
        {
            string entry = "Бадинских дом 33";
            Assert.IsTrue(employeesInfoCheck.CheckAdressInfo(entry));
        }

        [TestMethod]
        public void CheckAdressInfo_RightEntryNumberSymbols_ReturnTrue()
        {
            string entry = "Ул. Бадинских, дом 33";
            Assert.IsTrue(employeesInfoCheck.CheckAdressInfo(entry));
        }

        //CheckPhoneInfo

        [TestMethod]
        public void CheckPhoneInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(employeesInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(employeesInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "cyrilic";
            Assert.IsFalse(employeesInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_WrongEntry_ReturnFalse()
        {
            string entry = "89089075446";
            Assert.IsFalse(employeesInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_WrongEntryPlus_ReturnFalse()
        {
            string entry = "+79089075446";
            Assert.IsFalse(employeesInfoCheck.CheckPhoneInfo(entry));
        }

        [TestMethod]
        public void CheckPhoneInfo_RightEntry_ReturnTrue()
        {
            string entry = "79089075446";
            Assert.IsTrue(employeesInfoCheck.CheckPhoneInfo(entry));
        }

        //CheckSeriaInfo

        [TestMethod]
        public void CheckSeriaInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(employeesInfoCheck.CheckSeriaInfo(entry));
        }

        [TestMethod]
        public void CheckSeriaInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(employeesInfoCheck.CheckSeriaInfo(entry));
        }

        [TestMethod]
        public void CheckSeriaInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "cyrilic";
            Assert.IsFalse(employeesInfoCheck.CheckSeriaInfo(entry));
        }

        [TestMethod]
        public void CheckSeriaInfo_ShortEntry_ReturnFalse()
        {
            string entry = "098";
            Assert.IsFalse(employeesInfoCheck.CheckSeriaInfo(entry));
        }

        [TestMethod]
        public void CheckSeriaInfo_LongEntry_ReturnFalse()
        {
            string entry = "09844";
            Assert.IsFalse(employeesInfoCheck.CheckSeriaInfo(entry));
        }

        [TestMethod]
        public void CheckSeriaInfo_RightEntry_ReturnTrue()
        {
            string entry = "0984";
            Assert.IsTrue(employeesInfoCheck.CheckSeriaInfo(entry));
        }

        //CheckNumberInfo

        [TestMethod]
        public void CheckNumberInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(employeesInfoCheck.CheckNumberInfo(entry));
        }

        [TestMethod]
        public void CheckNumberInfo_LatinEntry_ReturnFalse()
        {
            string entry = "latin";
            Assert.IsFalse(employeesInfoCheck.CheckNumberInfo(entry));
        }

        [TestMethod]
        public void CheckNumberInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "cyrilic";
            Assert.IsFalse(employeesInfoCheck.CheckNumberInfo(entry));
        }

        [TestMethod]
        public void CheckNumberInfo_ShortEntry_ReturnFalse()
        {
            string entry = "09800";
            Assert.IsFalse(employeesInfoCheck.CheckNumberInfo(entry));
        }

        [TestMethod]
        public void CheckNumberInfo_LongEntry_ReturnFalse()
        {
            string entry = "0984400";
            Assert.IsFalse(employeesInfoCheck.CheckNumberInfo(entry));
        }

        [TestMethod]
        public void CheckNumberInfo_RightEntry_ReturnTrue()
        {
            string entry = "098400";
            Assert.IsTrue(employeesInfoCheck.CheckNumberInfo(entry));
        }


        //CheckSalaryInfo

        [TestMethod]
        public void CheckSalaryInfo_EmptyEntry_ReturnFalse()
        {
            string entry = "";
            Assert.IsFalse(employeesInfoCheck.CheckSalaryInfo(entry));
        }

        [TestMethod]
        public void CheckSalaryInfo_LatinEntry_ReturnFalse()
        {
            string entry = "asdasd";
            Assert.IsFalse(employeesInfoCheck.CheckSalaryInfo(entry));
        }

        [TestMethod]
        public void CheckSalaryInfo_CyrillicEntry_ReturnFalse()
        {
            string entry = "латин";
            Assert.IsFalse(employeesInfoCheck.CheckSalaryInfo(entry));
        }

        [TestMethod]
        public void CheckSalaryInfo_WronEntry_ReturnFalse()
        {
            string entry = "0000";
            Assert.IsFalse(employeesInfoCheck.CheckSalaryInfo(entry));
        }

        [TestMethod]
        public void CheckSalaryInfo_RightEntry_ReturnTrue()
        {
            string entry = "10000";
            Assert.IsTrue(employeesInfoCheck.CheckSalaryInfo(entry));
        }

    }
}
