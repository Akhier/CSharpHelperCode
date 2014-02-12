using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDijkstraAlgorithm
{
    class Edge {
        public int Cost, EdgeID;
        public static int EdgeIDCount = 0;
        public Vector2D PointA, PointB;
    }
}
