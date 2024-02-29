using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Tower_Projectiles : MonoBehaviour
{
    private int friendlyTowerIdentificationLocal;
    private Vector3 targetPosition;
    [SerializeField] private float projectileMoveSpeed = 5f;

    private void Awake()
    {
        GetFriendlyTowerIdentification();
    }

    private void Update()
    {
        Vector3 moveDireciton = (targetPosition - transform.position).normalized;
        transform.position += moveDireciton * projectileMoveSpeed * Time.deltaTime;
    }

    private void GetFriendlyTowerIdentification()
    {
        friendlyTowerIdentificationLocal = GetComponent<Scr_Tracker_Friendly_Stats>().friendlyTowerLevel;
    }

    public void CreateProjectile(Vector3 projectileSpawnPosition, Vector3 targetPosition)
    {
        switch (friendlyTowerIdentificationLocal)
        {
            case 1:
                print("Friendly tower is level 1, projectile will be created using this");
                AttackUsingLevelOne(projectileSpawnPosition, targetPosition);
                projectileMoveSpeed = 2f;
                break;

            case 2:
                print("Friendly tower is level 2, projectile will be created using this");
                AttackUsingLevelTwo(projectileSpawnPosition, targetPosition);
                projectileMoveSpeed = 2f;
                break;
        }
    }

    private void AttackUsingLevelOne(Vector3 projectileSpawnPosition, Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f);
    }

    private void AttackUsingLevelTwo(Vector3 projectileSpawnPosition, Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

}
