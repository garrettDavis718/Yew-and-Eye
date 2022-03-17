using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiviceEmulatorLib
{
	/// <summary>
	/// monster object.
	/// </summary>
	public class Monster
	{
		private int mood;
		private int hygiene;
		private int hunger;

		/// <summary>
		/// Monster object. 
		/// </summary>
		/// <param name="name">user-given name.</param>
		/// <param name="animations">animations for given monster.</param>
		/// <param name="health">current level of health of monster. (higher is better.)</param>
		/// <param name="mood">current mood of monster. (higher is better.)</param>
		/// <param name="dateOfBirth">date and time of monsters birth.</param>
		public Monster(string name,
					   AnimationSet animations,
					   int health,
					   int mood,
					   int dateOfBirth)
		{
			Name = name;
			Animations = animations;
			Mood = mood;
			DateOfBirth = dateOfBirth;
		}

		public Monster()
		{
			Name = "Empty";
			Mood = 100;
			Hygiene = 100;
			Hunger = 0;
		}

		/// <summary>
		/// user-given name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// animations for given monster.
		/// </summary>
		public AnimationSet Animations { get; set; }

		/// <summary>
		/// current mood of monster. (higher is better.)
		/// </summary>
		public int Mood
		{
			get { return mood; }
			set
			{
				if (value > 100) { mood = 100; }
				else if (value < 0) { mood = 0; }
				else { mood = value; }
			}
		}

		/// <summary>
		/// current hygiene of monster. (higher is better.)
		/// </summary>
		public int Hygiene
		{
			get { return hygiene; }
			set
			{
				if (value > 100) { hygiene = 100; }
				else if (value < 0) { hygiene = 0; }
				else { hygiene = value; }
			}
		}

		/// <summary>
		/// current hunger of monster. (lower is better.)
		/// </summary>
		public int Hunger
		{
			get { return hunger; }
			set
			{
				if (value > 100) { hunger = 100; }
				else if (value < 0) { hunger = 0; }
				else { hunger = value; }
			}
		}

		/// <summary>
		/// date and time of monsters birth.
		/// </summary>
		public int DateOfBirth { get; set; }

		//TODO - turn this into datetime format later.
	}
}
