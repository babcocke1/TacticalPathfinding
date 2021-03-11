using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class DjikstraFollower : Kinematic
{
    public Node[] graphNode = new Node[8];
    public Node start;
    public Node goal;
    Graph myGraph;
    Dijkstra d = new Dijkstra(); 

    FollowPath myMoveType;
    LookWhereGoing myRotateType;


    GameObject[] myPath = new GameObject[5];
    List<Graph.Connection> path;
    // Start is called before the first frame update
    void Start()
    {
        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;

        Graph myGraph = new Graph();
        myGraph.nodes = graphNode;  
        myGraph.buildGraph();
        path = d.pathfindDijkstra(myGraph, start, goal);
        path.Add(new Graph.Connection(goal, start));
        myMoveType = new FollowPath();
        myMoveType.targets = path;
        myMoveType.character = this;
    }

    // Update is called once per frame
    protected override void Update()
    {
        //reload when done
        if((this.transform.position - path[path.Count-1].from.nodeObject.transform.position).magnitude < .5f)
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
        steeringUpdate = new SteeringOutput();
        steeringUpdate.angular = myRotateType.getSteering().angular;
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }

}
