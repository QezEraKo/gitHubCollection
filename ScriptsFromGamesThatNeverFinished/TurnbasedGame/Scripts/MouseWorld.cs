using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{


    private static MouseWorld instance;
    [SerializeField] private LayerMask mousePlaneLayerMask;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        transform.position = MouseWorld.GetPosition(); //"Green ball"  // transform.position = MouseWorld.GetPosition();  // MouseWorld.GetPosition(); can be called from anywhere, if we need mouseworld position
    }

    public static Vector3 GetPosition()  //static, belongs to the class itself and not every instance of the class
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return raycastHit.point;
    }
}
