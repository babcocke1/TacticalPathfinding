using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public float speed = 1.0f;
    public Color[] colors = new Color[7];
    public Color cur;
    public Color next;
    public int index;
    public int nextIndex;
    float startTime;
    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float t = (Time.time - startTime) * speed;
        GetComponent<Renderer>().material.color = Color.Lerp(colors[index], colors[nextIndex], t);
        if(t >= 1)
        {
            startTime = Time.time;
            index++;
            if(index == colors.Length)            
                index = 0;
            nextIndex++;
            if(nextIndex == colors.Length)
            {
                nextIndex = 0;
            }
        }
    }
}
