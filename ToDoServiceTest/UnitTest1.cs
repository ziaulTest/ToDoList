using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToDoServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 1;
        

            Assert.IsNotNull(a);
        }
    }
}
