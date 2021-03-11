using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facer : Kinematic
{
    Face myMoveType;
    Align myRotateType;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Face();
        myMoveType.character = this;
        myMoveType.target = myTarget;

        myRotateType = new Align();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}


