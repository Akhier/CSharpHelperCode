﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDijkstraAlgorithm
{
    public class Vector2D {
        public const int INFINITY = -1;
        public int X, Y, AggregateCost;
        private int _vectorID;
        public bool Deadend, Visited;
        private static int _vectorIDCount = 0;
        public Edge EdgeWithLowestCost;
        public int VectorID {
            get { return _vectorID; }
        }
        public Vector2D(int x, int y, bool deadend) {
            Visited = false;
            X = x;
            Y = y;
            Deadend = deadend;
            AggregateCost = INFINITY;
            _vectorID = ++_vectorIDCount;
            EdgeWithLowestCost = null;
        }
        public override string ToString() {
            return "Vector ID: " + _vectorID + " X: " + X + " Y: " + Y + ";";
        }
    }
}
