using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Tracker_Enemy_Health : MonoBehaviour
{
    [SerializeField] int maxHealthPoints = 50;
    [SerializeField] int currentHealthPoints = 0;

    private void Start()
    {
        currentHealthPoints = maxHealthPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        //ProcessHit();
    }

    public void ProcessHit( int Damage)
    {

        Debug.Log("I've been hit! +" + Damage);
        currentHealthPoints -= Damage;

        if (currentHealthPoints <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision projectile)
    {

    }

}
