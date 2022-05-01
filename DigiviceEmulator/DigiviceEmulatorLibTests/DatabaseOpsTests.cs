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
		public static string name = "testName",
							 animations = "testAnimations",
							 email = "testEmail",
							 passwordHash = "testHash";
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
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.health_increments, health));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.mood_increments, mood));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.hygiene_increments, hygiene));
				Assert.IsTrue(DatabaseOps.SetMonsterAttribute(Monster.Attributes.date_of_birth, dateOfBirth));
				DatabaseOps.CloseConnection();
			}
		}

		[TestMethod()]
		public void SetUserAttributeTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			if (DatabaseOps.OpenConnection())
			{
				Assert.IsTrue(DatabaseOps.SetUserAttribute(User.Attributes.email, email));
				Assert.IsTrue(DatabaseOps.SetUserAttribute(User.Attributes.password_hash, passwordHash));
				DatabaseOps.CloseConnection();
			}
		}

		[TestMethod()]
		public void GetUserAttributeTest()
		{
			DatabaseOps.DatabasePath = @"../../UnitTests.db";
			if (DatabaseOps.OpenConnection())
			{
				Assert.AreEqual(email, DatabaseOps.GetUserAttribute(User.Attributes.email));
				Assert.AreEqual(SecurityOps.HashString(passwordHash), DatabaseOps.GetUserAttribute(User.Attributes.password_hash));
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
				Assert.AreEqual(health, DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.health_increments));
				Assert.AreEqual(mood, DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.mood_increments));
				Assert.AreEqual(hygiene, DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.hygiene_increments));
				Assert.AreEqual(dateOfBirth, DatabaseOps.GetMonsterAttribute<DateTime>(Monster.Attributes.date_of_birth));
				DatabaseOps.CloseConnection();
			}
		}
	}
}