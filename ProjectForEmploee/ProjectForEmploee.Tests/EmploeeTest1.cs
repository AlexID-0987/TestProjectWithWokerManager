using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectForEmploee.Tests
{
    [TestClass]
    public class EmploeeTest1
    {
        [TestMethod]
        public void Summa_20and_40_60returned()
        {
            IEnumerable<int> myList = new List<int>() { 20, 40 };
            int expected = 60;
            int summa = 0;
            foreach (var summaNum in myList)
            {
                summa += summaNum;
            }
            Assert.AreEqual(expected, summa);
        }
    }
}
