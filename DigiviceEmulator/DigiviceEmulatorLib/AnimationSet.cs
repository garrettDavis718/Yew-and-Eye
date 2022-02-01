using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiviceEmulatorLib
{
	/// <summary>
	/// set of animations to display Monster state. 
	/// </summary>
	public class AnimationSet
	{
		/// <summary>
		/// set of animations to display Monster state.
		/// </summary>
		/// <param name="idle">idle animation.</param>
		/// <param name="eat">eating animation.</param>
		/// <param name="play">playing animation.</param>
		/// <param name="dance">dancing animation. NOTE only 3rd tier monsters can dance.</param>
		public AnimationSet(string[] idle,
							string[] eat,
							string[] play,
							string[] dance)
		{
			Idle = idle;
			Eat = eat;
			Play = play;
			Dance = dance;
		}

		/// <summary>
		/// idle animation.
		/// </summary>
		public string[] Idle { get; }

		/// <summary>
		/// eating animation.
		/// </summary>
		public string[] Eat { get; }

		/// <summary>
		/// playing animation.
		/// </summary>
		public string[] Play { get; }

		/// <summary>
		/// dancing animation.
		/// </summary>
		public string[] Dance { get; }
	}
}
