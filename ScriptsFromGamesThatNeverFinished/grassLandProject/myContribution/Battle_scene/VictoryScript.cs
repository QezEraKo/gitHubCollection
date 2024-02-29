using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScript: MonoBehaviour
{
    //public Text VictoryTextReff;
    public GameObject thisVicText;
    public GameObject thisSpoilText;

    public GameObject thisH1XpDropObj;
    public GameObject thisH2XpDropObj;
    public Text thisH1XpDropText;
    public Text thisH2XpDropText;

    //Sett self active if victory
    private void Start()
    {
        
        thisVicText.SetActive(false);
        thisSpoilText.SetActive(false);
        thisH1XpDropObj.SetActive(false);
        thisH2XpDropObj.SetActive(false);
        
    }


    public void VictoryText()
    {
        thisVicText.SetActive(true);
        thisSpoilText.SetActive(true);
        thisH1XpDropObj.SetActive(true);
        thisH2XpDropObj.SetActive(true);
    }
    public void VictoryScreenh1XpDrop(int h1XpGain)
    {
        thisH1XpDropText.text = (("hero1 xp: ") + h1XpGain.ToString());
    }

    public void VictoryScreenh2XpDrop(int h2XpGain)
    {
         thisH2XpDropText.text = (("hero1 xp: ") + h2XpGain.ToString());
    }

}
