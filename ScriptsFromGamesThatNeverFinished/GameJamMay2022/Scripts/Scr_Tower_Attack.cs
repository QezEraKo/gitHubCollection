using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Tower_Attack : MonoBehaviour
{
    private int friendlyTowerIdentificationLocal;
    private float attackSpeed = 1f;

    private Vector3 projectileShootingLocation;
    private Vector3 projectileShootingTarget;

    //sorry  
    public GameObject attackProjectile;
    public GameObject collitionObject;
    public GameObject collitionObject2;

    private void Awake()
    {
        projectileShootingLocation = transform.Find("ProjectileShootingPosition").position;
    }

    private void Start()
    {
        GetFriendlyTowerIdentification();
    }

    private void GetFriendlyTowerIdentification()
    {
        friendlyTowerIdentificationLocal = GetComponent<Scr_Tracker_Friendly_Stats>().friendlyTowerLevel;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("ayoo");

        if (collitionObject == null)
        {
            if (other.transform.tag == "Enemy")
            {
                collitionObject = other.gameObject;

                StartCoroutine(attackEnemy());

                Debug.Log("I smell something");
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        collitionObject2 = other.gameObject;

        if (collitionObject2 == collitionObject) //Check if unit that left trigger, is the same as our target
        {
            collitionObject = null;
        }
    }


    private IEnumerator attackEnemy()
    {
        if (collitionObject != null)
        {
            yield return new WaitForSeconds(2);

            Instantiate(attackProjectile, this.transform.position, Quaternion.identity, transform);
            StartCoroutine(attackEnemy());
        }
    }
}
