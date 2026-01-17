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
		public static int sizeX;
		public static int sizeY;
		public static int sizeZ;
		public class Node
		{
			public Node(int node_) { Value = node_; }
			public int node;
			public int x = -1;
			public int z = -1;
			public int Value { get { return node; }
				set
				{
					int _z =  node / sizeX;
					if (_z >= sizeZ) throw new Exception("Node Value out of range.");

					node = value;
					x = node % sizeX;
					z = _z;
				}
			}
			public int X { get { return x; } }
			public int Z { get { return z; } }
			public (int, int) Coords { get { return (x, z); } }

			public object PrintCoords { get { return $"({x,-3},{z,-3})"; } }

			public (int dX, int dZ) DistanceTo(Node node2)
			{
				return (node2.x - x, node2.z - z);
			}
			public int Proximity(Node node2)
			{
				var distance = DistanceTo(node2);
				return distance.dX * distance.dX + distance.dZ * distance.dZ;
			}
		}
		public static (int X, int Z) Coords(int node)
		{
			int x = node % sizeX;
			int z = node / sizeX;
			return (x, z);
		}
		public static (int dX, int dZ) Distance2(int node1, int node2)
		{
			var c1 = Coords(node1);
			var c2 = Coords(node2);
			return (c2.Item1 - c1.Item1, c2.Item2 - c1.Item2);
		}
		public static int Proximity(int node1, int node2)
		{
			var d = Distance2(node1, node2);
			return d.dX * d.dX + d.dZ * d.dZ;
		}
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
