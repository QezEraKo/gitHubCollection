using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{

    public int moveSpeed;

    public GameObject SlimeManager;
    public Rigidbody2D rb;
    public GameObject collidedObject;

    public string colTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {

        float directionX = Input.GetAxis("Horizontal");
        float directionY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(directionX * moveSpeed, directionY * moveSpeed);

    }

    void OnCollisionEnter2d(Collision2D col)
    {
        //colTag = col.gameObject.name;
        //Debug.Log("collidedObject at all");

        //if (col.gameObject.name == "GreenSlimeFarm")
        //{
        //    Debug.Log("collided");
        //    SlimeManager.GetComponent<SlimeManager>().BuyGreen();
        //}

        //if (col.gameObject.tag == "BlueFarm")
        //{
        //    Debug.Log("collided");
        //    SlimeManager.GetComponent<SlimeManager>().BuyBlue();
        //}

        //if (col.gameObject.tag == "RedFarm")
        //{
        //    SlimeManager.GetComponent<SlimeManager>().BuyRed();
        //}

        //if (col.gameObject.tag == "YellowFarm")
        //{
        //    SlimeManager.GetComponent<SlimeManager>().BuyYellow();
        //}


    }
}
