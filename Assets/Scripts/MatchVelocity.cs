using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchVelocity : SteeringBehavior
{
    public Kinematic character;
    public Kinematic target;

    protected float maxAcceleration = 100f;

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        Vector3 targetVelocity = target.linearVelocity;
        //get difference in velocity
        Vector3 vDiff = target.linearVelocity - character.linearVelocity;
        //add force to match velocity 2 helps to match better
        result.linear = 1 * vDiff;
        // give full acceleration along this direction
        if (result.linear.magnitude > maxAcceleration)
        {
            result.linear.Normalize();
            result.linear *= maxAcceleration;
        }

        result.angular = 0;
        return result;
    }
}
