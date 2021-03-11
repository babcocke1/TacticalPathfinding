using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : SteeringBehavior
{
    public Kinematic character;
    float maxAcceleration = 1f;

    public Kinematic[] groupMates;

    // the threshold to take action
    float threshold = 5f; // 5

    // the constant coefficient of decay for the inverse square law
    float decayCoefficient = 100f;

    public override SteeringOutput getSteering()
    {
        Vector3 center = character.transform.position;
        SteeringOutput result = new SteeringOutput();
        foreach (Kinematic g in groupMates)
        {

            center += g.transform.position;
            center = center / (groupMates.Length + 1);

            result.linear = maxAcceleration * (center - character.transform.position);
            result.angular = 0;
        }
        /* This code is needed to stop the separator from moving after it is no longer close.
         * My understanding is in a game you would not want this if statement as the character would have its own movement ai
         * and the separation would act as a modifier to that movement ai. However, I added it here so the separator
         * stopped moving when it is >5 distance away from all other objects.
         * I used the opposite of the linearVelocity because result.linear is incremented on to the current velocity, therefore
         *using a new Vector 3(0,0,0) would have no affect howevwer this implementation effectively stops the separator.
         */



        return result;

    }
}
