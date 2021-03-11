using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Face
{
    
    // Start is called before the first frame update
    float wanderOffset = 5f;
    float wanderRadius= 3f;
    float wanderRate= 1f;
    float wanderOrientation;
    float maxAcceleration = 3f; // 5

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        
        float targetOrientation;
        wanderOrientation += randomBinomial() * wanderRate;
        targetOrientation = wanderOrientation + character.transform.eulerAngles.y;
        Debug.Log("targetOrientation");
        Debug.Log(targetOrientation);
        Debug.Log("asVector()");
        Debug.Log(asVector(targetOrientation));
      



        target.transform.position = character.transform.position +  wanderOffset * asVector(targetOrientation);
        target.transform.position += wanderRadius * asVector(targetOrientation) ;
        result.angular = getTargetAngle();
        result.linear = maxAcceleration * (asVector(character.transform.eulerAngles.y))/ (asVector(character.transform.eulerAngles.y)).magnitude;
        return result;
    }
    public float randomBinomial()
    {
        Debug.Log("randomValue");
        Debug.Log(Random.value- Random.value);
        return Random.value - Random.value;
        

    }
    public Vector3 asVector(float angle)
    {
        Vector3 vectorResult = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        return vectorResult;
    }
    


}
