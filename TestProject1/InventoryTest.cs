using SCANINOUTBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for InventoryTest and is intended
    ///to contain all InventoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InventoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetData
        ///</summary>
        [TestMethod()]
        public void GetDataTest()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value
            string SKU = ""; // TODO: Initialize to an appropriate value
            string Barcode = "xxx123456789012"; // TODO: Initialize to an appropriate value
            string result = string.Empty; // TODO: Initialize to an appropriate value
            string resultExpected = string.Empty; // TODO: Initialize to an appropriate value
            InventoryRecord expected = null; // TODO: Initialize to an appropriate value
            InventoryRecord actual;
            actual = target.GetData(SKU, Barcode, ref result);
            //Assert.AreEqual(resultExpected, result);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
