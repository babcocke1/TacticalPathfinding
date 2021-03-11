using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : SteeringBehavior
{
    public Kinematic character;
    float maxAcceleration = 1f;

    public Kinematic[] targets;

    // the threshold to take action
    float threshold = 5f; // 5

    // the constant coefficient of decay for the inverse square law
    float decayCoefficient = 100f;

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        bool close = false;

        foreach (Kinematic target in targets)
        {
            Vector3 direction = character.transform.position - target.transform.position;
            float distance = direction.magnitude;

            if (distance < threshold)
            {
                // calculate the strength of repulsion
                close = true;
                float strength = Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);
                direction.Normalize();
                result.linear += strength * direction;
            }
        }
        /* This code is needed to stop the separator from moving after it is no longer close.
         * My understanding is in a game you would not want this if statement as the character would have its own movement ai
         * and the separation would act as a modifier to that movement ai. However, I added it here so the separator
         * stopped moving when it is >5 distance away from all other objects.
         * I used the opposite of the linearVelocity because result.linear is incremented on to the current velocity, therefore
         *using a new Vector 3(0,0,0) would have no affect howevwer this implementation effectively stops the separator.
         */ 
         
        if (!close)
            result.linear = -1 * character.linearVelocity;
        

        return result;

    }
}
