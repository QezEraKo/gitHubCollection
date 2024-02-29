using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    //makes a list for sprites, for our NPC's
    [SerializeField] public List<Sprite> npcList;
    //Refrence to Gameobject where first NPC will be
    [SerializeField] private GameObject npcSpot1ref;  // first NPC
    //Refrence a transform as "LookAtMyCamera"
    private Transform LookAtMyCamera;
    [SerializeField] private GameObject thePlayer;
    private Transform thePlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        //Gives the gameobject "npcSpot1Red the first sprite image from npcList
        npcSpot1ref.GetComponent<SpriteRenderer>().sprite = npcList[0];
        //LookAtMyCamera now refrences "cameraFocusPoint"
        LookAtMyCamera = GameObject.Find("CameraFocusPoint").transform;
        //thePlayerTransform = GameObject.Find("Player 1").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        npcSpot1ref.transform.LookAt(LookAtMyCamera);
    }
}
