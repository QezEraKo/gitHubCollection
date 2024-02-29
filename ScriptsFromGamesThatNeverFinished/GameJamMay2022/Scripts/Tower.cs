using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Enemy targetEnemy;
    private float lookForTargetTimer;
    private float lookForTargetTimerMax = .2f;
    private Vector3 projectileSpawnPosition;
    private float shootTimer;
    private float shootTimerMax = 1f;

    Scr_SO_AttackProjectile projectile;
    Scr_SO_BuildingType buildingType;

    private void Awake()
    {
        projectileSpawnPosition = transform.Find("ProjectileShootingPosition").position;
        buildingType = GetComponent<Scr_FriendlyType_Holder>().buildingType;
    }

    private void Start()
    {
        SetProjectile();
        SetShootTImerMax();
    }

    private void SetProjectile()
    {
        projectile = buildingType.projectile;
    }

    private void SetShootTImerMax()
    {
        shootTimerMax = projectile.timeToReload;
    }

    private void Update()
    {
        HandleTargeting();
        HandleShooting();
    }

    private void HandleTargeting()
    {
        lookForTargetTimer -= Time.deltaTime;
        if (lookForTargetTimer < 0f)
        {
            lookForTargetTimer += lookForTargetTimerMax;
            LookForTargets();
        }
    }

    private void HandleShooting()
    {
        Debug.Log("HandleShooting");
        shootTimer -= Time.deltaTime;
        if (shootTimer < 0)
        {
            Debug.Log("Shoot timer < 0");
            shootTimer += shootTimerMax;
            if (targetEnemy != null)
            {
                Debug.Log("Calling projectile.create");
                Projectile.Create(projectileSpawnPosition, targetEnemy, projectile);
            }
        }
    }

    private void LookForTargets()
    {
        float targetMaxRadius = 10f;
        Collider2D[] collider2dArray = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);

        foreach (Collider2D colldier2D in collider2dArray)
        {
            Enemy enemy = colldier2D.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (targetEnemy == null)
                {
                    targetEnemy = enemy;
                }

                else
                {
                    if (Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, targetEnemy.transform.position))
                    {
                        targetEnemy = enemy;
                    }
                }
            }
        }
    }

}
