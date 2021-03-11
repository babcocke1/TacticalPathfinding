using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    // number of nodes
    public List<Connection> connections = new List<Connection>();
    public Node[] nodes;

    

    public List<Connection> getConnections(Node from)
    {
        List<Connection> connectionList = new List<Connection>();
        foreach(Connection connection in connections) 
        {
            if (connection.from == from)
                connectionList.Add(connection);
        }
        return connectionList;
        
    }

    public void buildGraph()
    {

        foreach (Node from in nodes)
        {
            Debug.Log(from.name);
            foreach (Node to in from.connectedTo)
            {
                connections.Add(new Connection(from, to)); 
            }
        }
    }
    public class Connection
    {
        public Node from;
        public Node to;
        public Connection(Node from, Node to)
        {
            this.from = from;
            this.to = to;
        }
        public float getCost()
        {
            
            return to.costScaler * (from.transform.position - to.transform.position).magnitude;
        }

    }

}
