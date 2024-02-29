using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPenScript : MonoBehaviour
{

    [SerializeField] private GameObject penPrefabGreen;
    [SerializeField] private GameObject penPrefabBlue;
    [SerializeField] private GameObject penPrefabRed;
    [SerializeField] private GameObject penPrefabYellow;

    private GameObject thisShop;

    [SerializeField] private Text greenBlobText;
    [SerializeField] private Text blueBlobText;
    [SerializeField] private Text redBlobText;
    [SerializeField] private Text yellowBlobText;

    public int checkBoughtGreenPen = 0;
    public int checkBoughtBluePen = 0;
    public int checkBoughtRedPen = 0;
    public int checkBoughtYellowPen = 0;

    private int greenBlobCountProgression = 0;
    private int blueBlobCountProgression = 0;
    private int redBlobCountProgression = 0;
    private int yellowBlobCountProgression = 0;

    [SerializeField] private int greenPenCount = 1;
    private int bluePenCount = 0;
    private int redPenCount = 0;
    private int yellowPenCount = 0;

    private int greenPenCountLimit = 2;
    private int bluePenCountLimit = 2;
    private int redPenCountLimit = 2;
    private int yellowPenCountLimit = 2;

    private int greenBlobMaxCountProgression = 100;
    private int blueBlobMaxCountProgression = 100;
    private int redBlobMaxCountProgression = 100;
    private int yellowBlobMaxCountProgression = 100;

    [SerializeField] private GameObject slimeManager;
    private SlimeManager slimeManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        slimeManager = GameObject.FindWithTag("SlimeManager");
        thisShop = this.gameObject;
        slimeManagerScript = slimeManager.GetComponent<SlimeManager>();
        StartCoroutine(GetBlobCount());
    }

    IEnumerator GetBlobCount()
    {
        checkBoughtGreenPen = slimeManagerScript.boughtGreenPen;
        checkBoughtBluePen = slimeManagerScript.boughtBluePen;
        checkBoughtRedPen = slimeManagerScript.boughtRedPen;
        checkBoughtYellowPen = slimeManagerScript.boughtYellowPen;

        Debug.Log("bluepen counter" + checkBoughtBluePen);




        yield return new WaitForSeconds(1);


        #region green pen blobcount
        greenBlobCountProgression = slimeManagerScript.greenBlobTracker;
        greenBlobMaxCountProgression = slimeManagerScript.greenBlobMaxCount;

        if (greenBlobCountProgression > greenBlobMaxCountProgression)
        {
            greenBlobCountProgression = greenBlobMaxCountProgression;
        }
        #endregion

        #region blue pen blobcount
        switch (checkBoughtBluePen)
        {
            case 0:
                blueBlobCountProgression = slimeManagerScript.greenBlobTracker;      //1.Get blob progession
                blueBlobMaxCountProgression = slimeManagerScript.greenBlobMaxCount;  //2.Get blob Max Progression
                if (blueBlobCountProgression > blueBlobMaxCountProgression)         //3. if 1 is bigger than 2
                {
                    blueBlobCountProgression = blueBlobMaxCountProgression;         //1 is equal to 2
                }
                break;
            case 1:
                blueBlobCountProgression = slimeManagerScript.blueBlobTracker;      //1.Get blob progession
                blueBlobMaxCountProgression = slimeManagerScript.blueBlobMaxCount;  //2.Get blob Max Progression
                Debug.Log(blueBlobCountProgression + "should be 0 now");
                if (blueBlobCountProgression > blueBlobMaxCountProgression)         //3. if 1 is bigger than 2
                {
                    blueBlobCountProgression = blueBlobMaxCountProgression;         //1 is equal to 2
                }
                break;
            case 2:
                blueBlobCountProgression = slimeManagerScript.blueBlobTracker;      //1.Get blob progession
                blueBlobMaxCountProgression = slimeManagerScript.blueBlobMaxCount;  //2.Get blob Max Progression
                if (blueBlobCountProgression > blueBlobMaxCountProgression)         //3. if 1 is bigger than 2
                {
                    blueBlobCountProgression = blueBlobMaxCountProgression;         //1 is equal to 2
                }
                break;
            case 3:
                blueBlobCountProgression = slimeManagerScript.blueBlobTracker;      //1.Get blob progession
                blueBlobMaxCountProgression = slimeManagerScript.blueBlobMaxCount;  //2.Get blob Max Progression
                if (blueBlobCountProgression > blueBlobMaxCountProgression)         //3. if 1 is bigger than 2
                {
                    blueBlobCountProgression = blueBlobMaxCountProgression;         //1 is equal to 2
                }
                break;
            case 4:
                blueBlobCountProgression = slimeManagerScript.blueBlobTracker;      //1.Get blob progession
                blueBlobMaxCountProgression = slimeManagerScript.blueBlobMaxCount;  //2.Get blob Max Progression
                if (blueBlobCountProgression > blueBlobMaxCountProgression)         //3. if 1 is bigger than 2
                {
                    blueBlobCountProgression = blueBlobMaxCountProgression;         //1 is equal to 2
                }
                break;
        }
        #endregion

        #region red pen blobcount

        switch (checkBoughtRedPen)
        {
            case 0:
                redBlobCountProgression = slimeManagerScript.blueBlobTracker;
                redBlobMaxCountProgression = slimeManagerScript.blueBlobMaxCount;
                if (redBlobCountProgression > redBlobMaxCountProgression)
                {
                    redBlobCountProgression = redBlobMaxCountProgression;
                }
                break;
            case 1:
                redBlobCountProgression = slimeManagerScript.redBlobTracker;
                redBlobMaxCountProgression = slimeManagerScript.redBlobMaxCount;
                if (redBlobCountProgression > redBlobMaxCountProgression)
                {
                    redBlobCountProgression = redBlobMaxCountProgression;
                }
                break;
            case 2:
                redBlobCountProgression = slimeManagerScript.redBlobTracker;
                redBlobMaxCountProgression = slimeManagerScript.redBlobMaxCount;
                if (redBlobCountProgression > redBlobMaxCountProgression)
                {
                    redBlobCountProgression = redBlobMaxCountProgression;
                }
                break;
            case 3:
                redBlobCountProgression = slimeManagerScript.redBlobTracker;
                redBlobMaxCountProgression = slimeManagerScript.redBlobMaxCount;
                if (redBlobCountProgression > redBlobMaxCountProgression)
                {
                    redBlobCountProgression = redBlobMaxCountProgression;
                }
                break;
            case 4:
                redBlobCountProgression = slimeManagerScript.redBlobTracker;
                redBlobMaxCountProgression = slimeManagerScript.redBlobMaxCount;
                if (redBlobCountProgression > redBlobMaxCountProgression)
                {
                    redBlobCountProgression = redBlobMaxCountProgression;
                }
                break;
        }
        #endregion

        #region yellow pen blobcount
        switch (checkBoughtYellowPen)
        {
            case 1:
                yellowBlobCountProgression = slimeManagerScript.redBlobTracker;
                yellowBlobMaxCountProgression = slimeManagerScript.redBlobMaxCount;
                if (yellowBlobCountProgression > yellowBlobMaxCountProgression)
                {
                    yellowBlobCountProgression = yellowBlobMaxCountProgression;
                }
                break;
            case 2:
                yellowBlobCountProgression = slimeManagerScript.yellowBlobTracker;
                yellowBlobMaxCountProgression = slimeManagerScript.yellowBlobMaxCount;
                if (yellowBlobCountProgression > yellowBlobMaxCountProgression)
                {
                    yellowBlobCountProgression = yellowBlobMaxCountProgression;
                }
                break;
            case 3:
                yellowBlobCountProgression = slimeManagerScript.yellowBlobTracker;
                yellowBlobMaxCountProgression = slimeManagerScript.yellowBlobMaxCount;
                if (yellowBlobCountProgression > yellowBlobMaxCountProgression)
                {
                    yellowBlobCountProgression = yellowBlobMaxCountProgression;
                }
                break;
            case 4:
                yellowBlobCountProgression = slimeManagerScript.yellowBlobTracker;
                yellowBlobMaxCountProgression = slimeManagerScript.yellowBlobMaxCount;
                if (yellowBlobCountProgression > yellowBlobMaxCountProgression)
                {
                    yellowBlobCountProgression = yellowBlobMaxCountProgression;
                }
                break;
        }
 
        #endregion

        SetText();
        StartCoroutine(GetBlobCount());

    }

    private void SetText()
    {
        greenBlobText.text = (greenBlobCountProgression.ToString() + " / " + greenBlobMaxCountProgression.ToString());
        redBlobText.text = (redBlobCountProgression.ToString() + " / " + blueBlobMaxCountProgression.ToString());
        blueBlobText.text = (blueBlobCountProgression.ToString() + " / " + redBlobMaxCountProgression.ToString());
        yellowBlobText.text = (yellowBlobCountProgression.ToString() + " / " + yellowBlobMaxCountProgression.ToString());
    }


    public void BuyGreenPen()
    {
        if (checkBoughtGreenPen < greenPenCountLimit)
        {
            if (greenBlobCountProgression >= greenBlobMaxCountProgression)
            {
                //make next comment into switch case!!!!!
                slimeManagerScript.IncreaseBoughtAmountGreen();
                //greenPenCount += 1;
                slimeManagerScript.ResetBlobCount(1);
                Instantiate(penPrefabGreen, new Vector2(thisShop.transform.position.x - 3.6f, thisShop.transform.position.y - 1.84f), Quaternion.identity);
                this.gameObject.SetActive(false);
            }
        }
    }

    public void BuyBluePen()
    {
        if (checkBoughtBluePen < bluePenCountLimit)
        {
            if (blueBlobCountProgression >= blueBlobMaxCountProgression)
            {
                //make next comment into switch case!!!!!
                slimeManagerScript.IncreaseBoughtAmountBlue();
                //bluePenCount += 1;
                if (checkBoughtBluePen >= 1)
                {
                    slimeManagerScript.ResetBlobCount(2);
                }

                Instantiate(penPrefabBlue, new Vector2(thisShop.transform.position.x - 3.6f, thisShop.transform.position.y - 1.84f), Quaternion.identity);
                this.gameObject.SetActive(false);
            }
        }
    }

    public void BuyRedPen()
    {
        if (checkBoughtRedPen < redPenCountLimit)
        {
            if (redBlobCountProgression >= redBlobMaxCountProgression)
            {
                //make next comment into switch case!!!!!
                slimeManagerScript.IncreaseBoughtAmountRed();
                //redPenCount += 1;
                if ( checkBoughtRedPen >= 1)
                {
                    slimeManagerScript.ResetBlobCount(3);
                }
                Instantiate(penPrefabRed, new Vector2(thisShop.transform.position.x - 3.6f, thisShop.transform.position.y - 1.84f), Quaternion.identity);
                this.gameObject.SetActive(false);
            }
        }
    }

    public void BuyYellowPen()
    {
        if (checkBoughtYellowPen < yellowPenCountLimit)
        {
            if (yellowBlobCountProgression >= yellowBlobMaxCountProgression)
            {
                //make next comment into switch case!!!!!
                slimeManagerScript.IncreaseBoughtAmountYellow();
                //yellowPenCount += 1;
                if (checkBoughtYellowPen >= 1)
                {
                    slimeManagerScript.ResetBlobCount(4);
                }
                Instantiate(penPrefabYellow, new Vector2(thisShop.transform.position.x - 3.6f, thisShop.transform.position.y - 1.84f), Quaternion.identity);
                this.gameObject.SetActive(false);
            }
        }
    }
}
