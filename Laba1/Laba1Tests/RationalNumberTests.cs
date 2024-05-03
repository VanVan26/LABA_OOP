using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laba1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Tests
{
    [TestClass()]
    public class RationalNumberTests
    {
        [TestMethod()]
        public void Sum()
        {
            RationalNumber test1 = new RationalNumber(1, 2);
            RationalNumber test2 = new RationalNumber(1, 2);
            RationalNumber trueTest3 = new RationalNumber(1, 1);
            var res = test1 + test2;
            Assert.IsTrue(res==trueTest3);
        }
    }
}