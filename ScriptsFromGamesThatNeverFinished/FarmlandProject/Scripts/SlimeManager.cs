using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeManager : MonoBehaviour
{

    public int greenCounter;
    public int blueCounter;
    public int redCounter;
    public int yellowCounter;

    public int boughtGreenPen = 0;
    public int boughtBluePen = 0;
    public int boughtRedPen = 0;
    public int boughtYellowPen = 0;

    public int greenIncome = 1;
    public int blueIncome = 5;
    public int redIncome = 25;
    public int yellowIncome = 125;

    public int moneyAdder;
    public int moneyCounter;

    public int greenBlobTracker;
    public int blueBlobTracker;
    public int redBlobTracker;
    public int yellowBlobTracker;

    public int greenBlobMaxCount = 100;
    public int blueBlobMaxCount = 100;
    public int redBlobMaxCount = 100;
    public int yellowBlobMaxCount = 100;


    //UI text
    public Text moneyText;
    public Text moneyAdderText;

    void Start()
    {
        //Change this!!!!!!
        boughtGreenPen += 1;
        
        //StartCoroutine(PassiveIncome());
    }

    void Update()
    {
        MoneyAdderFunction();
        moneyMaker();
        UpdateText();
    }

    public void MoneyAdderFunction()
    {
        moneyAdder = ((greenIncome * greenCounter) + (blueIncome * blueCounter) + (redIncome * redCounter) + (yellowIncome * yellowCounter));
    }

    public void moneyMaker()
    {
        if (Input.GetKeyDown("space"))
        {
            moneyCounter += moneyAdder;
        }
    }

    public void UpdateText()
    {
        moneyText.text = ("Bank: " + moneyCounter.ToString());
        moneyAdderText.text = ("Income: " + moneyAdder.ToString());
    }

     //private IEnumerator PassiveIncome()
    //{
       // moneyCounter += moneyAdder;
       // yield return new WaitForSeconds(1);
       // StartCoroutine(PassiveIncome());
    //}


    //Remove
    public void IncreaseGreen()
    {
        greenCounter += 1;
    }

    public void IncreaseBlobCount(int blobs, int colourNumber, int blobprice)
    {

        switch (colourNumber)
        {
            case 1:
                greenBlobTracker += blobs;
                moneyCounter += (blobs * blobprice);
                break;
            case 2:
                blueBlobTracker += blobs;
                moneyCounter += (blobs * blobprice);
                break;
            case 3:
                redBlobTracker += blobs;
                moneyCounter += (blobs * blobprice);
                break;
            case 4:
                yellowBlobTracker += blobs;
                moneyCounter += (blobs * blobprice);
                break;
            case 5:
                moneyCounter += (blobs * blobprice);
                break;
        }
    }

    public void ResetBlobCount(int colourNumber)
    {
        switch (colourNumber)
        {
            case 1:
                greenBlobTracker = 0;
                greenBlobMaxCount += 50;
                break;
            case 2:
                blueBlobTracker = 0;
                blueBlobMaxCount += 50;
                break;
            case 3:
                redBlobTracker = 0;
                redBlobMaxCount += 50;
                break;
            case 4:
                yellowBlobTracker = 0;
                yellowBlobMaxCount += 50;
                break;
        }
    }

    public void BuyGreen(int slimeCost)
    {
          if (moneyCounter >= slimeCost)
        {
            moneyCounter -= slimeCost;
            greenCounter += 1;
        }
    }

    public void BuyBlue(int slimeCost)
    {
         if (moneyCounter >= slimeCost)
        {
            moneyCounter -= slimeCost;
            blueCounter += 1;
        }
    }

    public void BuyRed(int slimeCost)
    {
         if (moneyCounter >= slimeCost)
        {
            moneyCounter -= slimeCost;
            redCounter += 1;
        }
    }

    public void BuyYellow(int slimeCost)
    {
         if (moneyCounter >= slimeCost)
        {
            moneyCounter -= slimeCost;
            yellowCounter += 1;
        }
    }

    public void BuyGreenLimit(int SlimeLimitCost)
    {
        if (moneyCounter >= SlimeLimitCost)
        {
            moneyCounter -= SlimeLimitCost;
        }
    }

    public void BuyBlueLimit(int SlimeLimitCost)
    {
        if (moneyCounter >= SlimeLimitCost)
        {
            moneyCounter -= SlimeLimitCost;
        }
    }

    public void BuyRedLimit(int SlimeLimitCost)
    {
        if (moneyCounter >= SlimeLimitCost)
        {
            moneyCounter -= SlimeLimitCost;
        }
    }

    public void BuyYellowLimit(int SlimeLimitCost)
    {
        if (moneyCounter >= SlimeLimitCost)
        {
            moneyCounter -= SlimeLimitCost;
        }
    }

    //Make in to switch case(this is cause I'm, lazy
    public void IncreaseBoughtAmountGreen()
    {
        boughtGreenPen += 1;
    }
    public void IncreaseBoughtAmountBlue()
    {
        boughtBluePen += 1;
    }
    public void IncreaseBoughtAmountRed()
    {
        boughtRedPen += 1;
    }
    public void IncreaseBoughtAmountYellow()
    {
        boughtYellowPen += 1;
    }

}
