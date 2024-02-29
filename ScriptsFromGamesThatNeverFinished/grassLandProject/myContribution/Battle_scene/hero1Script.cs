using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class hero1Script : MonoBehaviour
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
    [SerializeField] public int h1Damage;
    private int h1BaseDamage = 20;
    [SerializeField] public int h1ExtraDamage;  
    [SerializeField] private int h1Health;
    [SerializeField] private int h1CurrentHealth; 
    [SerializeField] private int h1HpRegeneration;
    [SerializeField] public int h1Armor;    
    private int h1MaxEnergy = 100;   
    private int h1CurrentEnergy;
    [SerializeField] public int h1LevelStat;    
    public int AddExperience;
    public int h1CurrentExperience;
    public int h1MaxExperience = 1000;
    public int h1ExcessExperience;
    #endregion
    #region Special Attacks
    private int h1SpecialAttack1;

    #endregion
    //public Text text;
    #region exp bools
    bool h1level1 = true;
    bool h1level2 = false;
    bool h1level3 = false;
    bool h1level4 = false;
    bool h1level5 = false;
    #endregion
    #region textRefrence
    public Text h1CurrentHealthText;
    public Text h1CurrentLevelText;
    public Text h1NameText;
    public Text h1CurrentEnergyText;
    #endregion
    // Start is called before the first frame update

    void Start()
    {
        #region settingStats
        h1CurrentEnergy = h1MaxEnergy;
        h1HpRegeneration = 12;
        h1Health = 20;
        h1Armor = 2;
        h1Damage = (h1BaseDamage + h1ExtraDamage);
        h1LevelStat = 1;
        //AddExperience = 101;
        h1CurrentHealth = h1Health;
        #endregion
        h1SpecialAttack1 = h1Damage * 3;
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
   
    public void h1ExperienceGain(int mobXp)
    {
        //h1CurrentExperience = h1CurrentExperience += AddExperience;
        h1CurrentExperience += mobXp;
        if (h1level1)
        {
            
            if (h1CurrentExperience >= h1MaxExperience)
            {
                h1ExcessExperience = h1CurrentExperience - h1MaxExperience;
                h1CurrentExperience = 0 + h1ExcessExperience;

                h1LevelStat = 2;
                Debug.Log("DingDing level 2!");
            }
            else
            {
                
            }
        }
        else if (h1level2)
        {
            
            if (h1CurrentExperience >= h1MaxExperience)
            {
                h1ExcessExperience = h1CurrentExperience - h1MaxExperience;
                h1CurrentExperience = 0 + h1ExcessExperience;
                h1LevelStat = 3;
            }
            else
            {

            }
        }
        else if (h1level3)
        {

            if (h1CurrentExperience >= h1MaxExperience)
            {
                h1ExcessExperience = h1CurrentExperience - h1MaxExperience;
                h1CurrentExperience = 0 + h1ExcessExperience;
                h1LevelStat = 4;

            }
            else
            {

            }
        }
        else if (h1level4)
        {

            if (h1CurrentExperience >= h1MaxExperience)
            {
                h1ExcessExperience = h1CurrentExperience - h1MaxExperience;
                h1CurrentExperience = 0 + h1ExcessExperience;
                h1LevelStat = 5;
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

    public void h1TakeDamage(int mobDmg)
    {
        if (mobDmg - h1Armor >= 0)
        {
            h1CurrentHealth -= (mobDmg - h1Armor);

        }
        if (h1CurrentHealth <= 0)
        {
            h1DeadDrop();
        }
    }
    
    public void h1DeadDrop()
    {
        //drop equipment 
        h1Dead();
    }

    public void h1Dead()
    {
        battleManagerScript = GameObject.FindObjectOfType(typeof(BattleManager)) as BattleManager;
        battleManagerScript.bmh1Died();

        myself.SetActive(false);
    }
    public void levelSystem()
    {
        if (h1LevelStat == 1)
        {
            
            h1level1 = true;

        }
        else if (h1LevelStat == 2)
        {
            
            h1level1 = false;
            h1level2 = true;
        }
        else if (h1LevelStat == 3)
        {
            
            h1level2 = false;
            h1level3 = true;
        }
        else if (h1LevelStat == 4)
        {
            
            h1level3 = false;
            h1level4 = true;
        }
        else 
        {
            
            h1level4 = false;
            h1level5 = true;
        }
    }

    #region Attack Enemy1
    public void H1AttackE1()
    {
        e1Script = GameObject.FindObjectOfType(typeof(Enemy1Script)) as Enemy1Script;
        e1Script.e1TakeDamage(h1Damage);
        Debug.Log("hero 1 Attacked!");
    }
    public void H1SpecialAttack1E1()
    {
        if (h1CurrentEnergy >= 30)
        {


            e1Script = GameObject.FindObjectOfType(typeof(Enemy1Script)) as Enemy1Script;
            e1Script.e1TakeDamage(h1SpecialAttack1);
            h1CurrentEnergy -= 30;
        }
    }

    #endregion

    #region Attack Enemy2
    public void H1AttackE2()
    {
        e2Script = GameObject.FindObjectOfType(typeof(enemy2Script)) as enemy2Script;
        e2Script.e2TakeDamage(h1Damage);
    }
    public void H1SpecialAttack1E2()
    {
        if(h1CurrentEnergy >= 30)
        {
            e2Script = GameObject.FindObjectOfType(typeof(enemy2Script)) as enemy2Script;
            e2Script.e2TakeDamage(h1SpecialAttack1);
        }
    }
    #endregion
    private void TextUpdate()
    {
        h1CurrentHealthText.text = (("Health ") + h1CurrentHealth.ToString());
        h1CurrentLevelText.text = (("Level ") + h1LevelStat.ToString());
        h1NameText.text = ("Name: Eskil");
        h1CurrentEnergyText.text = (("Enrgy: ") + h1CurrentEnergy.ToString() + (" / ") + h1MaxEnergy.ToString());
        //h1NameTextCanvas.Text = ("itsa me mario");
    }

    public void h1HpRegen()
    {
        
        if (h1CurrentHealth < h1Health)
        {
            
            if((h1CurrentHealth + h1HpRegeneration) >= h1Health)
            {
                h1CurrentHealth = h1Health;
            }
            else
            {
                h1CurrentHealth += h1HpRegeneration;
            }
        }
    }
}
