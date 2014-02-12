﻿using System;
using System.Collections.Generic;

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
        public Graph() {
            _listOfEdges = new List<Edge>();
            _listOfNodes = new List<Vector2D>();
            _sourceNode = null;
        }
        private void reset() {
            for (int i = 0; i < _listOfNodes.Count; i++) {
                _listOfNodes[i].Visited = false;
                _listOfNodes[i].AggregateCost = Vector2D.INFINITY;
                _listOfNodes[i].EdgeWithLowestCost = null;
            }
        }
        public void addEdge(Edge edge) {
            _listOfEdges.Add(edge);
            this.reset();
        }
        public void addVector(Vector2D node) {
            _listOfNodes.Add(node);
            this.reset();
        }
        private List<Vector2D> getListOfVisitedNodes() {
            List<Vector2D> listOfVisitedNodes = new List<Vector2D>();
            foreach (Vector2D node in _listOfNodes) {
                if (node.Visited) {
                    listOfVisitedNodes.Add(node);
                }
            }
            return listOfVisitedNodes;
        }
        private bool moreVisitedNodes() {
            return getListOfVisitedNodes().Count < _listOfNodes.Count;
        }
        private void performCalculationForAllNodes() {
            Vector2D currentNode = _sourceNode;
            currentNode.Visited = true;
            do {
                Vector2D nextBestNode = null;
                foreach (Vector2D visitedNode in this.getListOfVisitedNodes()){
                    foreach (Edge connectedEdge in this.getConnectedEdges(visitedNode)){
                        if (connectedEdge.getOtherVector(visitedNode).AggregateCost == Vector2D.INFINITY || (visitedNode.AggregateCost + connectedEdge.Cost) < connectedEdge.getOtherVector(visitedNode).AggregateCost){
                            connectedEdge.getOtherVector(visitedNode).AggregateCost = visitedNode.AggregateCost + connectedEdge.Cost;
                            connectedEdge.getOtherVector(visitedNode).EdgeWithLowestCost = connectedEdge;
                        }
                        if (nextBestNode == null || connectedEdge.getOtherVector(visitedNode).AggregateCost < nextBestNode.AggregateCost){
                            nextBestNode = connectedEdge.getOtherVector(visitedNode);
                        }
                    }
                }
                currentNode = nextBestNode;
                currentNode.Visited = true;
            } while (this.moreVisitedNodes());
        } 
        public bool calculateShortestPath() {
            bool unreachable = false;
            if (_sourceNode == null) {
                return false;
            }
            this.reset();
            _sourceNode.AggregateCost = 0;
            this.performCalculationForAllNodes();
            if (unreachable) {
                return false;
            }
            return true;
        }
        public List<Vector2D> retrieveShortestPath(Vector2D targetNode) {
            List<Vector2D> shortestPath = new List<Vector2D>();
            if (targetNode == null) {
                throw new InvalidOperationException("The target node is null");
            }
            else {
                Vector2D currentNode = targetNode;
                shortestPath.Add(currentNode);
                while (currentNode.EdgeWithLowestCost != null) {
                    currentNode = currentNode.EdgeWithLowestCost.getOtherVector(currentNode);
                    shortestPath.Add(currentNode);
                }
            }
            shortestPath.Reverse();
            return shortestPath;
        }
        private List<Edge> getConnectedEdges(Vector2D startNode) {
            List<Edge> connectedEdges = new List<Edge>();
            for (int i = 0; i < _listOfEdges.Count; i++) {
                if (_listOfEdges[i].getOtherVector(startNode) != null && !_listOfEdges[i].getOtherVector(startNode).Visited) {
                    connectedEdges.Add((Edge)_listOfEdges[i]);
                }
            }
            return connectedEdges;
        }
    }
}