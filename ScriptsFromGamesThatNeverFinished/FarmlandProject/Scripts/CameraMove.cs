using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;
    private Vector3 resetCamera;

    private bool drag = false;
    [SerializeField] private GameObject camGameObject;
    private Camera camCamera;
    private Transform camT;


    void Start()
    {
        camCamera = Camera.main;
        camT = camGameObject.transform;
        resetCamera = Camera.main.transform.position;
    }


    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            difference = (camCamera.ScreenToWorldPoint(Input.mousePosition)) - camGameObject.transform.position;
            if(drag == false)
            {
                drag = true;
                origin = camCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            camGameObject.transform.position = origin - difference;
        }

        if (Input.GetMouseButton(1))
        {
            camGameObject.transform.position = resetCamera;
        }
    }

}
