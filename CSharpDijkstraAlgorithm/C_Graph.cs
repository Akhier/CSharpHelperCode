using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDijkstraAlgorithm
{
    class Graph {
        private Vector2D _sourceNode;
        private List<Vector2D> _listOfNodes;
        private List<Edge> _listOfEdges;
        public List<Vector2D> AllNodes {
            get { return _listOfNodes; }
        }
        public Vector2D SourceVector {
            get { return _sourceNode; }
            set {
                for (int i = 0; i < _listOfNodes.Count; i++) {
                    if (_listOfNodes[i] == value) {
                        _sourceNode = value;
                        break;
                    }
                }
            }
        }
    }
}
