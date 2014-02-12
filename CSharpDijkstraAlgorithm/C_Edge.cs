using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDijkstraAlgorithm
{
    class Edge {
        public int Cost;
        private int _edgeID;
        private static int _edgeIDCount = 0;
        private Vector2D _pointA, _pointB;
        public int EdgeID {
            get { return _edgeID; }
        }
        public Vector2D PointA {
            get { return _pointA; }
        }
        public Vector2D PointB {
            get { return _pointB; }
        }
    }
}
