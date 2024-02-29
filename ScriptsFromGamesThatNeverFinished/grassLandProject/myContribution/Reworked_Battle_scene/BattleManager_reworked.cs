using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;




//testing out how to change states, as to easier controll battle
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleManager_reworked : MonoBehaviour
{
    private GameObject me;
    public BattleState state;
    [SerializeField] private GameObject statModifyerScript;

    #region Hero
    [Header("Heroes")]

    [SerializeField] public List<GameObject> heroList = new List<GameObject>();
    [SerializeField] private List<GameObject> deadHeroList = new List<GameObject>();
                     private List<GameObject> heroCloneList = new List<GameObject>();
    [Header("Hero Spots")]

    [SerializeField] List<Transform> heroSpotList = new List<Transform>();

    private GameObject heroPrefab;
    private int heroListCounter = 0;
    private int heroAmount;
    private int attackOrderHero;
    private int hCloneCounter;

    #endregion
    #region enemy
    [Header("Enemies")]

    [SerializeField] public List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private List<GameObject> deadEnemyList = new List<GameObject>();
                     private List<GameObject> enemyCloneList = new List<GameObject>();

    [Header("Enemy position")]
    [SerializeField] List<Transform> enemySpotList = new List<Transform>();

    [Header("Enemies")]

    private int enemyListCounter = 0;
    private int enemyAmount;
    private int attackOrderEnemy = 0;
    private int eCloneCounter;

    private GameObject clickedEnemy;

    //is used for calculation on hero's aggro weight. Nut sure where proper location should be.
    [SerializeField] private List<int> heroAggroWeightList = new List<int>();

    #endregion
    #region uI list
    [SerializeField] List<GameObject> heroUIList = new List<GameObject>();

    //Buttons
    [SerializeField] private GameObject buttonOne;
    [SerializeField] private GameObject buttonTwo;
    [SerializeField] private GameObject buttonThree;
    [SerializeField] private GameObject buttonFour;
    private bool heroButtonBool = false;

    [SerializeField] GameObject endGameTextObject;
    [SerializeField] Text endGameText;
    [SerializeField] GameObject ExitBattleButton;
    #endregion

    #region others
    [SerializeField] private float experiencePool; //collection of all experience reward from enemies
    private bool hLCounted = false; //heroList Counted
    private bool dHLCounted = false; //deadHeroList Counted
    //Aggro weight
    private int weightNumber;
    //for random generator
    private int randomNumber;
    private int lastRandomNumber;

    private int maxValue;
    private int maxIndex;
    //Loot
    private string loot1 = "poop";
    private string loot2 = "coin";
    private string loot3 = "angeltears";
    private string loot4 = "Legendary";

    [SerializeField] private int minRoll;
    [SerializeField] private int maxRoll;

    private int listIndex;
    #endregion

    [Header ("Indicator")]
    #region Indicators

    [SerializeField] private GameObject clickedEnemyIndicator;  

    #endregion

    void Start()
    {
        me = this.gameObject;
        CopyList();
        heroAmount = heroList.Count;
        enemyAmount = enemyList.Count;
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(heroAmount + " hero amount");
        Debug.Log("hero atatck order " + attackOrderHero); //Simply to see who's attacking per now
    }
    IEnumerator SetupBattle()
    {
        //heroAmount = heroList.Count;
        //enemyAmount = enemyList.Count;
        heroList = heroList.OrderBy(Hero => Hero.GetComponent<Stat_Script>().Speed).ToList();    //sorts herolist by SPEED
        enemyList = enemyList.OrderBy(enemy => enemy.GetComponent<Stat_Script>().Speed).ToList(); //sorts enemyLost by SPEED
        HeroSpawner(heroListCounter);
        EnemySpawner(enemyListCounter);
        statModifyerScript.GetComponent<StatModifyer_Script>().giveStats();
        //fuctionUI;
        yield return new WaitForSeconds(1); //wait 1 secounds before battle "starts"
        AssignHeroUi();
        AssignEnemyUi();
        statModifyerScript.GetComponent<StatModifyer_Script>().ClearList();
        OrderChangingUnits();
        FirstAttacker();
    }

    private void CopyList()
    {
        statModifyerScript = GameObject.FindWithTag("StatScriptHolder");
        statModifyerScript.GetComponent<StatModifyer_Script>().BattleStart(me);
        heroList = statModifyerScript.GetComponent<StatModifyer_Script>().heroModifyerList;
        //Debug.Log("should copy list now");

    }
    //void functionUI()  //would be for UI
    //{ }

    public void HeroCloneList(GameObject hero)
    {
        heroCloneList.Add(hero);
    }

    public void EnemyCloneList(GameObject enemy)
    {
        enemyCloneList.Add(enemy);
    }


    void HeroSpawner(int listCounter)
    {
        if (listCounter != heroAmount)
        {
            Instantiate(heroList[0], heroSpotList[listCounter]);
            heroList.RemoveAt(0);
            listCounter += 1;
            HeroSpawner(listCounter);
        }
        if (listCounter == heroAmount)
        {
            
            //heroCloneList();
            //Debug.Log("finished counting down!");
            listCounter = 0;
        }
    }

    private void AssignHeroUi()
    {
        heroList = heroCloneList;
        //Debug.Log(heroAmount + " is AssignHeroHpBar number");
        for (int heroUiListCounter = 0; heroUiListCounter < heroAmount; heroUiListCounter++)
        {
            heroList[heroUiListCounter].GetComponent<Stat_Script>().AssignUi(heroUiListCounter);
        }
    }

    void EnemySpawner(int listCounter)
    {
        if (listCounter != enemyAmount)
        {
            Instantiate(enemyList[0], enemySpotList[listCounter]);
            enemyList.RemoveAt(0);
            listCounter += 1;
            EnemySpawner(listCounter);
        }
        if (listCounter == enemyAmount)
        {
            //Debug.Log("finished counting down!");
        }
    }

    private void AssignEnemyUi()
    {
        enemyList = enemyCloneList;
        //Debug.Log("enemyAmount" + " is AssignEnemyHpBar number");

        for (int enemyUiListCounter = 0; enemyUiListCounter < enemyAmount; enemyUiListCounter++)
        {
            enemyList[enemyUiListCounter].GetComponent<Stat_Script>().AssignUi(enemyUiListCounter);
        }
    }

    void FirstAttacker()
    {
        Debug.Log("FirstAttacker");
        //heroList = heroCloneList;
        //enemyList = enemyCloneList;
        //Debug.Log("e" + enemyList + " h" + heroList);
        if (clickedEnemy == null)
        {
            ClickedEnemy(enemyList[0]);
        }
        heroListCounter = heroList.Count - 1; //listcount will be 4, and list is 0,1,2,3  so we do -1
        enemyListCounter = enemyList.Count - 1;
        //Debug.Log(heroListCounter + " h + e " + enemyListCounter);
        if (heroList[heroListCounter].GetComponent<Stat_Script>().Speed >= enemyList[enemyListCounter].GetComponent<Stat_Script>().Speed)
        {
            Playerturn(attackOrderHero);
            Debug.Log("Playerturn");
        }
        else
        {
            StartCoroutine(EnemyTurn(attackOrderEnemy));
            //EnemyTurn(attackOrderEnemy);
            Debug.Log("enemyTurn");
        }
    }

    void Playerturn(int attackOrderHero)
    {

        if ((attackOrderHero > -1) && (attackOrderHero < 5))
        {
            state = BattleState.PLAYERTURN;
            ButtonEnabler();
            Debug.Log("playerturn");

        }
        else
        {
            heroAmount = heroList.Count;
            attackOrderHero = heroAmount - 1;
            state = BattleState.PLAYERTURN;
            ButtonEnabler();
            Debug.Log("playerturn");
        }

    }

    public IEnumerator EnemyTurn(int enemyAttackOrder) //Add timer, or else it happens in 0.1 secound // JUST CHANGED SHIT SO IS BROKEN
    {
        if (state != BattleState.WON && state != BattleState.LOST)
        {

        

        ButtonEnabler(); //disables buttons


        yield return new WaitForSeconds(1);

        heroAmount = heroList.Count;
        heroListCounter = 0;
        EnemyTarget();
        FindHighestWeight();
        enemyAmount = enemyList.Count;



            if ((enemyAttackOrder < -1) || (enemyAttackOrder >= enemyAmount))
            {
            Debug.Log("checker in enemyturn has been called");
            enemyAttackOrder = enemyAmount - 1;
            }
        Debug.Log(enemyAttackOrder + " so what is wrong here??!?!?! 2.0");
        state = BattleState.ENEMYTURN;


        enemyList[enemyAttackOrder].GetComponent<Stat_Script>().AttackOne(heroList[maxIndex]);
        //heroAggroWeightList.Clear(); // is in EnemyTarget function, so we can see the last weights. enable this for "faster" clear.

        Debug.Log("enemy attacking Back");
        OrderChangingUnits();
        Debug.Log(attackOrderHero + " could it be attackOrderHero?");
        Playerturn(attackOrderHero);
        }
    }

    private void AssignUIHero(int listCounter)
    {
        if (listCounter != heroAmount)
        {

           // heroList[listCounter].unitAssignUI(listCounter);

        }
    }

    private void AssignUIEnemy()
    {

    }

    public void ButtonOneFunction()
    {
        heroList[attackOrderHero].GetComponent<Stat_Script>().AttackOne(clickedEnemy);
        OrderChangingUnits();

        StartCoroutine(EnemyTurn(attackOrderEnemy));
        //EnemyTurn(enemyListCounter);
    }

    public void ButtonTwoFunction()
    {
        heroList[attackOrderHero].GetComponent<Stat_Script>().AttackTwo(clickedEnemy);
        OrderChangingUnits();

        StartCoroutine(EnemyTurn(attackOrderEnemy));
        //EnemyTurn(enemyListCounter);
    }

    public void ButtonThreeFunction()
    {
        heroList[attackOrderHero].GetComponent<Stat_Script>().AttackThree(clickedEnemy);
        
        OrderChangingUnits();

        StartCoroutine(EnemyTurn(attackOrderEnemy));
        //EnemyTurn(enemyListCounter);
    }

    public void ButtonFourFunction()
    {
        heroList[attackOrderHero].GetComponent<Stat_Script>().AttackFour(clickedEnemy);
        OrderChangingUnits();

        StartCoroutine(EnemyTurn(attackOrderEnemy));
        //EnemyTurn(enemyListCounter);
    }

    private void EnemyTarget()
    {
        //perr now we get random number, and if it's the same number twice, we roll again.
        //This prevents 2 heroes in order, from getting same number.
        //there is still chance for hero 1-3/4 and 2-4 to get same number. if they have same weight, this will be an issue
        //Eather make better failsafe, or roll again on heroes with same number.

        heroAggroWeightList.Clear();// put in EnemyTurn, to clear faster. Here is for "Debugging/keeping track"
        for (int heroListCounter = 0; heroListCounter < (heroAmount); heroListCounter++)
            {
            weightNumber = heroList[heroListCounter].GetComponent<Stat_Script>().aggroWeight;
            randomNumber = Random.Range(1, 101);
            if(randomNumber == lastRandomNumber)
            {
                randomNumber = Random.Range(1, 101);
            }
            lastRandomNumber = randomNumber;
            weightNumber = weightNumber * randomNumber;
            heroAggroWeightList.Add(weightNumber);
            }
    }
    
    private void FindHighestWeight()
    {
        maxValue = heroAggroWeightList.Max(); //finds higest number in list
        Debug.Log("maxValue" + maxValue);
        maxIndex = heroAggroWeightList.IndexOf(maxValue); //finds index of highest number
        Debug.Log("maxIndex" + maxIndex);
    }

    public void ClickedEnemy(GameObject enemy)
    {
        //onclick script enemies, that pass in "this unit" on click
        clickedEnemy = enemy;
        clickedEnemyIndicator.transform.position = new Vector3(clickedEnemy.transform.position.x, 0.2f, clickedEnemy.transform.position.z);
    }

    private void OrderChangingUnits()
    {
        //START sets up attackOrder
        //PLAYERTURN reduces order by one, and "resets" order if it goes below 0. (happens after hero has attacked)
        //ENEMYTURN reduces order by one, and "resets" order if it goes below 0. (happens after enemy attacks)
        //WON runs GameWin function
        //LOST runs GameLost function

        if (state is BattleState.START)
        {
            Debug.Log("changing attackorder");
            attackOrderHero = heroAmount - 1;
            attackOrderEnemy = enemyAmount - 1;
        }
        else if (state is BattleState.PLAYERTURN)
        {
            attackOrderHero -= 1;

            if (attackOrderHero <= -1)
            {
                attackOrderHero = heroAmount -1;

            }
        }
        else if (state is BattleState.ENEMYTURN)
        {
            //enemyAmount = enemyList.Count;
            attackOrderEnemy -= 1;

            if (attackOrderEnemy <= -1)
            {
                attackOrderEnemy = enemyAmount -1;

            }

        }
        else if (state is BattleState.WON)
        {

            GameWin();

        }
        else if (state is BattleState.LOST)
        {
            GameLost();

        }
        else
        {
            Debug.Log("Somehow. there is no state?");
        }
    }

    public void heroUnitDied(GameObject hero)
    {

        if (attackOrderHero == (heroAmount - 1)) //checks if last hero in list is attacking next.
        {
            attackOrderHero -= 1; // if so, reduse attackordercounter by one. BECAUSE attack order would call an index higher than what we got.
        }
        deadHeroList.Add(hero);
        listIndex = heroList.IndexOf(hero);
        heroList.Remove(hero);
        statModifyerScript.GetComponent<StatModifyer_Script>().RemoveHero(listIndex); //this list contains the prefab, therefore "removing clone" won't work
        statModifyerScript.GetComponent<StatModifyer_Script>().RemoveClone(hero);
        heroAmount = heroList.Count;


        if (heroAmount <= 0)
        {
            state = BattleState.LOST; //OrderChangingUnits is checked after each attack.
        }
        
    }

    public void enemyUnitDied(GameObject enemy)
    {
        if (attackOrderEnemy == (enemyAmount - 1)) //checks if last enemy in list is attacking next.
        {
            attackOrderEnemy -= 1; // if so, reduse attackordercounter by one. BECAUSE attack order would call an index higher than what we got.
        }

        //Might need checker for Indexnumber, same as with hero
        deadEnemyList.Add(enemy);
        enemyList.Remove(enemy);
        enemyAmount = enemyList.Count;

        if (enemyAmount > 0)
        {
            ClickedEnemy(enemyList[0]);
        }
        else if (enemyAmount <= 0)
        {
            state = BattleState.WON; //OrderChangingUnits is checked after each attack.
        }
    }

    public void addToExperiencePool(float xp)
    {
        experiencePool += xp;
    }

    private void heroXpReward()
    {
        //should be reworked
        if (!hLCounted)
        {
            if (heroListCounter <= (heroAmount - 1))
            {
                heroList[heroListCounter].GetComponent<Stat_Script>().GainXP(experiencePool);
                Debug.Log("heroList " + heroListCounter);
                heroListCounter += 1;


                if (heroListCounter > heroAmount - 1)
                {
                    hLCounted = true;
                }

                heroXpReward();

                
            }
        }
    }

    private void deadHeroXpReward() //gives dead heroes XP, REMOVE
    {
        //should be reworked
        if (!dHLCounted)
        {
            if (heroListCounter <= (heroAmount - 1))
            {
                deadHeroList[heroListCounter].GetComponent<Stat_Script>().GainXP(experiencePool);
                Debug.Log("deadHeroList" + heroListCounter);
                heroListCounter += 1;

                if (heroListCounter > heroAmount - 1)
                {
                    dHLCounted = true;
                }
                deadHeroXpReward();
            }
        }
    }

    public void ButtonEnabler()
    {
        if (state != BattleState.WON && state != BattleState.LOST)
        {
            if (!heroButtonBool)
            {

                buttonOne.SetActive(true);
                buttonTwo.SetActive(true);
                buttonThree.SetActive(true);
                buttonFour.SetActive(true);
                heroButtonBool = true;
            }
            else
            {
                buttonOne.SetActive(false);
                buttonTwo.SetActive(false);
                buttonThree.SetActive(false);
                buttonFour.SetActive(false);
                heroButtonBool = false;
            }
        }
        else
        {
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            buttonThree.SetActive(false);
            buttonFour.SetActive(false);
            heroButtonBool = false;
        }
    }

    public void Loot() //aware that these strings create alot of GARBAGE
    {
        enemyListCounter = deadEnemyList.Count;
        minRoll = 1;
        maxRoll = 101;

        for (int i = 0; i < enemyListCounter; i++ )
        {
            randomNumber = Random.Range(minRoll,maxRoll);
            if (randomNumber > 0 && randomNumber <= 40) //MinRoll increases, if number hits between 0-40
            {
                minRoll += 10;
                randomNumber = Random.Range(1,5);
                Debug.Log("loot " + randomNumber + " " + loot1);
            }
            else if (randomNumber > 40 && randomNumber <= 70) //minRoll increases, if number hits between 40-70
            {
                minRoll += 5;
                randomNumber = Random.Range(2000,5000);
                Debug.Log("loot " + randomNumber + " " + loot2);
            }
            else if (randomNumber > 70 && randomNumber <= 90)
            {
                randomNumber = Random.Range(5,6);
                Debug.Log("loot " + randomNumber + " " + loot3);
            }
            else if (randomNumber > 90 && randomNumber <= 100)//maxRoll increases, if number hits between 90-100;
            {
                maxRoll -= 5;
                randomNumber = Random.Range(1,2);
                Debug.Log("loot " + randomNumber + " " + loot4);
            }
        }
    }

    private void GameWin()
    {
        heroAmount = heroList.Count;
        heroListCounter = 0;
        heroXpReward();

        heroAmount = deadHeroList.Count;
        heroListCounter = 0;
        deadHeroXpReward();

        ButtonEnabler();
        endGameTextObject.SetActive(true);
        endGameText.text = ("You WON!");
        ExitBattleButton.SetActive(true);
        Loot();
        statModifyerScript.GetComponent<StatModifyer_Script>().GameResultSaver();
        statModifyerScript.GetComponent<StatModifyer_Script>().ClearCloneList();

    }

    private void GameLost()
    {
        Debug.Log("You LOST! looser...");
        ButtonEnabler();

        endGameTextObject.SetActive(true);
        endGameText.text = ("You LOST!");
        //statModifyerScript.GetComponent<StatModifyer_Script>().GameResultSaver();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(1);
    }

}
