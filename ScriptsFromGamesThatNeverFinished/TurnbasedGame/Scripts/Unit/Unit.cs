using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{


    private GridPosition gridPosition;
    private Vector3 targetPosition;

    private GridPosition moveGridPosition;


    void Start()
    {
        //Grabs gridposition trough levelGrid(is static instance, prefabs can therefore access it) and 
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);  //calculates it's own grid-position 
        LevelGrid.Instance.SetUnitAtGridPosition(gridPosition, this); //lets gridObject at that gridPosition store unit
    }

    // Update is called once per frame
    void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position); //stores position as "newgridPosition"
        if (newGridPosition != gridPosition) //if "newGridPosition" is NOT same as gridPosition
        {
            //unit changed Grid Position

            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition); //clears the unit stored in gridObject from " old gridposition" and sets it at the news GridObject in  "newGridPosition"
            gridPosition = newGridPosition; //updates current gridPosition
        }



        MovementBit();
    }


    private void MovementBit()
    {
        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 MoveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += MoveDirection * moveSpeed * Time.deltaTime;
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Move(MouseWorld.GetPosition());
        //}

        if (Input.GetMouseButtonDown(0))
        {

            moveGridPosition = (LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition()));
            // LevelGrid.Instance.GetWorldPosition(moveGridPosition);
            Move(LevelGrid.Instance.GetWorldPosition(moveGridPosition));


        }
    }

    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
