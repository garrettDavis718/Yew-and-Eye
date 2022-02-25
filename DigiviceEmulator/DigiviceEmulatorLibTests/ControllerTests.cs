using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigiviceEmulatorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiviceEmulatorLib.Tests
{
	[TestClass()]
	public class ControllerTests
	{
		[TestMethod()]
		public void CreateUserTest()
		{
			string email = "testEmail",
				   password = "testPassword";
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			Assert.IsTrue(Controller.CreateUser(email, password));
			Controller.DeleteUser(email, password);
		}

		[TestMethod()]
		public void UpdatePasswordTest()
		{
			string email = "testEmail",
				   password = "testPassword",
				   newPassword = "newPassword";
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			Controller.CreateUser(email, password);
			Assert.IsTrue(Controller.UpdatePassword(email, newPassword));
			Controller.DeleteUser(email, newPassword);
		}

		[TestMethod()]
		public void LoginTest()
		{
			string email = "testEmail",
				   password = "testPassword";
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			Controller.CreateUser(email, password);
			Assert.IsTrue(Controller.Login(email, password));
			Controller.DeleteUser(email, password);
		}

		[TestMethod()]
		public void DeleteUserTest()
		{
			string email = "testEmail",
				   password = "testPassword";
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			Controller.CreateUser(email, password);
			Assert.IsTrue(Controller.DeleteUser(email, password));
		}
	}
}