using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlansLib
{
	/// <summary>
	/// class for performing time based operations.
	/// </summary>
	public static class TimeOps
	{
		/// <summary>
		/// calculate elapsed time based on 2 DateTime points. use DateTime.UtcNow
		/// to easily create time points. 
		/// </summary>
		/// <param name="startTime">point to start timing.</param>
		/// <param name="endTime">point to stop timing.</param>
		/// <returns>total elapsed time in seconds.</returns>
		public static int GetElapsedSeconds(DateTime startTime, DateTime endTime)
		{
			TimeSpan timeSpan = endTime - startTime;
			int elapsedSeconds = (int)timeSpan.TotalSeconds;
			return elapsedSeconds;
		}
	}
}
