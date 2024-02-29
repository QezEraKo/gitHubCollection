using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellSlimesScript : MonoBehaviour
{


    public GameObject slimePen;

    public void OnMouseDown()
    {
        slimePen.GetComponent<Farming_Pen>().SellBlob();
    }
}
