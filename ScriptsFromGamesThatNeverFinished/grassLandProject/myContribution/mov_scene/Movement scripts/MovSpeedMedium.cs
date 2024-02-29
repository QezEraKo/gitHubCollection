using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSpeedMedium : MonoBehaviour
{
    [SerializeField] private float backBoundary = -2f;
    [SerializeField] private float forwardBoundary = 2f;
    private float movementSpeed = 15f;

    //refrence to the RigidBody from the player as "rb"
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject thePlayer;
    //refrence to cube witch will indicate walking direction
    [SerializeField] private GameObject walkingDirection;
    //Sprite list

    
    [SerializeField] private List<Sprite> spriteListplayer;
    #region heroSprite
    [SerializeField] private SpriteRenderer mySpriteRenderer;
    [SerializeField] private List<Sprite> heroSpriteList;


    #endregion
    #region arrow locations
    //arrow location refrence
    [SerializeField] private GameObject rightarrow;
    [SerializeField] private GameObject leftarrow;
    [SerializeField] private GameObject uparrow;
    [SerializeField] private GameObject downarrow;
    #endregion
    //Rays
    [SerializeField] private int rayLength = 2;
    //position of this object
    public Transform groundPosition;


    [SerializeField] private Vector3 offsett;

    //bools
    #region Bools

    bool walkingRightImage = false;
    bool walkingLeftImage = false;
    bool groundClose = true;
    bool idle = true;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        offsett = new Vector3(0, 1.2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CastRay2();

        Indicator(); //input for bool activation
        IndicatorRelease();
    }

    // We use "FixedUpdate" given it is a better update method for physics. 
    //ideally we use inputs in "update" and physics in "fixedUpdate" unlike what I do here. 
    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");


        Vector3 movement = new Vector3(Horizontal, 0.0f, Vertical).normalized;
        rb.velocity = movement * movementSpeed;

        //boolactivation(); // bool activation
    }


    private void boolactivation()
    {
        if (walkingLeftImage)
        {
            //leftarrow.GetComponent<SpriteRenderer>().sprite = spriteListplayer[0];
            //rightarrow.GetComponent<SpriteRenderer>().sprite = null;
        }
        //--------------------------------------------------------------------------------//
        if (walkingRightImage)
        {
            //rightarrow.GetComponent<SpriteRenderer>().sprite = spriteListplayer[0];
            //leftarrow.GetComponent<SpriteRenderer>().sprite = null;
        }
        //-----------------------------------------------------------------------------------//
        if (idle)
        {
            rightarrow.GetComponent<SpriteRenderer>().sprite = null;
            leftarrow.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            Debug.Log("idle is false");
            idle = false;
        }
    }

    #region Raycast
    private void CastRay2()
    {
        //Raycast variable will be stored in rayHit
        RaycastHit rayHit;
        //Cast floatingRay. A new ray from this transforms position. in the "downwards vector" direction.
        Ray floatingRay = new Ray(transform.position, Vector3.down);
        //DRAW a visible line using the same variables as in floatingRay, times the RAY distance.
        Debug.DrawRay(transform.position, Vector3.down * rayLength);

        if (groundClose)
        {
            //if "floatingRay(playerposition and direction down) gets casted, in this instance allso have the first object hit stored as "rayHit" and have the lenght of the ray be "rayLenght" long. then do 
            if (Physics.Raycast(floatingRay, out rayHit, rayLength))
            {
                //if "rayHit" object has tag "Enviorment" then
                if (rayHit.collider.tag == "Enviorment")
                {
                    //set Player position to (player X, Raycast hit-positon Y, Player Z) + offsett in Y;
                    transform.position = (new Vector3(transform.position.x, rayHit.point.y, transform.position.z) + offsett);
                    //do freeze player function
                    FreezePlayerPos();
                }
            }
        }
    }
    #endregion
    //Freeze player function
    private void FreezePlayerPos()
    {
        //freeze position Y
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        //freeze all positions equal to "true"
        rb.freezeRotation = true;
    }
    private void Indicator()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            uparrow.GetComponent<SpriteRenderer>().sprite = spriteListplayer[0];
            mySpriteRenderer.sprite = heroSpriteList[2];
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            leftarrow.GetComponent<SpriteRenderer>().sprite = spriteListplayer[0];
            mySpriteRenderer.sprite = heroSpriteList[1];
            mySpriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            downarrow.GetComponent<SpriteRenderer>().sprite = spriteListplayer[0];
            mySpriteRenderer.sprite = heroSpriteList[2];
            mySpriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rightarrow.GetComponent<SpriteRenderer>().sprite = spriteListplayer[0];
            mySpriteRenderer.sprite = heroSpriteList[1];
        }
    }

    private void IndicatorRelease()
    { 
            if (Input.GetKeyUp(KeyCode.W))
            {
                uparrow.GetComponent<SpriteRenderer>().sprite = null;
                mySpriteRenderer.sprite = heroSpriteList[0];

            }

            if (Input.GetKeyUp(KeyCode.A))
            {
               leftarrow.GetComponent<SpriteRenderer>().sprite = null;
            mySpriteRenderer.sprite = heroSpriteList[0];
            mySpriteRenderer.flipX = false;
            }
            
            if (Input.GetKeyUp(KeyCode.S))
            {
               downarrow.GetComponent<SpriteRenderer>().sprite = null;
               mySpriteRenderer.sprite = heroSpriteList[0];
               mySpriteRenderer.flipX = false;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
               rightarrow.GetComponent<SpriteRenderer>().sprite = null;
            mySpriteRenderer.sprite = heroSpriteList[0];
            }
     }
}
