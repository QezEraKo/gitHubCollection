using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : MonoBehaviour
{
    private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
    }
}
