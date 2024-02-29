using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Attack_1 : MonoBehaviour
{
    //This attack should
    //
    //
    //     140% of spell
    //     130% of physical damage
    //
    //Physical
    //Cost 40  energy x
    //Scale by 120%  x
    // have a "cool" mechanic
    // have a toolTip

    private float thisPhysicalDamage;
    private float thisEnergy;
    private float Cost = 5f; // was 40 earlier




    // Start is called before the first frame update
    void Start()
    {
        thisPhysicalDamage = (this.GetComponent<Stat_Script>().physicalDamage * 1.2f);
        thisEnergy = this.GetComponent<Stat_Script>().currentEnergy;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackOne(GameObject enemy)
    {
        thisPhysicalDamage = (this.GetComponent<Stat_Script>().physicalDamage * 1.2f);
        thisEnergy = this.GetComponent<Stat_Script>().currentEnergy;
        if (thisEnergy >= Cost) //originally "if (currentEnergy >= 40)" change back to this when fixed on HeroPHYS
        {
           // this.GetComponent<Stat_Script>().energy -= 40;
                this.GetComponent<Stat_Script>().spendEnergy(Cost);
                enemy.GetComponent<Stat_Script>().TakePhysDamage(thisPhysicalDamage);
           
        }
        else
        {
            Debug.Log(this.gameObject + " is our of Energy ");
        }
        

        
    }

    public void attackonetest()
    {
        Debug.Log("ello fakkerboi, anyways there I was blasting");
    }
}
