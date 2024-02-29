using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
//Removing monobehaviour here since we want to use a struct (Can't use struct in monobehaviour)

{



    private int width;
    private int height;
    private int lenght;
    private float cellSize;
    private GridObject[,,] gridObjectArray;

    private List<Vector3> addPositionsList = new List<Vector3>();
    private List<Vector3> removePositionsList = new List<Vector3>();

    private int listCount;

    public GridSystem(int width, int height, int lenght, float cellSize)
    {
        //add int lenght above
        this.width = width;
        this.height = height; //lenght
        this.lenght = lenght;
        this.cellSize = cellSize;


        gridObjectArray = new GridObject[width, height, lenght];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < lenght; z++)
                {
                    GridPosition gridPosition = new GridPosition(x, y, z);       //creates a gridPosition for the current x and z values.
                    gridObjectArray[x, y, z] = new GridObject(this, gridPosition);  // creates new gridObject, and passes inn own refrence to that gridObject, and that gridObjects position.
                    //Debug.DrawLine(GetWorldPosition(gridPosition), GetWorldPosition(gridPosition) + Vector3.right * .2f, Color.white, 1000f);
                }
            }
        }

    }

    public void AddPeramiters(Vector3 add, Vector3 remove, int listcount)
    {
        addPositionsList.Add(add);
        removePositionsList.Add(remove);
        listCount = listcount;
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition) //(GridPosition gridPosition)
    {
        //converts GridPosition into WorldPosition
        return new Vector3(gridPosition.x, gridPosition.y, gridPosition.z) * cellSize;   //vecotr2 would use x,y
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        //converts WorldPosition into GridPosition
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.y / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize)
        );
    }


    public void CreateDebugObject(Transform debugPreFab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < lenght; z++)
                {

                    if (y != 1)
                    {
                        //for (int index = 0; index < listCount; index++)
                        //{
                        //    if (new Vector3(x, y, z) == (removePositionsList[index] / 2))
                        //    {
                        //        return;
                        //    }
                        //}
                        GridPosition gridPosition = new GridPosition(x, y, z); //creates a gridPosition for the current x and z values.
                        Transform debugTransform = GameObject.Instantiate(debugPreFab, GetWorldPosition(gridPosition), Quaternion.identity); // spawn a "gridDebugObject" at this worldposition(2x2 cellsizes), at this rotation
                        GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>(); //gets this gridDebugObjects refrence.
                        gridDebugObject.SetGridObject(GetGridObject(gridPosition));


                        if ((x == 9) && (z == 9))
                        {
                            Debug.Log("forLoop done!");
                        }
                    }

                    else if (y == 1)
                    {
                        for (int index = 0; index < listCount; index++)
                        {
                            if (new Vector3(x, y, z) == (addPositionsList[index] / 2))
                            {
                                GridPosition gridPosition = new GridPosition(x, y, z); //creates a gridPosition for the current x and z values.
                                Transform debugTransform = GameObject.Instantiate(debugPreFab, GetWorldPosition(gridPosition), Quaternion.identity); // spawn a "gridDebugObject" at this worldposition(2x2 cellsizes), at this rotation
                                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>(); //gets this gridDebugObjects refrence.
                                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
                            }
                        }
                    }



                    // if ((x, y, z) == (3, 1, 4))
                    // {
                    //     GridPosition gridPosition = new GridPosition(x, y, z); //creates a gridPosition for the current x and z values.
                    //     Transform debugTransform = GameObject.Instantiate(debugPreFab, GetWorldPosition(gridPosition), Quaternion.identity); // spawn a "gridDebugObject" at this worldposition(2x2 cellsizes), at this rotation
                    //     GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>(); //gets this gridDebugObjects refrence.
                    //     gridDebugObject.SetGridObject(GetGridObject(gridPosition));
                    // }
                    // if (y != 1)
                    // {
                    //     GridPosition gridPosition = new GridPosition(x, y, z); //creates a gridPosition for the current x and z values.
                    //     Transform debugTransform = GameObject.Instantiate(debugPreFab, GetWorldPosition(gridPosition), Quaternion.identity); // spawn a "gridDebugObject" at this worldposition(2x2 cellsizes), at this rotation
                    //     GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>(); //gets this gridDebugObjects refrence.
                    //     gridDebugObject.SetGridObject(GetGridObject(gridPosition));
                    // }
                }
            }
        }
    }
    //

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        //returns the gridObject that is in this position
        return gridObjectArray[gridPosition.x, gridPosition.y, gridPosition.z];
    }

}
