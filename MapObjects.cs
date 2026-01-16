using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroesOE.JsonBracketMatcher;

namespace HOETool
{
	public class MapObjects
	{
		public class MapProximityObject
		{
			string Text;
			int deltaX; // left/right
			int deltaY;	// surface/underground
			int deltaZ; // down/up
			int proximity; // square of distance
			NumericOffset no;
		}
	}
}
