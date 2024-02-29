using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat_Script : MonoBehaviour
{
    #region refrence
    [SerializeField] GameObject BattleManager;
    [SerializeField] GameObject SpellBook;
    private GameObject statModifyer;
    #endregion

    #region Stats
    public string unitName;

    public float level;
    public float experience;
    public float experienceTreshold;
    private float xpReward;
    [SerializeField] private GameObject me;

    [SerializeField] private float basePhysicalDamage;
                     public float physicalDamage;// = basePhysicalDamage * ((level-1) * 1,1f);
    [SerializeField] private float baseSpellDamage;
                     public float spellDamage;// = baseSpellDamage * ((level-1) * 1,1);

    public float maxEnergy;
    public float currentEnergy;

    public float Speed;

    [SerializeField] private float baseArmour;
                     public float armour;
    [SerializeField] private float baseMagicResist;
                     public float magicResist;

    [SerializeField] private float baseMaxHp;
                     public float maxHp;
    public float currentHp;
    public int aggroWeight;

    private float scaling; //= 1 + ((level - 1) * 1.1f)

    #endregion

    #region Spells
   
    //Testing ID
    public List<int> attack1IDList = new List<int>();
    public List<int> attack2IDList = new List<int>();
    public List<int> attack3IDList = new List<int>();
    public List<int> attack4IDList = new List<int>();

    public List<int> currentAttackIDList = new List<int>();

    public bool autoattack1;
    public bool autoattack2;

    public bool slap;
    public bool smash;

    public bool fireBall;
    public bool frostBolt;


    #endregion
    public bool isEnemy;

    #region AggroWeight Bool
    public bool isTank;
    public bool isDps;
    public bool isElusive;
    #endregion


    private int uiListCounter = 0;
    #region UI lists and refrences
    [SerializeField] List<GameObject> unitHpUIList = new List<GameObject>();
    [SerializeField] List<GameObject> unitNameTUIList = new List<GameObject>();
    [SerializeField] List<GameObject> unitHealthTUIList = new List<GameObject>();
    [SerializeField] List<GameObject> unitEnergyTUIList = new List<GameObject>();

    private GameObject healthBarRefrence;
    private GameObject nameTextRefrence;
    private GameObject healthTextRefrence;
    private GameObject energyTextRefrence;


    #endregion

    //public HealthBarScript healthBar;


    private void Awake()
    {
        #region Scaling all stats
        scaling = 1f + ((level - 1f) * 0.1f);
        physicalDamage = (basePhysicalDamage * scaling);
        spellDamage = (baseSpellDamage * scaling);
        armour = (baseArmour * scaling);
        magicResist = (baseMagicResist * scaling);
        maxHp = (baseMaxHp * scaling);
        #endregion

        BattleManager = GameObject.Find("BattleManagerHolder");
        SpellBook = GameObject.Find("Spellbookholder");
        statModifyer = GameObject.Find("statScriptHolder");
        unitName = this.name;
        me = this.gameObject;
        
        //SetName();
        //TESTING- Tho it's working nicely
        attack1IDList.Add(1); //assign spesific spell on all 4
        attack2IDList.Add(3);
        attack3IDList.Add(5);
        attack4IDList.Add(6);

        AggroWeightCalculation();
        ExperienceTresholdCalc();

        //This is temporairy. units should not heal to max on each fight
        currentHp = maxHp;
        currentEnergy = maxEnergy;
        //updateHealthbar();

        //healthBar.SetMaxHealth(maxHp);   

        if (isEnemy)       // not in use (UI)
        {
            uiListCounter += 4;
        }
        UIRefrence();

        AddToList();
    }


   public void UpdateStats(float newlevel, float newexperience, float newenergy, float newhp)
    {
        level = newlevel;
        experience = newexperience;
        //currentEnergy = newenergy; Removed, so game can be played longer
        currentHp = newhp;
        Debug.Log(this + " should have updated stats");
        updateHealthbar();
    }

    public void updateHealthbar() //Not in use (UI)
    {
        if (healthBarRefrence != null)
        {
            healthBarRefrence.GetComponent<HealthBarScript>().SetMaxHealth(maxHp);
            healthBarRefrence.GetComponent<HealthBarScript>().SetHealth(currentHp);
            healthTextRefrence.GetComponent<Text>().text = (currentHp + " / " + maxHp);
        }
        else
        {
            Debug.Log(me + " no healthbar refrence");
        }
        //healthBar.SetHealth(currentHp);
        //Debug.Log("Ui officially updated");
    }

    public void AssignUi(int index)
    {
        if (!isEnemy)
        {
            healthBarRefrence = unitHpUIList[index];
            nameTextRefrence = unitNameTUIList[index];
            healthTextRefrence = unitHealthTUIList[index];
            energyTextRefrence = unitEnergyTUIList[index];
        }
        else
        {
            healthBarRefrence = unitHpUIList[index + uiListCounter];
            nameTextRefrence = unitNameTUIList[index + uiListCounter];
            healthTextRefrence = unitHealthTUIList[index + uiListCounter];
            energyTextRefrence = unitEnergyTUIList[index + uiListCounter];
        }
        
        SetName();
        SetEnergy();
        updateHealthbar();
    }

    public void TakePhysDamage(float physdmg)
    {

        if (physdmg - armour >= 1)
        {
            currentHp -= physdmg - armour;

            if (healthBarRefrence != null)
            {
                updateHealthbar();
            }
        }
        else //add spice
        {
            //damage negated
           // Debug.Log(unitName + " I am standong strong");
           // Debug.Log(unitName + "didn't take " + physdmg + "damage" + "minus " + armour);
        }
        //updateHealthbar(); //Not in use (UI)
        if (currentHp <= 0)
        {
            if (isEnemy)
            {
                DeathReward();
                BattleManager.GetComponent<BattleManager_reworked>().enemyUnitDied(me);
            }
            else
            {
                BattleManager.GetComponent<BattleManager_reworked>().heroUnitDied(me);
            }
            me.SetActive(false);
        }

        updateHealthbar(); //Not in use (UI)
    }
    //how we calculate Spell damage dealt
    public void TakeMagicDamage(float magicdmg)
    {
        if (magicdmg - magicResist >= 1)
        {
            currentHp -= magicdmg - magicResist;
            if (healthBarRefrence != null)
            {
                updateHealthbar();
            }
        }
        else //Add spice
        {
            //damage negated
        }
        //updateHealthbar(); //Not in use (UI)
        if (currentHp <= 0)
        {
            if (isEnemy)
            {
                DeathReward();
                BattleManager.GetComponent<BattleManager_reworked>().enemyUnitDied(me);
            }
            else
            {
                BattleManager.GetComponent<BattleManager_reworked>().heroUnitDied(me);
            }
            me.SetActive(false);
        }


    }

    private void SetName()
    {
        if (unitName == null)
        {
            unitName = this.name;
        }

        if (unitName != null)
        {
            nameTextRefrence.GetComponent<Text>().text = unitName;
        }


    }

    private void SetEnergy()
    {
        energyTextRefrence.GetComponent<Text>().text = (currentEnergy + " / " + maxEnergy);

    }
    public void spendEnergy(float energy)
    {
        if (energy <= currentEnergy)
        {
            currentEnergy -= energy;
            SetEnergy();
        }
        else
        {
            Debug.Log(unitName + " has no energy");
        }
        
    }

    private void AddToList()
    {
        if (!isEnemy) //ads the unit to "battlemanagers" heroList
        {
            BattleManager.GetComponent<BattleManager_reworked>().HeroCloneList(this.gameObject);
            statModifyer.GetComponent<StatModifyer_Script>().AddToCloneList(this.gameObject);
        }
        else if (isEnemy) //ads the unit to "battlemanagagers" enemyList
        {
            BattleManager.GetComponent<BattleManager_reworked>().EnemyCloneList(this.gameObject);
        }
    }

    private void UIRefrence() // Horrible sight. this gets called on max 8 units at the start of combat. Can be redused by 8 times, if put in BattleManager
    {
        #region healthBars
        //find HealthBars
        GameObject hbh1 = GameObject.Find("HealthBarH1");
        GameObject hbh2 = GameObject.Find("HealthBarH2");
        GameObject hbh3 = GameObject.Find("HealthBarH3");
        GameObject hbh4 = GameObject.Find("HealthBarH4");
        GameObject hbe1 = GameObject.Find("HealthBarE1");
        GameObject hbe2 = GameObject.Find("HealthBarE2");
        GameObject hbe3 = GameObject.Find("HealthBarE3");
        GameObject hbe4 = GameObject.Find("HealthBarE4");
        //add to list
        unitHpUIList.Add(hbh1);
        unitHpUIList.Add(hbh2);
        unitHpUIList.Add(hbh3);
        unitHpUIList.Add(hbh4);
        unitHpUIList.Add(hbe1);
        unitHpUIList.Add(hbe2);
        unitHpUIList.Add(hbe3);
        unitHpUIList.Add(hbe4);
        #endregion
        #region Name Text
        //find Name text
        GameObject nth1 = GameObject.Find("Display NameH1");
        GameObject nth2 = GameObject.Find("Display NameH2");
        GameObject nth3 = GameObject.Find("Display NameH3");
        GameObject nth4 = GameObject.Find("Display NameH4");
        GameObject nte1 = GameObject.Find("Display NameE1");
        GameObject nte2 = GameObject.Find("Display NameE2");
        GameObject nte3 = GameObject.Find("Display NameE3");
        GameObject nte4 = GameObject.Find("Display NameE4");
        //add to list
        unitNameTUIList.Add(nth1);
        unitNameTUIList.Add(nth2);
        unitNameTUIList.Add(nth3);
        unitNameTUIList.Add(nth4);
        unitNameTUIList.Add(nte1);
        unitNameTUIList.Add(nte2);
        unitNameTUIList.Add(nte3);
        unitNameTUIList.Add(nte4);
        #endregion
        #region healthText
        //find Health Text
        GameObject hth1 = GameObject.Find("Display HealthH1");
        GameObject hth2 = GameObject.Find("Display HealthH2");
        GameObject hth3 = GameObject.Find("Display HealthH3");
        GameObject hth4 = GameObject.Find("Display HealthH4");
        GameObject hte1 = GameObject.Find("Display HealthE1");
        GameObject hte2 = GameObject.Find("Display HealthE2");
        GameObject hte3 = GameObject.Find("Display HealthE3");
        GameObject hte4 = GameObject.Find("Display HealthE4");
        //add to list
        unitHealthTUIList.Add(hth1);
        unitHealthTUIList.Add(hth2);
        unitHealthTUIList.Add(hth3);
        unitHealthTUIList.Add(hth4);
        unitHealthTUIList.Add(hte1);
        unitHealthTUIList.Add(hte2);
        unitHealthTUIList.Add(hte3);
        unitHealthTUIList.Add(hte4);
        #endregion
        #region Energy Text
        //find Energy Text
        GameObject eth1 = GameObject.Find("Display EnergyH1");
        GameObject eth2 = GameObject.Find("Display EnergyH2");
        GameObject eth3 = GameObject.Find("Display EnergyH3");
        GameObject eth4 = GameObject.Find("Display EnergyH4");
        GameObject ete1 = GameObject.Find("Display EnergyE1");
        GameObject ete2 = GameObject.Find("Display EnergyE2");
        GameObject ete3 = GameObject.Find("Display EnergyE3");
        GameObject ete4 = GameObject.Find("Display EnergyE4");
        //add to list
        unitEnergyTUIList.Add(eth1);
        unitEnergyTUIList.Add(eth2);
        unitEnergyTUIList.Add(eth3);
        unitEnergyTUIList.Add(eth4);
        unitEnergyTUIList.Add(ete1);
        unitEnergyTUIList.Add(ete2);
        unitEnergyTUIList.Add(ete3);
        unitEnergyTUIList.Add(ete4);
        #endregion
    }

    public void AttackOne(GameObject enemy)
    {
        currentAttackIDList.Add(attack1IDList[0]);
        AttackSpell(enemy);
        currentAttackIDList.Remove(0);

        //attack1BoolList[0] = true;
        //AttackSpell(enemy);
        //attack1BoolList[0] = false;
    }

    public void AttackTwo(GameObject enemy)
    {
        currentAttackIDList.Add(attack2IDList[0]); //uses 1 list for all Currentskills, and is used to refrence skill ID 
        AttackSpell(enemy);
        currentAttackIDList.Remove(0); //Removes examle "fireBall" so another skill can be assigned next
    }

    public void AttackThree(GameObject enemy)
    {
        currentAttackIDList.Add(attack3IDList[0]);
        AttackSpell(enemy);
        currentAttackIDList.Remove(0);
    }

    public void AttackFour(GameObject enemy)
    {
        currentAttackIDList.Add(attack4IDList[0]);
        AttackSpell(enemy);
        currentAttackIDList.Remove(0);
    }

    private void AggroWeightCalculation()
    {
        if (!isEnemy)
        {

            if (isTank)
            {
                aggroWeight = 400; //simple AggroWeight distribution. should be changed.
            }
            else if (isDps)
            {
                aggroWeight = 250;
            }
            else if (isElusive)
            {
                aggroWeight = 125;
            }
            else
            {
                Debug.Log(me + " is Weightless?");
            }
        }
    }

    private void AttackSpell(GameObject enemy) // can be improved in so many ways
    {
        if (currentAttackIDList[0] == 1)
        {
            SpellBook.GetComponent<AttackSpellScript>().AutoAttack1(physicalDamage, spellDamage, me, enemy);
        }
        else if (currentAttackIDList[0] == 2)
        {
            SpellBook.GetComponent<AttackSpellScript>().AutoAttack2(physicalDamage, me, enemy);
        }
        else if (currentAttackIDList[0] == 3)
        {
            SpellBook.GetComponent<AttackSpellScript>().Slap(physicalDamage, me, enemy);
            Debug.Log("Slap");
        }
        else if (currentAttackIDList[0] == 4)
        {
            SpellBook.GetComponent<AttackSpellScript>().Smash(physicalDamage, me, enemy);
        }
        else if (currentAttackIDList[0] == 5)
        {
            SpellBook.GetComponent<AttackSpellScript>().FireBall(spellDamage, me, enemy);
        }
        else if (currentAttackIDList[0] == 6)
        {
            SpellBook.GetComponent<AttackSpellScript>().FrostBolt(spellDamage, me, enemy);
        }
    }


    public void GainXP(float mobExperience) //Gain XP at end of fight
    {
        ExperienceTresholdCalc();

        experience += mobExperience;

        if (experience >= experienceTreshold)
        {
            experience -= experienceTreshold;
            //experienceTreshold -= experience;
            level += 1;
            ExperienceTresholdCalc();
        }
    }

    private void ExperienceTresholdCalc() //calculation of how much experience is needed per level
    {
        if (level > 1)
        {
            experienceTreshold = (100f * (((level - 1) * 0.1f) + 1));
        }
        else 
        {
            experienceTreshold = 100;
        }
    }

    private void DeathReward() //only used by "Enemies"
    {
        xpReward = 10 * level;
        BattleManager.GetComponent<BattleManager_reworked>().addToExperiencePool(xpReward);
    }

}
