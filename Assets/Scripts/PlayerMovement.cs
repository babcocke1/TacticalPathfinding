using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    // Start is called before the first frame update
    public float sidewaysVelocity = 1.0f;
    public float forwardVelocity = 1.0f;
    public float x, y, z;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector3.forward * Time.deltaTime *200f, ForceMode.VelocityChange);
        //rb.AddForce(Vector3.left * rb.velocity.x, ForceMode.VelocityChange);
        //rb.AddForce(Vector3.back * rb.velocity.z, ForceMode.VelocityChange);
        if (Input.GetKey("w"))
        {
            rb.AddForce(Vector3.forward * forwardVelocity, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector3.left * sidewaysVelocity, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(Vector3.back * sidewaysVelocity, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector3.right * sidewaysVelocity, ForceMode.VelocityChange);
        }
    }
}