using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlansLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlansLib.Tests
{
    [TestClass()]
    public class ControllerTests
    {
        [TestMethod()]
        public void CreateUserTest()
        {
            User user = new User("TedDansen", "testPass", "Ted", "Dansen");

            Assert.IsFalse(Controller.CreateUser(user));

        }

        [TestMethod()]
        public void LoadUserTest()
        {
            User user = new User("TedDansen", "testPass");
            user = Controller.LoadUser(user);
            Assert.AreEqual(user.FirstName, "Ted");
        }
    }
}