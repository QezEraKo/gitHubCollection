using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDied += HealthSystem_OnDied;
    }

    public static Enemy Create(Vector3 position, Scr_SO_EnemyType enemyType)
    {
        Transform enemyPrefab = Resources.Load<Transform>(enemyType.prefab.name);
        // Transform pf_ArrowProjectile = Resources.Load<Transform>("pf_ArrowProjectile");
        Transform enemyTransform = Instantiate(enemyPrefab, position, Quaternion.identity);

        Enemy newEnemy = enemyTransform.GetComponent<Enemy>();

        return newEnemy;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Friendly friendly = collision.gameObject.GetComponent<Friendly>();
        if (friendly != null)
        {
            HealthSystem healthSystem = friendly.GetComponent<HealthSystem>();
            healthSystem.Damage(10);
            Destroy(gameObject);
        }
    }

    private void HealthSystem_OnDied(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }
}
