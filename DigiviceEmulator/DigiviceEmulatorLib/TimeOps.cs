using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiviceEmulatorLib
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

		/// <summary>
		/// apply decrements/evolution/death to monster based on time.
		/// </summary>
		public static void SimulateTime()
		{
			const int HatchTime = 300,              // 5 minutes (times represented in seconds)
					  FirstEvolutionTime = 86700,   // 1 day 5 minutes
					  SecondEvolutionTime = 345900, // 4 days 5 minutes
					  LifeSpan = 1209600,           // 14 days
					  DecrementRate = 3600;         // 1 hour
			int elapsedSeconds = TimeOps.GetElapsedSeconds(Monster.DateOfBirth,
														   DateTime.UtcNow);
			if (((int)Monster.Type == 0
				&& elapsedSeconds > HatchTime)
			  || (((int)Monster.Type == 1 || (int)Monster.Type == 2)
				&& elapsedSeconds > FirstEvolutionTime)
			  || (((int)Monster.Type == 3 || (int)Monster.Type == 4
				|| (int)Monster.Type == 5 || (int)Monster.Type == 6)
				&& elapsedSeconds > SecondEvolutionTime))
			{
				Controller.Evolve();
			}
			if (elapsedSeconds > LifeSpan)
			{
				Controller.Die();
			}
			int decrements = elapsedSeconds / DecrementRate;
			Monster.Health = Monster.HealthIncrements - decrements;
			Monster.Mood = Monster.MoodIncrements - decrements;
			Monster.Hygiene = Monster.HygieneIncrements - decrements;
		}
	}
}
