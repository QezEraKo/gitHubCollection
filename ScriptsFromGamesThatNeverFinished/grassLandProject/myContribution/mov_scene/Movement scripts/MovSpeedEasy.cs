using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovSpeedEasy : MonoBehaviour
{
   

    


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //Here we want to check if the player wants to move on each update frame.
        Move();
    }
    private void Move()
    {
        
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            //if it is, we move the transforms position to the "Right"
            transform.position += Vector3.right;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            //if it is, we move the transforms position to the "Left"
            transform.position += Vector3.left;
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            //if it is, we move the transforms position "Forward"
            transform.position += Vector3.forward;
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            //if it is, we move the transforms position "Backwards"
            transform.position += Vector3.back;
        }
    }
}

