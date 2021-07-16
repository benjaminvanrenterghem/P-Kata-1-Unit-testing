using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Kata1.Tests
{
    // AAA pattern
    // Arrange → Act → Assert

    [TestClass()]
    public class CalculatorTests
    {
        private Calculator _calculator;

        // TestInitialize zorgt er voor dat er voor iedere test met een schone lij begonnen wordt,
        // was niet perse van toepassing sinds de staat van Calculator nooit veranderd (er is slechts sprake van 1 methode in een klasse die iets retourneert)
        [TestInitialize]
        public void Setup() 
        {
            _calculator = new Calculator();
        }

        private int AddTest(string toBeHandled) // wordt gebruikt door de onderstaande testmethodes
        {
            var res = _calculator.Add(toBeHandled);
            return res;
        }

        [TestMethod()]
        public void legeStringTest()
        {
            string testStr = "";
            int perfres = 0;
           
            Assert.AreEqual(AddTest(testStr), perfres);
        }

        [TestMethod()]
        public void enkelGetalTest()
        {
            string testStr = "8";
            int perfres = 8;

            Assert.AreEqual(AddTest(testStr), perfres);
        }

        [TestMethod()]
        public void duoGetalMetSeparatorTest()
        {
            string testStr = "8,4";
            int perfres = 12;

            Assert.AreEqual(AddTest(testStr), perfres);
        }

        [TestMethod()]
        public void nGetalMetSeparatorsTest()
        {
            string testStr = "4,3,6,9,4,1,3,2,1,5,1";
            int perfres = 39;

            Assert.AreEqual(AddTest(testStr), perfres);

            // trailing komma ,
            string testStrII = "4,3,6,9,4,1,3,2,1,5,1,";

            Assert.AreEqual(AddTest(testStrII), perfres);
        }

        [TestMethod()]
        public void nGetalMetDiffSeparatorsTest()
        {
            string testStr = "4\n3\n2\n1,3,4,5\n6";
            int perfres = 28;

            Assert.AreEqual(AddTest(testStr), perfres);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotSupportedException))]
        public void nGetalMetNegatievenEnSeparatorsTest()
        {
            string testStr = "4\n-1,2,3,-7\n4";
            int placeholder = 0;

            Assert.AreEqual(AddTest(testStr), placeholder);

        }

        [TestMethod()]
        public void nGetalMetDuizendenEnSeparatorsTest()
        {
            string testStr = "5,1000,1001,3";
            int perfres = 1008;

            Assert.AreEqual(AddTest(testStr), perfres);
        }

    }
}
