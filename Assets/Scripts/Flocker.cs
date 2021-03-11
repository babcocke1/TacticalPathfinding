using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flocker : Kinematic
{
    Flocking myMoveType;
    LookWhereGoing myRotateType;
    public Kinematic character;
    public SteeringBehavior[] behaviors = new SteeringBehavior[3];
    public float[] weights = new float[3];
    public Kinematic[] flockMates = new Kinematic[4];
    //public GameObject[] wayPoints = new GameObject[4];
    public Kinematic Leader;
    public Cohesion c = new Cohesion();
    public Separation s = new Separation();
    public MatchVelocity f = new MatchVelocity();
    // Start is called before the first frame update
    void Start()
    {
        f.character = character;
        c.character = character;
        s.character = character;
        c.groupMates = flockMates;
        s.targets = flockMates;
        f.target = Leader;
        myMoveType = new Flocking();
        myMoveType.character = character;
        myMoveType.flockmates = flockMates;
        myMoveType.weights[0] = weights[0];
        myMoveType.weights[1] = weights[1];
        myMoveType.weights[2] = weights[2];


        myMoveType.behaviors[0] = f;
        myMoveType.behaviors[1] = c;
        myMoveType.behaviors[2] = s;



        myRotateType = new LookWhereGoing();
        myRotateType.character = character;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.linear.y = 0f;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}
