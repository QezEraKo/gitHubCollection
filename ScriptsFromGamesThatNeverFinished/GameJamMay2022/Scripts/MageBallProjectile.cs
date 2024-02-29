using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBallProjectile : MonoBehaviour
{
    private Enemy targetEnemy;
    private Vector3 lastMoveDir;
    private float timeToDie = 2f;

    public static MageBallProjectile Create(Vector3 position, Enemy enemy)
    {
        Transform pf_MagicBallProjectile = Resources.Load<Transform>("pf_ArrowProjectile");
        Transform mageBallTransform = Instantiate(pf_MagicBallProjectile, position, Quaternion.identity);

        MageBallProjectile mageBallProjectile = mageBallTransform.GetComponent<MageBallProjectile>();
        mageBallProjectile.SetTarget(enemy);

        return mageBallProjectile;
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

        float moveSpeed = 20F;
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
            Debug.Log("Enemy has been hit");
            enemy.GetComponent<HealthSystem>().Damage(5);
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
