using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    //Define the singleton pattern, in order to set a static instance. this way "prefabs" can access it
    //Starts here!
    public static LevelGrid Instance { get; private set; }

    [SerializeField] private Transform gridDebugObjectPrefab;

    private GridSystem gridSystem;

    private List<Vector3> addPositionsList = new List<Vector3>();
    private List<Vector3> removePositionsList = new List<Vector3>();

    private int listCount;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one LevelGrid! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;


        //gridSystem = new GridSystem(10, 2, 10, 2f); //create a grid of 10 x 10, having the cellSize as 2x2 wordpositions
        //add number for lenght above
        //gridSystem.CreateDebugObject(gridDebugObjectPrefab); //passes in debugObject prefab to gridsystems function
    }

    public void CreateGridSystem()
    {

        gridSystem = new GridSystem(10, 2, 10, 2f); //create a grid of 10 x 10, having the cellSize as 2x2 wordpositions


        for (int index = 0; index < (listCount); index++)
        {
            gridSystem.AddPeramiters(addPositionsList[index], removePositionsList[index], listCount);
        }


        gridSystem.CreateDebugObject(gridDebugObjectPrefab); //passes in debugObject prefab to gridsystems function
    }
    public void LevelGridPositionLists(Vector3 position1, Vector3 position2, int listcount)
    {

        addPositionsList.Add(position1);
        removePositionsList.Add(position2);
        listCount = listcount;

    }

    public void SetUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        //      SET UNIT AT GRID POSITION
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);   //finds the gridObject at given position
        gridObject.SetUnit(unit);  // lets THAT gridObject store the unit.
    }

    public Unit GetUnitAtGridPosition(GridPosition gridPosition)
    {
        //not in use?
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnit();
    }

    public void ClearUnitAtGridPosition(GridPosition gridPosition)
    {
        //tells gridObject at this gridPosition, there is no unit here.
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.SetUnit(null);
    }

    public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        ClearUnitAtGridPosition(fromGridPosition);

        SetUnitAtGridPosition(toGridPosition, unit);
    }


    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        //uses gridsystemn to: converts WorldPosition into GridPosition
        return gridSystem.GetGridPosition(worldPosition);
    }


    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        //uses gridSystem to: converts gridposition to wroldposition
        return gridSystem.GetWorldPosition(gridPosition);
    }
}
