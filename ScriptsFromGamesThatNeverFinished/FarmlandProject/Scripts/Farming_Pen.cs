using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Farming_Pen : MonoBehaviour
{
    
    public enum Colour { Green, Blue, Red, Yellow};
    [SerializeField] private Colour colour;
    [SerializeField] private int colourInt;

    private SlimeManager slimeManagerScript;

    public GameObject thisPen;
    public GameObject slimeManager;

    private int money;
    [SerializeField] private List<GameObject> SlimePrefab = new List<GameObject>();

    [SerializeField] private bool hasWorker = false;

    public int slimeCost;
    public int slimeLimitCost;
    public int income;
    private int singleSlimeIncome;
    public int slimeAmount;
    public int slimeLimit;

    [SerializeField] private int blobCount;
    private int blobCountLimit = 30;
    private int blobTimer;


    public List <GameObject> slimeSpots = new List<GameObject>();
    private int maxRoll = 10;
    #region Text-refrence
    public Text costButton;
    public Text LimitCostText;
    public Text IncomeText;
    public Text SlimeAmountText;
    public Text slimeLimitText;
    
    public Text blobCountText;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        slimeManager = GameObject.FindWithTag("SlimeManager");
        AssignIntToEnum();
        //SpawnSlime();
        thisPen = this.gameObject;
        slimeManagerScript = slimeManager.GetComponent<SlimeManager>();


        if (slimeAmount == 1)
        {
            SpawnSlime();
            slimeManager.GetComponent<SlimeManager>().IncreaseGreen();
        }
        income = (singleSlimeIncome * slimeAmount);
        StartCoroutine(BlobGainer());
        StartCoroutine(AutoSellBlobs());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        
    }

    private void AssignIntToEnum()
    {
        colourInt = GetColourInt(colour);
        slimeLimit = GetSlimeLimit(colour);
        slimeCost = GetSlimeCost(colour);
        singleSlimeIncome = GetSingleSlimeIncome(colour);
        slimeLimitCost = GetSlimeLimitCost(colour);
        blobTimer = GetBlobTimer(colour);
    }

    private int GetColourInt (Colour colour)
    {
        //remove default
        switch (colour)
        {
            case Colour.Green: return  0; // colourInt = 0;
            case Colour.Blue: return  1; // colourInt = 1;
            case Colour.Red: return 2; // colourInt = 2;
            case Colour.Yellow: return  3; // colourInt = 3;
            default: return  0; // colourInt = 4;
        }
    }


    private int GetSlimeLimit (Colour colour)
    {
        switch (colour)
        {
            case Colour.Green: return 5;
            case Colour.Blue: return 3;
            case Colour.Red: return 2;
            case Colour.Yellow: return 1;
            default: return 1;
        }
    }


    private int GetSlimeCost (Colour colour)
    {
        switch (colour)
        {
            case Colour.Green: return 5;
            case Colour.Blue: return 25;
            case Colour.Red: return 125;
            case Colour.Yellow: return 625;
            default: return 1;
        }
    }

    private int GetSlimeLimitCost (Colour colour)
    {
        switch (colour)
        {
            case Colour.Green: return 1000;
            case Colour.Blue: return 5000;
            case Colour.Red: return 12500;
            case Colour.Yellow: return 625000;
            default: return 1;

        }
    }

    private int GetSingleSlimeIncome(Colour colour)
    {
        switch (colour)
        {
            case Colour.Green: return 1;
            case Colour.Blue: return 5;
            case Colour.Red: return 25;
            case Colour.Yellow: return 125;
            default: return 0;
        }
    }

    private int GetBlobTimer(Colour colour)
    {
        switch (colour)
        {
            case Colour.Green: return 1;
            case Colour.Blue: return 3;
            case Colour.Red: return 6;
            case Colour.Yellow: return 10;
            default: return 1;
        }
    }

     private IEnumerator BlobGainer()
    {

        yield return new WaitForSeconds(blobTimer);

        if(blobCount < blobCountLimit)
        {
            if((blobCount + (1 * slimeAmount)) >= blobCountLimit)
            {
                blobCount = blobCountLimit;
            }
            else
            {
                blobCount += (1 * slimeAmount);
            }
            
           
        }
        else
        {
            Debug.Log("Pen is full!!");
        }

        StartCoroutine(BlobGainer());
    }

    private IEnumerator AutoSellBlobs()
    {
        if (hasWorker)
        {
            Debug.Log("Should be sellin yoo");
            SellBlob();
        }
        yield return new WaitForSeconds(blobTimer);
        StartCoroutine(AutoSellBlobs());
    }

    public void SellBlob()
    {
        if (blobCount > 0)
        {
            switch (colour)
            {
                case Colour.Green:
                    slimeManagerScript.IncreaseBlobCount(blobCount, 1, singleSlimeIncome);
                    //slimeManagerScript.IncreaseBlobCount(blobCount, 2, singleSlimeIncome);
                    blobCount = 0;
                    break;
                case Colour.Blue:
                    slimeManagerScript.IncreaseBlobCount(blobCount, 2, singleSlimeIncome);
                    blobCount = 0;
                    break;
                case Colour.Red:
                    slimeManagerScript.IncreaseBlobCount(blobCount, 3, singleSlimeIncome);
                    blobCount = 0;
                    break;
                case Colour.Yellow:
                    slimeManagerScript.IncreaseBlobCount(blobCount, 4, singleSlimeIncome);
                    blobCount = 0;
                    break;
                default:
                    Debug.Log("it has no colour my guy");
                    break;
            }
        }
        else
        {
            Debug.Log("Nothing to sell");
        }
    }

    public void BuySlime()
    {
        money = slimeManager.GetComponent<SlimeManager>().moneyCounter;
        Debug.Log("Money: " + money);

        if (slimeAmount < slimeLimit)
        {
              if (money >= slimeCost)
              {
                SpawnSlime();
                slimeAmount += 1;
                income = (singleSlimeIncome * slimeAmount);
                switch (colour)
                {

                        //cashe SLimeManager for better performance
                    case Colour.Green: 
                        slimeManager.GetComponent<SlimeManager>().BuyGreen(slimeCost);
                        slimeCost *= 5;
                        break;
                    case Colour.Blue:
                        slimeManager.GetComponent<SlimeManager>().BuyBlue(slimeCost);
                        slimeCost *= 5;
                        break;
                    case Colour.Red:
                        slimeManager.GetComponent<SlimeManager>().BuyRed(slimeCost);
                        slimeCost *= 5;
                        break;
                    case Colour.Yellow:
                        slimeManager.GetComponent<SlimeManager>().BuyYellow(slimeCost);
                        slimeCost *= 5;
                        break;
                    default:
                        Debug.Log("it has no colour my guy");
                            break;
                }
            }
              else
              {
                Debug.Log("Boi ya broke");
              }
        }
        else
        {
            Debug.Log("can't buy mah boi");
        }
    }

    public void BuySlimeLimit()
    {
        money = slimeManager.GetComponent<SlimeManager>().moneyCounter;
        Debug.Log("Money: " + money);

        if (slimeLimit < 10)
        {
            if (money >= slimeLimitCost)
            {
                slimeLimit += 1;
                switch (colour)
                {

                    //cashe SLimeManager for better performance
                    case Colour.Green:
                        slimeManager.GetComponent<SlimeManager>().BuyGreenLimit(slimeLimitCost);
                        break;
                    case Colour.Blue:
                        slimeManager.GetComponent<SlimeManager>().BuyBlueLimit(slimeLimitCost);
                        break;
                    case Colour.Red:
                        slimeManager.GetComponent<SlimeManager>().BuyRedLimit(slimeLimitCost);
                        break;
                    case Colour.Yellow:
                        slimeManager.GetComponent<SlimeManager>().BuyYellowLimit(slimeLimitCost);
                        break;
                    default:
                        Debug.Log("it has no colour my guy");
                        break;
                }
                slimeLimitCost *= 2;
            }
            else
            {
                Debug.Log("Boi ya broke");
            }
        }
        else
        {
            Debug.Log("can't buy mah boi");
        }
    }

    private void UpdateText()
    {
        costButton.text = ("Cost: " + slimeCost.ToString());
        LimitCostText.text = ("Cost: " + slimeLimitCost.ToString());
        IncomeText.text = ("Income: " + income.ToString());
        SlimeAmountText.text = ("Amount: " + slimeAmount.ToString());
        slimeLimitText.text = ("Limit: " + slimeLimit.ToString());
        blobCountText.text = (blobCount.ToString() + " / " + blobCountLimit.ToString());
    }

    public void SpawnSlime()
    {

        int randomNumber;
        randomNumber = Random.Range(0, maxRoll);
        Instantiate(SlimePrefab[colourInt], new Vector2(slimeSpots[randomNumber].transform.position.x, slimeSpots[randomNumber].transform.position.y), Quaternion.identity);
        slimeSpots.RemoveAt(randomNumber);
        maxRoll -= 1;
    }
}
