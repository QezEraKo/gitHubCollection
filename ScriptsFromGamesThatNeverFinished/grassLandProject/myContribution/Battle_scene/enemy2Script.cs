using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy2Script : MonoBehaviour
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
    [SerializeField] public int e2Damage;
    private int e2BaseDamage = 10;
    [SerializeField] public int e2DamageIncrease;
    [SerializeField] public int e2MaxHealth = 250;
    [SerializeField] public int e2CurrentHealth;
    [SerializeField] public int e2Armor;
    [SerializeField] public int e2Energy;
    #endregion
    #region TextRefrences

    public Text e2NameText;
    public Text e2HealthText;
    public Text e2DamageText;

    #endregion

    #region DeathReward
    private bool hero1Dead = false;
    private bool hero2Dead = false;
    private int e2XpDrop = 100;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        e2Armor = 0;
        //sets current hp to max hp
        e2CurrentHealth = e2MaxHealth;
        //will add a way to increase depending on progress
        e2DamageIncrease = 10;

        e2Damage = (e2BaseDamage + e2DamageIncrease);
    }
    // Update is called once per frame
    void Update()
    {


        TextUpdate();


    }


    public void e2TakeDamage(int heroDamage)
    {
        if (heroDamage - e2Armor >= 0)
        {
            e2CurrentHealth -= heroDamage - e2Armor;
           
        }
        else
        {
            Debug.Log("Armor too high! no damage taken");
        }

        if (e2CurrentHealth <= 0)
        {

            e2DeadReward();
        }
    }

    public void e2DeadReward()
    {
        if (!hero1Dead)
        {
            h1Script = GameObject.FindObjectOfType(typeof(hero1Script)) as hero1Script;
            h1Script.h1ExperienceGain(e2XpDrop);
        }

        if (!hero2Dead)
        {
            h2Script = GameObject.FindObjectOfType(typeof(hero2Script)) as hero2Script;
            h2Script.h2ExperienceGain(e2XpDrop);
        }
        battleManagerScript.VictoryScreenxpReward(e2XpDrop);
        e2Dead();

    }

    public void e2Dead()
    {
        //change e2active bool to false
        battleManagerScript = GameObject.FindObjectOfType(typeof(BattleManager)) as BattleManager;
        battleManagerScript.bmE2Died();

        myself.SetActive(false);
    }

    public void E2AttackH1()
    {
        h1Script = GameObject.FindObjectOfType(typeof(hero1Script)) as hero1Script;
        h1Script.h1TakeDamage(e2Damage);
        Debug.Log("Enemy2 Attacked h1");
    }

    public void E2AttackH2()
    {
        h2Script = GameObject.FindObjectOfType(typeof(hero2Script)) as hero2Script;
        h2Script.h2TakeDamage(e2Damage);
        Debug.Log("Enemy2 attacked h2");
    }


    private void TextUpdate()
    {
        e2NameText.text = ("Name: Enemy2");
        e2HealthText.text = ("Health: ") + e2CurrentHealth.ToString();
        e2DamageText.text = ("Damage: ") + e2Damage.ToString();
    }

    public void e2Hero1Died()
    {
        hero1Dead = true;
    }

    public void e2Hero2Died()
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
        battleManagerScript.playerClickedE2();
    }
}
