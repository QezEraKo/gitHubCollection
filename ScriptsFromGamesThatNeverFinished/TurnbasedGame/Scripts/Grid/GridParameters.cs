using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridParameters : MonoBehaviour
{

    private bool firstCounting = false;
    private bool firstCountingdone = false;


    private List<Vector3> addPositionsList = new List<Vector3>();
    private List<Vector3> removePositionsList = new List<Vector3>();

    private int listCount;
    private bool listSent = false;
    [SerializeField] private int heightBlockAmount;

    public void AddToPositionLists(Vector3 position1, Vector3 position2)
    {
        if (firstCounting == false)
        {
            firstCounting = true;
        }

        addPositionsList.Add(position1);
        removePositionsList.Add(position2);

    }

    //    public void AddToRemovePositionsList(Vector3 position)
    //    {
    //   removePositionsList.Add(position);

    // }

    private void Update()
    {
        if (firstCounting == true)
        {
            if (firstCountingdone == false)
            {
                Debug.Log("start of forLoop!!");
                firstCountingdone = true;
            }



        }

        listCount = removePositionsList.Count;

        if ((listCount == heightBlockAmount) && (listSent == false))
        {

            for (int index = 0; index < listCount; index++)
            {

                LevelGrid.Instance.LevelGridPositionLists(addPositionsList[index], removePositionsList[index], listCount);
            }

            LevelGrid.Instance.CreateGridSystem();
            listSent = true;
        }


    }


}
