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
	public class SecurityOpsTests
	{
		[TestMethod()]
		public void HashStringTest()
		{
			string password = "testPassword";
			string hash = SecurityOps.HashString(password);
			Assert.AreNotEqual(password, hash);
		}

		[TestMethod()]
		public void VerifyHashTest()
		{
			string hash1 = "testPassword";
			string hash2 = "testPassword";
			Assert.IsTrue(SecurityOps.VerifyHash(hash1, hash2));

		}
	}
}