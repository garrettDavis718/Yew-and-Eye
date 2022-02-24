using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigiviceEmulatorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DigiviceEmulatorLib.Tests
{
	[TestClass()]
	public class DatabaseOpsTests
	{
		public static User User { get; set; } = new User("testEmail", "testHash");

		[TestMethod()]
		public void OpenConnectionTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			Assert.IsTrue(DatabaseOps.OpenConnection());
			DatabaseOps.CloseConnection();
		}

		[TestMethod()]
		public void CloseConnectionTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			if (DatabaseOps.OpenConnection())
			{
				Assert.IsTrue(DatabaseOps.CloseConnection());
			}
		}

		[TestMethod()]
		public void CreateUserTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			if (DatabaseOps.OpenConnection())
			{
				Assert.IsTrue(DatabaseOps.CreateUser(User));
				DatabaseOps.DeleteUser(User);
				DatabaseOps.CloseConnection();
			}
		}

		[TestMethod()]
		public void UpdateUserTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			if (DatabaseOps.OpenConnection())
			{
				DatabaseOps.CreateUser(User);
				User.PasswordHash = "newHash";
				Assert.IsTrue(DatabaseOps.UpdateUser(User));
				DatabaseOps.DeleteUser(User);
				DatabaseOps.CloseConnection();
			}
		}

		[TestMethod()]
		public void DeleteUserTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			if (DatabaseOps.OpenConnection())
			{
				DatabaseOps.CreateUser(User);
				Assert.IsTrue(DatabaseOps.DeleteUser(User));
				DatabaseOps.CloseConnection();
			}
		}

		[TestMethod()]
		public void GetPasswordHashTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			if (DatabaseOps.OpenConnection())
			{
				DatabaseOps.CreateUser(User);
				string passwordHash = DatabaseOps.GetPasswordHash(User.Email);
				Assert.AreEqual(passwordHash, "testHash");
				DatabaseOps.DeleteUser(User);
				DatabaseOps.CloseConnection();
			}
		}
	}
}