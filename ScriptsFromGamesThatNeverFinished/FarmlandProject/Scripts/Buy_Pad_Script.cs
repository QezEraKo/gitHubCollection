using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Pad_Script : MonoBehaviour
{
    public GameObject slimePen;

    public void OnMouseDown()
    {
        slimePen.GetComponent<Farming_Pen>().BuySlime();
    }
}
