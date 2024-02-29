using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy targetEnemy;
    private Vector3 lastMoveDir;
    private float timeToDie = 2f;
    Scr_SO_AttackProjectile localProjectile;

    public static Projectile Create(Vector3 position, Enemy enemy, Scr_SO_AttackProjectile projectile)
    {
        Transform shootingProjectile = Resources.Load<Transform>(projectile.prefab.name);
        // Transform pf_ArrowProjectile = Resources.Load<Transform>("pf_ArrowProjectile");
        Transform projectileTransform = Instantiate(shootingProjectile, position, Quaternion.identity);

        Projectile newProjectile = projectileTransform.GetComponent<Projectile>();
        newProjectile.SetTarget(enemy);

        return newProjectile;
    }

    private void Awake()
    {
        localProjectile = GetComponent<Scr_ProjectileType_Holder>().projectileType;
    }

    private void Update()
    {
        Vector3 moveDir;

        if (targetEnemy != null)
        {
            moveDir = (targetEnemy.transform.position - transform.position).normalized;
            lastMoveDir = moveDir;
        }

        else
        {
            moveDir = lastMoveDir;
        }
        lastMoveDir = moveDir;

        // if(!localProjectile) {}

        float moveSpeed = localProjectile.attackSpeed;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(moveDir));

        timeToDie -= Time.deltaTime;
        if (timeToDie < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void SetTarget(Enemy targetEnemy)
    {
        this.targetEnemy = targetEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            // int extraDamage;
            // extraDamage = Shopmenu.Instance.shopDamage + Shopmenu.Instance.pShopDamage;
            Debug.Log("Enemy has been hit");
            enemy.GetComponent<HealthSystem>().Damage(localProjectile.damage);
            Destroy(gameObject);
        }
    }

    private static float GetAngleFromVector(Vector3 vector)
    {
        float radians = Mathf.Atan2(vector.y, vector.x);
        float degrees = radians * Mathf.Rad2Deg;
        return degrees;
    }

}
