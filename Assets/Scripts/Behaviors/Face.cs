using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    // TODO: override Align's getTargetAngle to face the target instead of matching it's orientation
    public override float getTargetAngle()
    {
        // --- replace me ---
        float targetAngle = 100f;
        Vector3 direction;
        direction = target.transform.position - character.transform.position;


        if (direction.magnitude < 0.001) 
        {
            return character.transform.eulerAngles.y;
        } 
        else
        {
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        }
        return targetAngle;
    }
}
