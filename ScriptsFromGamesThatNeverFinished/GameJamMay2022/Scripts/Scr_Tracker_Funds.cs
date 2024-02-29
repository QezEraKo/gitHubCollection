using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Tracker_Funds : MonoBehaviour
{
    public int minorSoulsValue;
    public int majorSoulsValue;

    public void AddMinorFunds(int deathMinorSoulValue)
    {
        minorSoulsValue += deathMinorSoulValue;
    }

    public void AddMajorFunds(int deathMajorSoulValue)
    {
        majorSoulsValue += deathMajorSoulValue;
    }

    public void SpendMinorFunds(int spendMinorSoulValue)
    {
        if (spendMinorSoulValue > minorSoulsValue)
        {
            return;
        }

        else
        {
            minorSoulsValue -= spendMinorSoulValue;
        }
    }

    public void SpendMajorFunds(int spemdMajorSoulValue)
    {
        if (spemdMajorSoulValue > majorSoulsValue)
        {
            return;
        }

        else
        {
            majorSoulsValue -= majorSoulsValue;
        }
    }

}
