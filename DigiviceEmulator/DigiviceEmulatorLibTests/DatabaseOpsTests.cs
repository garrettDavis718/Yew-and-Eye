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
		public static string name = "testName",
							 animations = "testAnimations";
		public static Monster.Types type = Monster.Types.Faunamon;
		public static Monster.States state = Monster.States.idle;
		public static int health = 10,
						  mood = 10,
						  hygiene = 10;
		public static DateTime dateOfBirth = new DateTime(1969, 4, 20);

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
		public void SetMonsterAttributeTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			if (DatabaseOps.OpenConnection())
			{
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.name, name));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.animation, animations));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.type, (int)type));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.state, (int)state));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.health, health));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.mood, mood));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.hygiene, hygiene));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.date_of_birth, dateOfBirth));
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

		[TestMethod()]
		public void GetMonsterAttributeTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			if (DatabaseOps.OpenConnection())
			{
				Assert.AreEqual(name, DatabaseOps.GetMonsterAttribute<string>(Monster.Attributes.name));
				Assert.AreEqual(animations, DatabaseOps.GetMonsterAttribute<string>(Monster.Attributes.animation));
				Assert.AreEqual((int)type, DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.type));
				Assert.AreEqual((int)state, DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.state));
				Assert.AreEqual(health, DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.health));
				Assert.AreEqual(mood, DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.mood));
				Assert.AreEqual(hygiene, DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.hygiene));
				Assert.AreEqual(dateOfBirth, DatabaseOps.GetMonsterAttribute<DateTime>(Monster.Attributes.date_of_birth));
				DatabaseOps.CloseConnection();
			}
		}
	}
}