using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlansLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlansLib.Objects;

namespace PlansLib.Tests
{
    [TestClass()]
    public class ControllerTests
    {
        [TestMethod()]
        public void CreateUserTest()
        {
            User user = new User("TedDansen", "testPass", "Ted", "Dansen", 1, "bio", "city");

            Assert.IsFalse(Controller.CreateUser(user));

        }

        [TestMethod()]
        public void LoadUserTest()
        {
            User user = new User("TedDansen", "testPass");
            user = Controller.LoadUser(user);
            Assert.AreEqual(user.FirstName, "Ted");
        }

        [TestMethod()]
        public void LoadPlanTest()
        {
            DateTime date = new DateTime(2022, 05, 05, 0, 0, 0);
            
            List<Plan> plans = Controller.LoadPlans(date);
            Console.WriteLine(plans.Count);
            Assert.IsTrue(plans.Count > 0);
        }
    }
}