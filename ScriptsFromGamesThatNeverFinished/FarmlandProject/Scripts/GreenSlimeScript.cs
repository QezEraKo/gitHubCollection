using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlimeScript : MonoBehaviour
{
    public GameObject SlimeManager;


    void OnCollisionEnter2d(Collision2D col)
    {
        Debug.Log("collidedObject at all");


        //SlimeManager.GetComponent<SlimeManager>().BuyGreen();
        
    }

    }
