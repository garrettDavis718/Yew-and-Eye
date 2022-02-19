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
		public static string DatabasePath { get; } = @"../../UnitTests.db";
		public static User User { get; set; } = new User("testEmail", "testHash");

		[TestMethod()]
		public void OpenConnectionTest()
		{
			Assert.IsTrue(DatabaseOps.OpenConnection(DatabasePath));
			DatabaseOps.CloseConnection();
		}

		[TestMethod()]
		public void CloseConnectionTest()
		{
			if (DatabaseOps.OpenConnection(DatabasePath))
			{
				Assert.IsTrue(DatabaseOps.CloseConnection());
			}
		}

		[TestMethod()]
		public void CreateUserTest()
		{
			if (DatabaseOps.OpenConnection(DatabasePath))
			{
				Assert.IsTrue(DatabaseOps.CreateUser(User));
				DatabaseOps.DeleteUser(User);
				DatabaseOps.CloseConnection();
			}
		}

		[TestMethod()]
		public void UpdateUserTest()
		{
			if (DatabaseOps.OpenConnection(DatabasePath))
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
			if (DatabaseOps.OpenConnection(DatabasePath))
			{
				DatabaseOps.CreateUser(User);
				Assert.IsTrue(DatabaseOps.DeleteUser(User));
				DatabaseOps.CloseConnection();
			}
		}

		[TestMethod()]
		public void GetPasswordHashTest()
		{
			if (DatabaseOps.OpenConnection(DatabasePath))
			{
				DatabaseOps.CreateUser(User);
				string passwordHash = DatabaseOps.GetPasswordHash(User);
				Assert.AreEqual(passwordHash, "testHash");
				DatabaseOps.DeleteUser(User);
				DatabaseOps.CloseConnection();
			}
		}
	}
}