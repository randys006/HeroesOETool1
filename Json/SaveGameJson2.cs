using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	internal class SaveGameJson2
	{
		// this is the 3rd json blob in the quicksavegame
		public class Rootobject
		{
			public int[] bytes_ { get; set; }
		}
	}
}
