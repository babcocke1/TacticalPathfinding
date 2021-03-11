using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flocking : SteeringBehavior
{
    public Kinematic character;
    public Kinematic[] flockmates;
    public GameObject[] wayPoints;
    public SteeringBehavior[] behaviors = new SteeringBehavior[3];
    public float[] weights = new float[3];
    
    //public Flocking(SteeringBehavior[] b, float[] w)
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        Debug.Log("hi");
    //        behaviors[i].behavior = b[i];
    //        behaviors[i].weight = w[i];
    //    }
    //}
    public float maxAcceleration = 3f;
    public float maxRotation;
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        result.linear = Vector3.zero;
        for (int i = 0; i < 3; i++)
        {
            result.linear += weights[i] * behaviors[i].getSteering().linear;
            //Debug.Log(behaviors[i].getSteering().linear);
            //Debug.Log(result.linear);
            //result.angular += b.weight * b.behavior.getSteering().angular;
        }
        Debug.Log(result.linear);
        if (result.linear.magnitude > maxAcceleration)
            result.linear = result.linear.normalized * maxAcceleration;
        Debug.Log(result.linear);
        result.angular = Mathf.Max(0f, maxRotation);
        return result;
    }
   
}
