using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scr_Manager_Resources : MonoBehaviour
{
    public static Scr_Manager_Resources Instance { get; private set; }

    public event EventHandler OnResourceAmountChanged;

    private Dictionary<Scr_SO_ResourceType, int> resourceAmountDictionary;

    private void Awake()
    {
        Instance = this;

        resourceAmountDictionary = new Dictionary<Scr_SO_ResourceType, int>();

        Scr_SO_ResourceType_List resourceTypeList = Resources.Load<Scr_SO_ResourceType_List>(typeof(Scr_SO_ResourceType_List).Name);

        foreach (Scr_SO_ResourceType resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 200;
        }
    }

    public void AddResource(Scr_SO_ResourceType resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;

        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SpendResource(Scr_SO_ResourceType resourceType, int amount)
    {
        Debug.Log("SpendResource called");
        if (resourceAmountDictionary[resourceType] - amount < 0)
        {
            Debug.Log("Trying to spend too much!");
        }
        else
        {
            resourceAmountDictionary[resourceType] -= amount;
            OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public int GetResourceAmount(Scr_SO_ResourceType resourceType)
    {
        return resourceAmountDictionary[resourceType];
    }
}
