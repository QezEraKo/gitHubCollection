using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Tracker_Friendly_Stats : MonoBehaviour
{
    [SerializeField] private int friendlyTowerIdentificationLocal = 1;
    //This value is going to be referenced within the swtich statement located within Scr_Tower_Attack
    public int friendlyTowerLevel { get { return friendlyTowerIdentificationLocal; } }

    //refrence
    [SerializeField] private GameObject shopRefrence;

    //base stats
    public int level;
    public int baseDamage;
    public int attackSpeed;

    //upgrades
    public int shopDamage;
    public int shopAttackSpeed;


    //end-product
    public int fullDamage;
    public int fullAttackSpeed;


     private void Start()
     {
        findWithTag();
        StartCoroutine(UpdateStats());

        SetStats();

      
     }

    private void update()
    {
        //findWithTag();
    }

    private void SetStats()
    {
        fullDamage = (baseDamage * level) + shopDamage;
        fullAttackSpeed = attackSpeed + shopAttackSpeed;
        
    }

    public void DealDamage(GameObject enemy)
    {
        enemy.GetComponent<Scr_Tracker_Enemy_Health>().ProcessHit(fullDamage);
    }

    public void SetShopStats(int damage, int attackspeed)
    {
        shopDamage = damage;
        shopAttackSpeed = attackspeed;
    }

    private IEnumerator UpdateStats()
    {
        StatChecker();
        SetStats();
        yield return new WaitForSeconds(1);
        StartCoroutine(UpdateStats());
    }


    public void StatChecker()
    {
        if (shopRefrence != null)
        {
            //shopRefrence.GetComponent<Shopmenu>().increaseStats(this.gameObject);
        }
    }

    private void findWithTag()
    {
        shopRefrence = GameObject.FindWithTag("Shop");
       
    }
}
