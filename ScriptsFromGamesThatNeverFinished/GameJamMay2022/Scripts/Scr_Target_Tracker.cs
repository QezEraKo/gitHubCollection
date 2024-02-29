using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Target_Tracker : MonoBehaviour
{
    [SerializeField] Transform particleContainer;
    [SerializeField] Transform target;

    private float offset;
    private void Update()
    {
        AimAtTarget();
    }

    private void SetTarget()
    {
        target = FindObjectOfType<Scr_Mover_Enemy>().transform;

    }

    private void AimAtTarget()
    {
        if (target == null)
        {
            SetTarget();
        }
        //offset = (target.position.z - 90);
        Vector3 targetVector = new Vector3(target.position.x, target.position.y, target.position.z);
        //targetVector = target.position;
        particleContainer.LookAt(targetVector);  // Change back to "target" for same effect
        //particleContainer.Rotate(0, 90, 0);
        //particleContainer.LookAt(target.position.x, target.position.y, target.position.z -90);
    }

}
