using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour
{
    public List<Node> connectedTo;
    public GameObject nodeObject;
    public float costScaler = 1.0f;

    void Start()
    {
        if(Random.value < .5f)
        {
            costScaler = 5.0f;
            GetComponent<Renderer>().material.color = Color.red; 
        }
        nodeObject.transform.position = nodeObject.transform.position + new Vector3(Random.value - .5f, 0f, Random.value - .5f);
    }
}
