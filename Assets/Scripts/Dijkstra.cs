using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : Graph
{
    public class NodeRecord
    {
        public Node node;
        public Connection connection;
        public float costSoFar;
    }
    class PathfindingList
    { 
        public List<NodeRecord> nodeRecords = new List<NodeRecord>();

        public NodeRecord smallestElement()
        {
            NodeRecord smallestElement = new NodeRecord();
            smallestElement.costSoFar = Mathf.Infinity;
            foreach(NodeRecord nr in nodeRecords)
            {
                if(nr.costSoFar < smallestElement.costSoFar)
                {
                    smallestElement = nr;
                }
                
            }
            return smallestElement;
        }

        public int length()
        {
            return nodeRecords.Count;
        }

        public bool contains(Node node)
        {
            foreach (NodeRecord nr in nodeRecords)
            {
                if (nr.node == node)
                    return true;
             
            }

            return false;
        }

        public NodeRecord find(Node node)
        {
            foreach (NodeRecord nr in nodeRecords)
            {
                if (nr.node == node)
                {
                    return nr;
                }
            }

            return null;
        }

    }
    public List<Connection> pathfindDijkstra(Graph graph, Node start, Node to)
    {
        int count = 0;
       
        NodeRecord startRecord = new NodeRecord(); 
        startRecord.node = start;
        startRecord.connection = null;
        startRecord.costSoFar = 0f;
        Node endNode = null;
        NodeRecord endNodeRecord = new NodeRecord();
        float endNodeCost;
        List<Connection> output = new List<Connection>();
        PathfindingList open = new PathfindingList();
        open.nodeRecords.Add(startRecord);
        PathfindingList closed = new PathfindingList();
        NodeRecord current = new NodeRecord();

        while (open.length() > 0)
        {

            // Find the smallest element in the open list
            current = open.smallestElement();
            Debug.Log("open.length");
            Debug.Log(open.length());
            Debug.Log("count = ");
            Debug.Log(count);
            Debug.Log("current = " + current);
            Debug.Log("current.node = " + open.smallestElement().node);
           
            count++;
            // If it is the goal node, then terminate
            if (current.node == to) { 
                Debug.Log("success");
                break;
            }
            // Otherwise get its outgoing connections
            connections = graph.getConnections(current.node);

            // Loop through each connection in turn
            foreach (Connection connection in connections)
            {
                endNode = connection.to;
                endNodeCost = current.costSoFar + connection.getCost();
                if (closed.contains(endNode))
                {
                    Debug.Log("continue");
                    Debug.Log("continue");
                    Debug.Log("continue");

                    continue;
                }
                else if (open.contains(endNode))
                {
                    endNodeRecord = open.find(endNode);
                    if (endNodeRecord != null && endNodeRecord.costSoFar < endNodeCost)
                        continue;

                }
                else
                {
                    endNodeRecord = new NodeRecord();
                    endNodeRecord.node = endNode;
                }
                endNodeRecord.costSoFar = endNodeCost;
                endNodeRecord.connection = connection;

                if (!open.contains(endNode))
                {
                    open.nodeRecords.Add(endNodeRecord);
                }
            }

            open.nodeRecords.Remove(current);
            closed.nodeRecords.Add(current);
            Debug.Log("open.length");
            Debug.Log("open.length");
            Debug.Log("open.length");
            Debug.Log("open.length");

            Debug.Log(open.length());

        }
        //Debug.Log(to);
        //Debug.Log(current.node);

        if (current.node != to)
        {
            return null;
        }
        else
        {
            while (current.node != start)
            {
                output.Add(current.connection);
 
                current = closed.find(current.connection.from);
            }
        }
        output.Reverse();
        return output;
    }


}
