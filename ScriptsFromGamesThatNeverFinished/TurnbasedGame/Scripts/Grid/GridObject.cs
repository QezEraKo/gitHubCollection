using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    //this object Is each grid.              "START on LevelGrid!"
    //uses GridSystem for 
    //usen GridPosition for: keeping track of and displaying cordinates
    //uses Unit for: keeping track of, and displaying unit
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    //private List<Unit> unitList;        <-- this is for units overlapping 1 grid (example, 1 unit runs across anothers units grid). works as is, but names does not update.
    private Unit unit;




    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        //UnitList = new List<Unit>();
    }


    public override string ToString()
    {
        //forach (Unit unit in unitList)
        //{
        //    unitString += uint + "\n";
        //}
        return gridPosition.ToString() + "\n" + unit;   //

    }

    public void SetUnit(Unit unit)
    {
        this.unit = unit; //stores unit
    }

    // public void RemoveUnit(Unit unit)
    // {
    //     unitList.Remove(unit);
    // }

    public Unit GetUnit()
    {
        return unit;
    }

}
