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
			public Node(int X, int Z) { Value = X + Z * sizeX; }
			public int node;
			public int x = -1;
			public int z = -1;
			public int Value { get { return node; }
				set
				{
					int _z =  value / sizeX;
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
			public int ProximityTo(Node node2)
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
			public MapProximityObject(string obj_text, NumericOffset no)
			{
				Text = obj_text;
				if (no == null) this.no = NumericOffset.Invalid;
				else this.no = no;
			}
			public MapProximityObject(string obj_text, Node home, Node obj, NumericOffset no = null)
			{
				node = obj;
				home_node = home;
				(DeltaX, DeltaZ) = home.DistanceTo(obj);
				Text = $"{obj_text} @ ({DeltaX},{DeltaZ}) : ";
				Proximity = DeltaX * DeltaX + DeltaZ * DeltaZ;
				if (no == null) this.no = NumericOffset.Invalid;
				else this.no = no;
			}
			public string Text { get; set; }
			public Node? node { get; internal set; }
			public Node? home_node { get; internal set; }
			public int DeltaX { get { return node.X - home_node.X; } set { node.node = home_node.node + value; } } // left/right
			public int DeltaY { get; set; }  // surface/underground
			public int DeltaZ { get { return node.Z - home_node.Z; } set { node.node = home_node.node + value * sizeX; } } // left/right
			public int Proximity { get; internal set; } // square of distance
			public NumericOffset? no;
			public List<MapProximityObject>? spawns = null;
			// TODO: finish direction octants. They're intended to be mutually-exclusive with non-cardinals slightly larger than cardinals.
			public bool N { get { return DeltaZ >= 0 && Math.Abs(DeltaX / DeltaZ) <= 0.5; } }
			public bool S { get { return DeltaZ <= 0 && Math.Abs(DeltaX / DeltaZ) <= 0.5; } }
			public bool E { get { return DeltaX >= 0 && Math.Abs(DeltaZ / DeltaX) <= 0.5; } }
			public bool W { get { return DeltaX >= 0 && Math.Abs(DeltaZ / DeltaX) <= 0.5; } }
			public bool NE { get { return DeltaX > 0 && DeltaZ > 0 && !N && !E; } }
			public bool SW { get { return DeltaX < 0 && DeltaZ < 0 && Math.Abs(DeltaX / DeltaZ) <= 2; } }
			public bool SE { get { return DeltaX > 0 && Math.Abs(DeltaZ / DeltaX) <= 2; } }
			public bool NW { get { return DeltaX > 0 && Math.Abs(DeltaZ / DeltaX) <= 2; } }

			internal MapProximityObject Spawn(string text, NumericOffset? no)
			{
				var mpo = new MapProximityObject(text, no);
				mpo.node = node;
				//mpo.DeltaX = DeltaX;
				//mpo.DeltaY = DeltaY;
				//mpo.DeltaZ = DeltaZ;
				mpo.Proximity = Proximity;
				if (spawns == null) spawns = new();
				spawns.Add(mpo);

				return mpo;
			}
		}
	}
}
