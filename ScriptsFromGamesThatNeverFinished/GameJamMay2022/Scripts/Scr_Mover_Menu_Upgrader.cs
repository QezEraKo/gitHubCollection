using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Mover_Menu_Upgrader : MonoBehaviour
{
    [SerializeField] private bool isMenuOpen;
    [SerializeField] private GameObject openPositionObject;
    [SerializeField] private GameObject closedPositionObject;
    [SerializeField] private bool isMenuTransitioning;
    [SerializeField] private float menuMovementTime = 1f;
    private float travelPercent;
    private Vector3 openPosition;
    private Vector3 closedPosition;

    public void ChangeMenuState()
    {
        Debug.Log("ChangeMenuState has been called");
        if (!isMenuTransitioning)
        {
            if (isMenuOpen)
            {
                Debug.Log("Upgrade menu was open, menu now closing");
                isMenuOpen = false;
                StartCoroutine(CloseUpgradeMenu());
                isMenuTransitioning = false;
            }

            else
            {
                Debug.Log("Upgrade menu was closed, menu now opening");
                isMenuOpen = true;
                StartCoroutine(OpenUpgradeMenu());
                isMenuTransitioning = false;
            }
        }
    }

    private IEnumerator CloseUpgradeMenu()
    {
        if (!isMenuTransitioning)
        {
            isMenuTransitioning = true;
            travelPercent = 0f;
            openPosition = openPositionObject.transform.position;
            closedPosition = closedPositionObject.transform.position;

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * menuMovementTime;
                transform.position = Vector3.Lerp(openPosition, closedPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private IEnumerator OpenUpgradeMenu()
    {
        if (!isMenuTransitioning)
        {
            isMenuTransitioning = true;
            travelPercent = 0f;
            openPosition = openPositionObject.transform.position;
            closedPosition = closedPositionObject.transform.position;

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * menuMovementTime;
                transform.position = Vector3.Lerp(closedPosition, openPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
