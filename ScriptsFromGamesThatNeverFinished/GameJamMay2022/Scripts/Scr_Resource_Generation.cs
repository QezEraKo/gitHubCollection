using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Resource_Generation : MonoBehaviour
{
    private Scr_SO_EnemyType enemyType;
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        enemyType = GetComponent<Scr_EnemyType_Holder>().enemyType;
        healthSystem.OnDied += HealthSystem_OnDied;
    }

    private void HealthSystem_OnDied(object sender, System.EventArgs e)
    {
        Scr_Manager_Resources.Instance.AddResource(enemyType.resourceGenerationData.resourceType, enemyType.resourceGenerationData.resourceAmount);
        Destroy(gameObject);
    }
}
