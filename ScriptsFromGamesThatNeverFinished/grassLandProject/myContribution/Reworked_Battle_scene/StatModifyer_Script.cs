using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StatModifyer_Script : MonoBehaviour
{
    [SerializeField] GameObject BattleManager;
    [SerializeField] public List<GameObject> heroModifyerList = new List<GameObject>();
    [SerializeField] private List<GameObject> heroModifyerCloneList = new List<GameObject>();
    

    #region saveStats

    //Saves stats for the next battle
    //private int listCounter;
    private int heroListAmount = 4;
    private float floatvariable;
    [SerializeField] private bool firstBattle = true;

    #region Lists

    [SerializeField] List<float> heroLevelList = new List<float>();
    [SerializeField] List<float> heroExperienceList = new List<float>();
    [SerializeField] List<float> heroCurrentEnergyList = new List<float>();
    [SerializeField] List<float> heroCurrentHpList = new List<float>();

    #endregion

    #endregion


    private void Awake()
    {

        ////LAST USED
        //BattleManager = GameObject.Find("BattleManagerHolder");
        //heroModifyerList = BattleManager.GetComponent<BattleManager_reworked>().heroList;

        //heroListAmount = heroModifyerList.Count;
    }
    void Start()
    {
        DontDestroyOnLoad(this);


    }

    public void BattleStart(GameObject CurrentBattleManager)
    {
        
        BattleManager = CurrentBattleManager;
        //heroModifyerList = BattleManager.GetComponent<BattleManager_reworked>().heroList;
        heroListAmount = heroModifyerList.Count;
        heroModifyerList = heroModifyerList.OrderBy(Hero => Hero.GetComponent<Stat_Script>().Speed).ToList();
        //savestats();

    }

    public void CopyList()
    {
        heroModifyerList = BattleManager.GetComponent<BattleManager_reworked>().heroList;
        Debug.Log("copying list to mmodifyer");
    }

    public void AddToCloneList(GameObject hero)
    {
        heroModifyerCloneList.Add(hero);
    }

    public void RemoveClone(GameObject hero)
    {
        heroModifyerCloneList.Remove(hero);
    }
    public void RemoveHero(int hero)
    {
        heroModifyerList.RemoveAt(hero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void scaleByItem()
    {
        //function should be something like=
        //
        //      "copy"/"Get" item list from "ItemList_Script"
        //      Get values from said Item
        //      increase % of stats or increase + of stats accordingly
        //   
    }

    public void giveStats()
    {
        if (!firstBattle)
        {


            heroListAmount = heroModifyerCloneList.Count;

            for (int listCounter = 0; listCounter < heroListAmount; listCounter++)
            {
                heroModifyerCloneList[listCounter].GetComponent<Stat_Script>().UpdateStats(heroLevelList[listCounter], heroExperienceList[listCounter], heroCurrentEnergyList[listCounter], heroCurrentHpList[listCounter]);
            }

        }
        else
        {
            firstBattle = false;
            
        }
    }

    public void GameResultSaver()
    {
        savestats();
    }
    void savestats() //foreach loop might get rid of if statement. Revisit at better time
    {
        heroListAmount = heroModifyerCloneList.Count;
        if (heroListAmount != 1) 
        {


            for (int listCounter = 0; listCounter < heroListAmount; listCounter++)
            {
                //save level
                floatvariable = heroModifyerCloneList[listCounter].GetComponent<Stat_Script>().level;
                heroLevelList.Add(floatvariable);

                //Experience
                floatvariable = heroModifyerCloneList[listCounter].GetComponent<Stat_Script>().experience;
                heroExperienceList.Add(floatvariable);

                //Current Energy
                floatvariable = heroModifyerCloneList[listCounter].GetComponent<Stat_Script>().currentEnergy;
                heroCurrentEnergyList.Add(floatvariable);

                //save CurrentHp
                floatvariable = heroModifyerCloneList[listCounter].GetComponent<Stat_Script>().currentHp;
                heroCurrentHpList.Add(floatvariable);

            }
        }
        else
        {
            //save level
            floatvariable = heroModifyerCloneList[0].GetComponent<Stat_Script>().level;
            heroLevelList.Add(floatvariable);

            //Experience
            floatvariable = heroModifyerCloneList[0].GetComponent<Stat_Script>().experience;
            heroExperienceList.Add(floatvariable);

            //Current Energy
            floatvariable = heroModifyerCloneList[0].GetComponent<Stat_Script>().currentEnergy;
            heroCurrentEnergyList.Add(floatvariable);

            //save CurrentHp
            floatvariable = heroModifyerCloneList[0].GetComponent<Stat_Script>().currentHp;
            heroCurrentHpList.Add(floatvariable);
        }
           
    }

    public void ClearList()
    {
        heroLevelList.Clear();
        heroExperienceList.Clear();
        heroCurrentEnergyList.Clear();
        heroCurrentHpList.Clear();

    }
    public void ClearCloneList()
    {
        heroModifyerCloneList.Clear();
    }
}

