using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class FiringSolution
{

	public Nullable<Vector3> calculateFiringSolution(Vector3 start, Vector3 end, float muzzleV, Vector3 gravity)
	{
		float time0;
		float time1;
		float ttt;
		// Calculate the vector from the target back to the start
		Vector3 delta = end - start;
		// Calculate the real-valued a,b,c coefficients of a conventional
		// quadratic equation
		float a = Vector3.Dot(gravity, gravity);
		float b = -4 * (Vector3.Dot(gravity, delta) + muzzleV * muzzleV);
		float c = 4 * Vector3.Dot(delta, delta);

		// Check for no real solutions
		if (4 * a * c > b * b)
			return null;

		// Find the candidate times
		time0 = Mathf.Sqrt((-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a));
		time1 = Mathf.Sqrt((-b - Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a));

		// Find the time to target
		if (time0 < 0)
		{
			if (time1 < 0)
			{
				// We have no valid times
				return null;
			}
			else
			{
				ttt = time1;
			}
		}
		else
		{
			if (time1 < 0)
			{
				ttt = time0;
			}
			else
			{
				ttt = Mathf.Max(time0, time1);
			}
			// Return the firing vector
			
		}
		return (2 * delta - gravity * ttt * ttt) / (2 * muzzleV * ttt);
	}

}