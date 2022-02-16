using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigiviceEmulatorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DigiviceEmulatorLib.Tests
{
	[TestClass()]
	public class TimeOpsTests
	{
		[TestMethod()]
		public void GetElapsedSecondsTest()
		{
			DateTime startTime = DateTime.UtcNow;
			Thread.Sleep(1000);
			DateTime stopTime = DateTime.UtcNow;
			int elapsedSeconds = TimeOps.GetElapsedSeconds(startTime, stopTime);
			Assert.AreEqual(expected: 1,
							actual: elapsedSeconds);
		}
	}
}