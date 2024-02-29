using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSpeedMedium2 : MonoBehaviour
{
    //refrence to the rigidbody component on the player
    public Rigidbody rb;
    public float speed;

    //vectors in each direction
    Vector3 forwardVector;
    Vector3 backVector;
    Vector3 leftVector;
    Vector3 rightVector;
    


    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
        
        forwardVector = new Vector3(0.0f, 0.0f, 10.0f);
        backVector = new Vector3(0.0f, 0.0f, -10.0f);
        leftVector = new Vector3(-10.0f, 0.0f, 0.0f);
        rightVector = new Vector3(10.0f, 0.0f, 0.0f);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            //velocity in units per second.
              rb.velocity = forwardVector * speed * Time.deltaTime;
           // rb.velocity = new Vector3(speed, 0.0f, 0.0f);
            // rb.velocity = new Vector3(0, 0, 10 * Time.deltaTime);
            //body.velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;

            //if it is, we move the transforms position to the "Right"
            //transform.position += Vector3.right;
        }
    
        if (Input.GetKeyDown(KeyCode.S))
        {
            //velocity in units per second.
            rb.velocity = backVector * speed * Time.deltaTime;

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //velocity in units per second.
            rb.velocity = leftVector * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //velocity in units per second.
            rb.velocity = rightVector * speed * Time.deltaTime;
    
        }
    
    }
}
