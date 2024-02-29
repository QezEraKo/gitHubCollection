using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirghtInteraction1 : MonoBehaviour
{

    private GameObject interactingObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider interactingObject)
    {
        
        if (interactingObject.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
        //SceneManager.LoadScene(2);
    }
    
}
