using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DigiviceEmulatorLib
{
	/// <summary>
	/// monster class.
	/// </summary>
	public static class Monster
	{
		/// <summary>
		/// monster attributes. 
		/// </summary>
		public enum Attributes
		{
			name,
			animation,
			type,
			state,
			health,
			mood,
			hygiene,
			date_of_birth,
		}

		/// <summary>
		/// monster types. corresponds to bestiary entries.
		/// </summary>
		public enum Types
		{
			Faunamon,
		}

		/// <summary>
		/// state of monster. used by animation classes. 
		/// </summary>
		public enum States
		{
			idle,
			eating,
			playing,
			dancing
		}

		/// <summary>
		/// restrict input to between 2 numbers. 
		/// </summary>
		/// <param name="input">input to be evaluated.</param>
		/// <returns>returns input restricted between min and max values.</returns>
		private static int RestrictInputRange(int input)
		{
			int maxValue = 100,
				minValue = 0,
				restrictedInt;
			if (input > maxValue)
			{
				restrictedInt = maxValue;
			}
			else if (input < minValue)
			{
				restrictedInt = minValue;
			}
			else
			{
				restrictedInt = input;
			}
			return restrictedInt;
		}

		/// <summary>
		/// user-given name.
		/// </summary>
		public static string Name
		{
			get 
			{
				string val = "";
				if (DatabaseOps.OpenConnection())
				{
					val = DatabaseOps.GetMonsterAttribute<string>(Monster.Attributes.name);
					DatabaseOps.CloseConnection();
				}
				return val; 
			}
			set 
			{ 
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetMonsterAttribute(Monster.Attributes.name, value);
					DatabaseOps.CloseConnection();
				}
			}
		}

		/// <summary>
		/// animations for given monster.
		/// </summary>
		public static AnimationSet Animations
		{
			get
			{
				AnimationSet val = null;
				if (DatabaseOps.OpenConnection())
				{
					val = JsonSerializer.Deserialize<AnimationSet>(DatabaseOps.GetMonsterAttribute<string>(Monster.Attributes.animation));
					DatabaseOps.CloseConnection();
				}
				return val;
			}
			set
			{
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetMonsterAttribute(Monster.Attributes.animation, JsonSerializer.Serialize(value));
					DatabaseOps.CloseConnection();
				}
			}
		}

		/// <summary>
		/// type of monster. corresponds to bestiary entries.
		/// </summary>
		public static Types Type
		{
			get
			{
				Types val = 0;
				if (DatabaseOps.OpenConnection())
				{
					val = (Monster.Types)DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.type);
					DatabaseOps.CloseConnection();
				}
				return val;
			}
			set
			{
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetMonsterAttribute(Monster.Attributes.type, (int)value);
					DatabaseOps.CloseConnection();
				}
			}
		}

		/// <summary>
		/// current state of monster. used by animation classes.
		/// </summary>
		public static States State
		{
			get
			{
				States val = 0;
				if (DatabaseOps.OpenConnection())
				{
					val = (Monster.States)DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.state);
					DatabaseOps.CloseConnection();
				}
				return val;
			}
			set
			{
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetMonsterAttribute(Monster.Attributes.state, (int)value);
					DatabaseOps.CloseConnection();
				}
			}
		}

		/// <summary>
		/// current mood of monster. (higher is better.)
		/// </summary>
		public static int Health
		{
			get
			{
				int val = 0;
				if (DatabaseOps.OpenConnection())
				{
					val = DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.health);
					DatabaseOps.CloseConnection();
				}
				return val;
			}
			set
			{
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetMonsterAttribute(Monster.Attributes.health, RestrictInputRange(value));
					DatabaseOps.CloseConnection();
				}
			}
		}

		/// <summary>
		/// current hygiene of monster. (higher is better.)
		/// </summary>
		public static int Mood
		{
			get
			{
				int val = 0;
				if (DatabaseOps.OpenConnection())
				{
					val = DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.mood);
					DatabaseOps.CloseConnection();
				}
				return val;
			}
			set
			{
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetMonsterAttribute(Monster.Attributes.mood, RestrictInputRange(value));
					DatabaseOps.CloseConnection();
				}
			}
		}

		/// <summary>
		/// current level of hygiene. (higher is better.)
		/// </summary>
		public static int Hygiene
		{
			get
			{
				int val = 0;
				if (DatabaseOps.OpenConnection())
				{
					val = DatabaseOps.GetMonsterAttribute<int>(Monster.Attributes.hygiene);
					DatabaseOps.CloseConnection();
				}
				return val;
			}
			set
			{
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetMonsterAttribute(Monster.Attributes.hygiene, RestrictInputRange(value));
					DatabaseOps.CloseConnection();
				}
			}
		}

		/// <summary>
		/// date and time of monsters birth.
		/// </summary>
		public static DateTime DateOfBirth
		{
			get
			{
				DateTime val = DateTime.UtcNow;
				if (DatabaseOps.OpenConnection())
				{
					val = DatabaseOps.GetMonsterAttribute<DateTime>(Monster.Attributes.date_of_birth);
					DatabaseOps.CloseConnection();
				}
				return val;
			}
			set
			{
				if (DatabaseOps.OpenConnection())
				{
					DatabaseOps.SetMonsterAttribute(Monster.Attributes.date_of_birth, value);
					DatabaseOps.CloseConnection();
				}
			}
		}
	}
}
