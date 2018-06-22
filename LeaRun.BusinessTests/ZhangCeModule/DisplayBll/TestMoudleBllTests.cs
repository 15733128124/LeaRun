using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeaRun.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Business.Tests
{
    [TestClass()]
    public class TestMoudleBllTests
    {
        [TestMethod()]
        public void GetTestMoudleAllInfoTest()
        {
            TestMoudleBll tc = new TestMoudleBll();
            int[] an= tc.GetRandom(70);
            Assert.Fail();
        }
    }
}