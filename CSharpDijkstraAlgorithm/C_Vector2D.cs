using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDijkstraAlgorithm
{
    public class Vector2D {
        public const int INFINITY = -1;
        public int X, Y, VectorID, AggregateCost;
        public bool Deadend, Visited;
        public static int VectorIDCount = 0;
        public Edge EdgeWithLowestCost;
        public Vector2D(int x, int y, bool deadend) {
            Visited = false;
            X = x;
            Y = y;
            Deadend = deadend;
            AggregateCost = INFINITY;
            VectorID = ++VectorIDCount;
            EdgeWithLowestCost = null;
        }
        public override string ToString() {
            return "Vector ID: " + VectorID + " X: " + X + " Y: " + Y + ";";
        }
    }
}
