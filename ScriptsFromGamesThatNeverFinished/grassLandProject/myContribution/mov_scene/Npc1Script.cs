using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc1Script : MonoBehaviour
{
    //player reff
    [SerializeField] private GameObject playerRef;
    //bools
    bool triggered = false;


    // Start is called before the first frame update
    void Start()
    {


        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Add Npc Dialoge
            //Add something 
            Debug.Log("You stepped on mi trigger matey");
            triggered = true;
        }
    }






    // Update is called once per frame
    void Update()
    {
        
    }
}
