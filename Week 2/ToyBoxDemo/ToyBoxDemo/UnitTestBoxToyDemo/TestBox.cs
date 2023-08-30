using ToyBoxDemo;

namespace UnitTestBoxToyDemo
{
    [TestClass]
    public class TestBox
    {
        private Box theBox;

        [TestInitialize]
        public void MakeEmptyBox()
        {
            theBox = new Box();
        }

        [TestMethod]
        public void TestToyCounTIsZero()
        {
            //Box theBox = new Box();
            int expectedToyCount = 0;
            int actualToyCount = theBox.GetToyCount();
            Assert.AreEqual(expectedToyCount, actualToyCount);
        }

        [TestMethod]
        public void TestReturnsAStringSayingItIsABoxWith0Toys()
        {
            //Box theBox = new Box();
            string expectedString = "A box containing 0 toys";
            string actualString = "" + theBox;
            Assert.AreEqual(expectedString, actualString);
        }

        void AddToy1()
        {
            theBox.AddToy("Teddy", "brown", 12.34M);
        }

        [TestMethod]
        public void TestBoxWith1ToyHasToyCount1()
        {
            AddToy1();
            int expectedToyCount = 1;
            int actualToyCount = theBox.GetToyCount();
            Assert.AreEqual(expectedToyCount, actualToyCount);
        }

        [TestMethod]
        public void TestBoxWith1ToyReturnsCorrectString()
        {
            //theBox.AddToy("Teddy", "brown", 12.34M);
            AddToy1();
            string expectedString = "A box containing 1 toys"
                + "\na brown colored Teddy worth $12.34";

            string actualString = "" + theBox;
            Assert.AreEqual(expectedString, actualString);
        }

        void AddToy2()
        {
            theBox.AddToy("Doll", "pink", 34.56M);
        }

        [TestMethod]
        public void TestBoxWith2ToysHasToyCount2()
        {
            AddToy1();
            AddToy2();
            int expectedToyCount = 2;
            int actualToyCount = theBox.GetToyCount();
            Assert.AreEqual(expectedToyCount, actualToyCount);
        }

        [TestMethod]
        public void TestBoxWith2ToysReturnsCorrectString()
        {
            AddToy1();
            AddToy2();
            string expectedString = "A box containing 2 toys"
                + "\na brown colored Teddy worth $12.34"
                + "\na pink colored Doll worth $34.45";
            string actualString = "" + theBox;
            Assert.AreEqual(expectedString, actualString);
        }

        void AddToy3()
        {
            theBox.AddToy("Aardvark", "black", 45.67M);
        }

        public void TestBoxWith3ToysHasToyCount3()
        {
            AddToy1();
            AddToy2();
            AddToy3();
            int expectedToyCount = 3;
            int actualToyCount = theBox.GetToyCount();
            Assert.AreEqual(expectedToyCount, actualToyCount);
        }

        [TestMethod]
        public void TestBoxWith3ToysReturnsCorrectString()
        {
            AddToy1();
            AddToy2();
            AddToy3();
            string expectedString = "A box containing 3 toys"
                + "\na brown colored Teddy worth $12.34"
                + "\na pink colored Doll worth $34.45"
                + "\na black colored Aadvark worth $45.67";
            string actualString = "" + theBox;
            Assert.AreEqual(expectedString, actualString);
        }

        // [TestMethod]
        [Ignore]
        public void TestBoxcanSortByToyName()
        {

        }
    }
}