using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpellScript : MonoBehaviour
{


    //      OFFICIAL SPELLBOOK 
    //
    //

    private float thisPhysicalDamage;
    private float thisMagicalDamage;
    private float unitEnergy;
    private float Cost;


    /////////////////Auto Attacks

    //ID 1
    public void AutoAttack1(float phys, float spellDamage, GameObject attacker, GameObject enemy)
    {
        thisPhysicalDamage = (phys * 0.5f);
        thisMagicalDamage = (spellDamage * 0.2f);

        enemy.GetComponent<Stat_Script>().TakePhysDamage(thisPhysicalDamage + thisMagicalDamage);

        thisPhysicalDamage = 0;
        thisMagicalDamage = 0;
    }

    //ID 2
    public void AutoAttack2(float phys, GameObject attacker, GameObject enemy)
    {
        thisPhysicalDamage = (phys * 0.8f);

        enemy.GetComponent<Stat_Script>().TakePhysDamage(thisPhysicalDamage);

        thisPhysicalDamage = 0;
    }

    /////////////////Physical Attacks

    //ID 3
    public void Slap(float phys, GameObject attacker, GameObject enemy)
    {
        Cost = 5;
        thisPhysicalDamage = (phys * 1.45f);
        unitEnergy = attacker.GetComponent<Stat_Script>().currentEnergy;

        if (unitEnergy >= Cost)
        {
            attacker.GetComponent<Stat_Script>().spendEnergy(Cost);
            enemy.GetComponent<Stat_Script>().TakePhysDamage(thisPhysicalDamage);
            Debug.Log("Should be slapping");
        }
        else
        {
            Debug.Log(attacker.gameObject + " is out of energy");
        }

        Cost = 0;
        thisPhysicalDamage = 0;
        unitEnergy = 0;
    }

    //ID 4
    public void Smash(float phys, GameObject attacker, GameObject enemy)
    {
        Cost = 10;
        thisPhysicalDamage = (phys * 2f);
        unitEnergy = attacker.GetComponent<Stat_Script>().currentEnergy;

        if (unitEnergy >= Cost)
        {
            attacker.GetComponent<Stat_Script>().spendEnergy(Cost);
            enemy.GetComponent<Stat_Script>().TakePhysDamage(thisPhysicalDamage);
        }
        else
        {
            Debug.Log(attacker.gameObject + " is out of energy");
        }

        Cost = 0;
        thisPhysicalDamage = 0;
        unitEnergy = 0;
    }

    /////////////////Magical Attacks

    //ID 5
    public void FireBall(float spellDamage, GameObject attacker, GameObject enemy)
    {
        Cost = 10;
        thisMagicalDamage = (spellDamage * 2f);
        unitEnergy = attacker.GetComponent<Stat_Script>().currentEnergy;

        if (unitEnergy >= Cost)
        {
            attacker.GetComponent<Stat_Script>().spendEnergy(Cost);
            enemy.GetComponent<Stat_Script>().TakeMagicDamage(thisMagicalDamage);
        }
        else
        {
            Debug.Log(attacker.gameObject + " is out of energy");
        }

        Cost = 0;
        thisMagicalDamage = 0;
        unitEnergy = 0;
    }

    //ID 6
    public void FrostBolt(float spellDamage, GameObject attacker, GameObject enemy)
    {
        Cost = 7;
        thisMagicalDamage = (spellDamage * 1.7f);
        unitEnergy = attacker.GetComponent<Stat_Script>().currentEnergy;

        if (unitEnergy >= Cost)
        {
            attacker.GetComponent<Stat_Script>().spendEnergy(Cost);
            enemy.GetComponent<Stat_Script>().TakeMagicDamage(thisMagicalDamage);
        }
        else
        {
            Debug.Log(attacker.gameObject + " is out of energy");
        }

        Cost = 0;
        thisMagicalDamage = 0;
        unitEnergy = 0;
    }
}
