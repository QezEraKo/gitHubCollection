using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy1Script : MonoBehaviour
{
    #region hero and self ref
    [SerializeField] private GameObject myself;
    [SerializeField] private GameObject hero1;
    private hero1Script h1Script;
    [SerializeField] private GameObject hero2;
    private hero2Script h2Script;
    #endregion
    #region BM ref
    private BattleManager battleManagerScript;
    #endregion
    #region stats
    [SerializeField] public int e1Damage;
    private int e1BaseDamage = 10;
    [SerializeField] public int e1DamageIncrease;
    [SerializeField] public int e1MaxHealth = 350;
    [SerializeField] public int e1CurrentHealth;
    [SerializeField] public int e1Armor;
    [SerializeField] public int e1Energy;
    #endregion
    #region TextRefrences

    public Text e1NameText;
    public Text e1HealthText;
    public Text e1DamageText;

    #endregion

    #region DeathReward
    private bool hero1Dead = false;
    private bool hero2Dead = false;
    private int e1XpDrop = 100;
    private int e1GoldDrop = 20;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        e1Armor = 0;
        //sets current hp to max hp
        e1CurrentHealth = e1MaxHealth;
        //will add a way to increase depending on progress
        e1DamageIncrease = 10;

        e1Damage = (e1BaseDamage + e1DamageIncrease);
    }
    // Update is called once per frame
    void Update()
    {


        TextUpdate();
        
       
    }

    
    public void e1TakeDamage(int heroDamage)
    {
        if (heroDamage - e1Armor >= 0)
        {
            e1CurrentHealth -= heroDamage - e1Armor;
          
        }
        else
        {
            Debug.Log("Armor too high! no damage taken");
        }

        if (e1CurrentHealth <= 0)
        {

            e1DeadReward();
        }
    }

    public void e1DeadReward()
    {
        if (!hero1Dead)
        {
            h1Script = GameObject.FindObjectOfType(typeof(hero1Script)) as hero1Script;
            h1Script.h1ExperienceGain(e1XpDrop);
        }

        if (!hero2Dead)
        {
            h2Script = GameObject.FindObjectOfType(typeof(hero2Script)) as hero2Script;
            h2Script.h2ExperienceGain(e1XpDrop);
        }
        battleManagerScript.VictoryScreenxpReward(e1XpDrop);
        e1Dead();
    }

    public void e1Dead()
    {
        //change e1active bool to false
        battleManagerScript = GameObject.FindObjectOfType(typeof(BattleManager)) as BattleManager;
        battleManagerScript.bmE1Died();

        myself.SetActive(false);
    }

    public void E1AttackH1()
    {
        h1Script = GameObject.FindObjectOfType(typeof(hero1Script)) as hero1Script;
        h1Script.h1TakeDamage(e1Damage);
        Debug.Log("Enemy1 Attacked h1");
    }

    public void E1AttackH2()
    {
        h2Script = GameObject.FindObjectOfType(typeof(hero2Script)) as hero2Script;
        h2Script.h2TakeDamage(e1Damage);
        Debug.Log("Enemy1 attacked h2");
    }
    private void TextUpdate()
    {
        e1NameText.text = ("Name: Enemy1");
        e1HealthText.text = ("Health: ") + e1CurrentHealth.ToString();
        e1DamageText.text = ("Damage: ") + e1Damage.ToString();
    }

    public void e1Hero1Died()
    {
        hero1Dead = true;
    }

    public void e1Hero2Died()
    {
        hero2Dead = true;
    }
    private void OnMouseOver()
    {
       
    }

    private void OnMouseExit()
    {
       
    }
    private void OnMouseDown()
    {
        battleManagerScript = GameObject.FindObjectOfType(typeof(BattleManager)) as BattleManager;
        battleManagerScript.playerClickedE1();
    }



   
}
