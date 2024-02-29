using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    [SerializeField] private GridParameters gridParameters;

    [SerializeField] private Transform addSpot;
    [SerializeField] private Transform removeSpot;

    // Start is called before the first frame update
    void Awake()
    {
        gridParameters.AddToPositionLists(addSpot.position, removeSpot.position);
        //gridParameters.AddToRemovePositionsList(removeSpot.position);
    }


}
