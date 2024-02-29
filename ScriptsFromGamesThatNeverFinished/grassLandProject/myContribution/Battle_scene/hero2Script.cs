using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class hero2Script : MonoBehaviour
{
    #region test
    public GameObject enemy1;
    public GameObject emeny2;
    [SerializeField] private GameObject myself;

    public Enemy1Script e1Script;
    public enemy2Script e2Script;

    #endregion
    #region BM ref
    private BattleManager battleManagerScript;
    #endregion
    #region stats
    [SerializeField] private int h2Damage;
    private int h2BaseDamage = 20;
    [SerializeField] public int h2ExtraDamage;
    [SerializeField] private int h2Health;
    [SerializeField] private int h2CurrentHealth;
    [SerializeField] private int h2HpRegeneration;
    [SerializeField] public int h2Armor;
    private int h2MaxEnergy = 100;
    private int h2CurrentEnergy;
    [SerializeField] public int h2LevelStat;
    public int AddExperience;
    public int h2CurrentExperience;
    public int h2MaxExperience = 1000;
    public int h2ExcessExperience;
    #endregion
    #region Special Attacks
    private int h2SpecialAttack1;

    #endregion
    //public Text text;
    #region exp bools
    bool h2level1 = true;
    bool h2level2 = false;
    bool h2level3 = false;
    bool h2level4 = false;
    bool h2level5 = false;
    #endregion
    #region textRefrence
    public Text h2CurrentHealthText;
    public Text h2CurrentLevelText;
    public Text h2NameText;
    public Text h2CurrentEnergyText;
    #endregion
    // Start is called before the first frame update

    void Start()
    {
        #region settingStats
        h2CurrentEnergy = h2MaxEnergy;
        h2ExtraDamage = 20;
        h2HpRegeneration = 12;
        h2Health = 100;
        h2Armor = 2;
        h2Damage = (h2BaseDamage + h2ExtraDamage);
        h2LevelStat = 1;
        //AddExperience = 101;
        h2CurrentHealth = h2Health;
        #endregion
        h2SpecialAttack1 = h2Damage * 3;
        TextUpdate();
        //e1Script = GameObject.FindObjectOfType(typeof(Enemy1Script)) as Enemy1Script;
    }

    // Update is called once per frame
    void Update()
    {
        //text.text =("Level " + h1LevelStat.ToString());
        levelSystem();
        TextUpdate();


    }

    public void h2ExperienceGain(int mobXp)
    {
        //h1CurrentExperience = h1CurrentExperience += AddExperience;
        h2CurrentExperience += mobXp;
        if (h2level1)
        {

            if (h2CurrentExperience >= h2MaxExperience)
            {
                h2ExcessExperience = h2CurrentExperience - h2MaxExperience;
                h2CurrentExperience = 0 + h2ExcessExperience;

                h2LevelStat = 2;
                Debug.Log("DingDing level 2!");
            }
            else
            {

            }
        }
        else if (h2level2)
        {

            if (h2CurrentExperience >= h2MaxExperience)
            {
                h2ExcessExperience = h2CurrentExperience - h2MaxExperience;
                h2CurrentExperience = 0 + h2ExcessExperience;
                h2LevelStat = 3;
            }
            else
            {

            }
        }
        else if (h2level3)
        {

            if (h2CurrentExperience >= h2MaxExperience)
            {
                h2ExcessExperience = h2CurrentExperience - h2MaxExperience;
                h2CurrentExperience = 0 + h2ExcessExperience;
                h2LevelStat = 4;

            }
            else
            {

            }
        }
        else if (h2level4)
        {

            if (h2CurrentExperience >= h2MaxExperience)
            {
                h2ExcessExperience = h2CurrentExperience - h2MaxExperience;
                h2CurrentExperience = 0 + h2ExcessExperience;
                h2LevelStat = 5;
            }
            else
            {

            }
        }
        else
        {
            Debug.Log("it is what it is");
        }

    }

    public void h2TakeDamage(int mobDmg)
    {
        if (mobDmg - h2Armor >= 0)
        {
            h2CurrentHealth -= (mobDmg - h2Armor);

        }
        if (h2CurrentHealth <= 0)
        {
            h2DeadDrop();
        }
    }

    public void h2DeadDrop()
    {
        //drop equipment 
        h2Dead();
    }

    public void h2Dead()
    {
        battleManagerScript = GameObject.FindObjectOfType(typeof(BattleManager)) as BattleManager;
        //battleManagerScript.bmh2Died();

        myself.SetActive(false);
    }
    private void levelSystem()
    {
        if (h2LevelStat == 1)
        {

            h2level1 = true;

        }
        else if (h2LevelStat == 2)
        {

            h2level1 = false;
            h2level2 = true;
        }
        else if (h2LevelStat == 3)
        {

            h2level2 = false;
            h2level3 = true;
        }
        else if (h2LevelStat == 4)
        {

            h2level3 = false;
            h2level4 = true;
        }
        else
        {

            h2level4 = false;
            h2level5 = true;
        }
    }

    #region Attack Enemy1
    public void H2AttackE1()
    {
        e1Script = GameObject.FindObjectOfType(typeof(Enemy1Script)) as Enemy1Script;
        e1Script.e1TakeDamage(h2Damage);
    }
    public void H2SpecialAttack1E1()
    {
        if (h2CurrentEnergy >= 50)
        {


            e1Script = GameObject.FindObjectOfType(typeof(Enemy1Script)) as Enemy1Script;
            e1Script.e1TakeDamage(h2SpecialAttack1);
            h2CurrentEnergy -= 50;
        }
    }

    #endregion

    #region Attack Enemy2
    public void H2AttackE2()
    {
        e2Script = GameObject.FindObjectOfType(typeof(enemy2Script)) as enemy2Script;
        e2Script.e2TakeDamage(h2Damage);
    }
    public void H2SpecialAttack1E2()
    {
        if (h2CurrentEnergy >= 50)
        {
            e2Script = GameObject.FindObjectOfType(typeof(enemy2Script)) as enemy2Script;
            e2Script.e2TakeDamage(h2SpecialAttack1);
        }
    }
    #endregion
    private void TextUpdate()
    {
        
        h2CurrentHealthText.text = (("Health ") + h2CurrentHealth.ToString());
        h2CurrentLevelText.text = (("Level ") + h2LevelStat.ToString());
        h2NameText.text = ("Name: kyle");
        h2CurrentEnergyText.text = (("Enrgy: ") + h2CurrentEnergy.ToString() + (" / ") + h2MaxEnergy.ToString());
        
        
    }

    public void h2HpRegen()
    {
        
        if (h2CurrentHealth < h2Health)
        {
            
            if ((h2CurrentHealth + h2HpRegeneration) >= h2Health)
            {
                h2CurrentHealth = h2Health;
            }
            else
            {
                h2CurrentHealth += h2HpRegeneration;
            }
        }
    }
}
