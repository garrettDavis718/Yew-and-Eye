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
		/// <summary>
		/// Monster object. 
		/// </summary>
		/// <param name="name">user-given name.</param>
		/// <param name="animations">animations for given monster.</param>
		/// <param name="health">current level of health of monster. (higher is better.)</param>
		/// <param name="mood">current mood of monster. (higher is better.)</param>
		/// <param name="hunger">current hunger of monster. (lower is better.)</param>
		/// <param name="dateOfBirth">date and time of monsters birth.</param>

		public Monster(string name,
					   AnimationSet animations,
					   int health,
					   int mood,
					   int hunger,
					   DateTime dateOfBirth)
		{
			Name = name;
			Animations = animations;
			Health = health;
			Mood = mood;
			Hunger = hunger;
			DateOfBirth = dateOfBirth;
			
		}

		/// <summary>
		/// user-given name.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// animations for given monster.
		/// </summary>
		public AnimationSet Animations { get; set; }

		/// <summary>
		/// current level of health of monster. (higher is better.)
		/// </summary>
		public int Health 
		{
			get { return Health; }
			set
			{
				if (value > 100) { Health = 100; }
				else if (value < 0) { Health = 0; }
				else { Health = value; }
			}
		}

		/// <summary>
		/// current mood of monster. (higher is better.)
		/// </summary>
		public int Mood
		{
			get { return Mood; }
			set
			{
				if (value > 100) { Mood = 100; }
				else if (value < 0) { Mood = 0; }
				else { Mood = value; }
			}
		}

		/// <summary>
		/// current hunger of monster. (lower is better.)
		/// </summary>
		public int Hunger
		{
			get { return Hunger; }
			set
			{
				if (value > 100) { Hunger = 100; }
				else if (value < 0) { Hunger = 0; }
				else { Hunger = value; }
			}
		}

		/// <summary>
		/// date and time of monsters birth.
		/// </summary>
		public DateTime DateOfBirth { get; }
	}
}
