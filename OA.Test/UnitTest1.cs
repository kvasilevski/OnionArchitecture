using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace OA.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void getData_OK()
        {
            var mockUserRepo = new Mock<IUserRepository>();

            Assert();
        }
    }
}
