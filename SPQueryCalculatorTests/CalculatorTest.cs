using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPQueryGenerator;

namespace SPQueryCalculatorTests
{

    [TestClass]
    public class CalculatorTest
    {

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Add_OneTextParam_ReturnsQuery()
        {
            Generator calculator = new Generator();
            string query = @"<Where><Eq><FieldRef Name='field' /><Value Type='Text'>value</Value></Eq></Where>";

            calculator.AddParam("field", "value");

            Assert.AreEqual(query, calculator.Query);
        }

        [TestMethod]
        public void Add_AnotherTextParam_ReturnsQuery()
        {
            Generator generator = new Generator();
            string query = @"<Where><Eq><FieldRef Name='field2' /><Value Type='Text'>value2</Value></Eq></Where>";

            generator.AddParam("field2", "value2");

            Assert.AreEqual(query, generator.Query);
        }

        [TestMethod]
        public void Add_TwoTextParams_ReturnsQuery()
        {
            Generator generator = new Generator();
            string query = @"<Where><And><Eq><FieldRef Name='field1' /><Value Type='Text'>value1</Value></Eq><Eq><FieldRef Name='field2' /><Value Type='Text'>value2</Value></Eq></And></Where>";

            generator.AddParam("field1", "value1");
            generator.AddParam("field2", "value2");
            Assert.AreEqual(query, generator.Query);

        }

        [TestMethod]
        public void Add_ThreeTextParams_ReturnsQuery()
        {
            Generator generator = new Generator();
            string query = @"<Where><And><And><Eq><FieldRef Name='field1' /><Value Type='Text'>value1</Value></Eq><Eq><FieldRef Name='field2' /><Value Type='Text'>value2</Value></Eq></And><Eq><FieldRef Name='field3' /><Value Type='Text'>value3</Value></Eq></And></Where>";

            generator.AddParam("field1", "value1");
            generator.AddParam("field2", "value2");
            generator.AddParam("field3", "value3");
            Assert.AreEqual(query, generator.Query);

        }

        [TestMethod]
        public void Add_FourTextParams_ReturnsQuery()
        {
            Generator generator = new Generator();
            string query = @"<Where><And><And><And><Eq><FieldRef Name='field1' /><Value Type='Text'>value1</Value></Eq><Eq><FieldRef Name='field2' /><Value Type='Text'>value2</Value></Eq></And><Eq><FieldRef Name='field3' /><Value Type='Text'>value3</Value></Eq></And><Eq><FieldRef Name='field4' /><Value Type='Text'>value4</Value></Eq></And></Where>";

            generator.AddParam("field1", "value1");
            generator.AddParam("field2", "value2");
            generator.AddParam("field3", "value3");
            generator.AddParam("field4", "value4");
            Assert.AreEqual(query, generator.Query);

        }

        [TestMethod]
        public void Add_OneNumberParam_ReturnsTypedQuery()
        {
            Generator calculator = new Generator();
            string query = @"<Where><Eq><FieldRef Name='field' /><Value Type='Number'>value</Value></Eq></Where>";

            calculator.AddParam("field", "value", "Number");

            Assert.AreEqual(query, calculator.Query);
        }

        [TestMethod]
        public void Add_TwoNumberParam_ReturnsTypedQuery()
        {
            Generator calculator = new Generator();
            string query = @"<Where><And><Eq><FieldRef Name='field1' /><Value Type='Number'>value1</Value></Eq><Eq><FieldRef Name='field2' /><Value Type='Number'>value2</Value></Eq></And></Where>";

            calculator.AddParam("field1", "value1", "Number");
            calculator.AddParam("field2", "value2", "Number");

            Assert.AreEqual(query, calculator.Query);
        }
    }
}
