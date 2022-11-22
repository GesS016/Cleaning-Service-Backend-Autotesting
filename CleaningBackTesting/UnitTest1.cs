using System;
using NUnit.Framework;

namespace CleaningBackTesting
{
    public class Tests
    {
        FirstClassTest first  = new FirstClassTest();
        [TestCase (2, 2, 4)]
        public void ayeTest(int x,int y,int expected)
        {
            int actual = first.aye(x,y);
            Assert.AreEqual(expected, actual);
        }
    }
}