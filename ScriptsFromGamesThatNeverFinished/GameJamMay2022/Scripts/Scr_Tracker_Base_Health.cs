using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Tracker_Base_Health : MonoBehaviour
{
    [SerializeField] public int friendlyBaseHealthCurent;
    [SerializeField] public int friendlyBaseHealthMax;

    private void Start()
    {
        SetStartHealth();
    }

    private void SetStartHealth()
    {
        friendlyBaseHealthCurent = friendlyBaseHealthMax;
    }
}
