using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shopmenu : MonoBehaviour
{
    public static Shopmenu Instance { get; private set; }

    //public event EventHandler OnShopUsed;


    [SerializeField] private Scr_SO_ResourceType minorSoul;
    [SerializeField] private Scr_SO_ResourceType majorSoul;

    [SerializeField] private GameObject resourceObj;
    #region upgrade values
    [Header("Upgrade Values", order = 0)]
    [SerializeField] private int shopDamage;
    [SerializeField] private float shopAttackspeed;
    [SerializeField] private int shopBaseHealth;
    [SerializeField] private int shopSoulGain;
    [SerializeField] private int shopCostReduction;

    [SerializeField] private int pShopDamage;
    [SerializeField] private float pShopAttackspeed;
    [SerializeField] private int pShopBaseHealth;
    [SerializeField] private int pShopSoulGain;
    [SerializeField] private int pShopCostReduction;
    [SerializeField] private int pShopUpgradeBase;
    #endregion

    #region upgrade Base
    private bool upgradeBase1 = false;
    private bool upgradeBase2 = false;
    #endregion

    #region Cost

    private int soulAmount;
    [Header("Cost", order = 1)]

    [SerializeField] private int shopDamageCost;
    [SerializeField] private int shopAttackspeedCost;
    [SerializeField] private int shopBaseHealthCost;
    [SerializeField] private int shopSoulGainCost;
    [SerializeField] private int shopCostReductionCost;

    [SerializeField] private int pShopDamageCost;
    [SerializeField] private int pShopAttackspeedCost;
    [SerializeField] private int pShopBaseHealthCost;
    [SerializeField] private int pShopSoulGainCost;
    [SerializeField] private int pShopCostReductionCost;
    [SerializeField] private int pShopUpgradeBaseCost;
    #endregion

    #region TextRefrence
    //Normal upgrades
    [Header("Text Refrence", order = 3)]
    public Text damageText;
    public Text attackSpeedText;
    public Text baseHealthText;
    public Text soulGainText;
    public Text costReductionText;

    //Perma Upgrades
    public Text pDamageText;
    public Text pAttackSpeedText;
    public Text pBaseHealthText;
    public Text pSoulGainText;
    public Text pCostReductionText;
    public Text pUpgradeBaseText;
    #endregion

    private void awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);

        }
        else if (Instance != null)
        {
            Destroy(this);
        }
    }


    #region Normal upgrade functions
    public void UpgradeDamage()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(minorSoul);
        Debug.Log(soulAmount);
        Debug.Log(shopDamageCost);
        if (soulAmount >= shopDamageCost)
        {
            if (shopDamage < 3)
            {
                Scr_Manager_Resources.Instance.SpendResource(minorSoul, shopDamageCost);
                shopDamage += 1;
                if (shopDamage == 3)
                {
                    damageText.text = "Max";
                }
            }
            else
            {
                Debug.Log("max Damage-upgrade");
            }
        }
    }

    public void UpgradeAttackSpeed()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(minorSoul);

        if (soulAmount >= shopAttackspeedCost)
        {
            Scr_Manager_Resources.Instance.SpendResource(minorSoul, shopAttackspeedCost);

            if (shopAttackspeed > -0.45f)
            {
                shopAttackspeed -= 0.15f;
                if (shopAttackspeed == -0.45f)
                {
                    attackSpeedText.text = "Max";
                }
            }
            else
            {
                Debug.Log("max AttackSpeed-upgrade");
            }
        }
    }

    public void UpgradeMeatWall()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(minorSoul);

        if (soulAmount >= shopBaseHealthCost)
        {
            if (shopBaseHealth < 15)
            {
                Scr_Manager_Resources.Instance.SpendResource(minorSoul, shopBaseHealthCost);
                shopBaseHealth += 5;
                if (shopBaseHealth == 15)
                {
                    baseHealthText.text = "Max";
                }
            }
        }
    }

    public void UpgradeSoulGain()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(minorSoul);

        if (soulAmount >= shopSoulGainCost)
        {
            if (shopSoulGain < 3)
            {
                Scr_Manager_Resources.Instance.SpendResource(minorSoul, shopSoulGainCost);
                shopSoulGain += 1;
                if (shopSoulGain == 3)
                {
                    soulGainText.text = "Max";
                }
            }
        }
    }

    public void UpgradeCostReduction()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(minorSoul);

        if (soulAmount >= shopCostReductionCost)
        {
            if (shopCostReduction > -3)
            {
                Scr_Manager_Resources.Instance.SpendResource(minorSoul, shopCostReductionCost);
                shopCostReduction -= 1;
                if (shopCostReduction == -3)
                {
                    costReductionText.text = "Max";
                }
            }
        }
    }
    #endregion

    #region Permanent upgrade functions
    public void PUpgradeDamage()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(majorSoul);

        if (soulAmount >= pShopDamageCost)
        {
            if (pShopDamage < 3)
            {
                Scr_Manager_Resources.Instance.SpendResource(majorSoul, pShopDamageCost);
                pShopDamage += 1;
                if (pShopDamage == 3)
                {
                    pDamageText.text = "Max";
                }
            }
            else
            {
                Debug.Log("max Damage-upgrade");
            }
        }
    }

    public void PUpgradeAttackSpeed()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(majorSoul);

        if (soulAmount >= pShopAttackspeedCost)
        {
            if (pShopAttackspeed > -3)
            {
                Scr_Manager_Resources.Instance.SpendResource(majorSoul, pShopAttackspeedCost);
                pShopAttackspeed -= 1;
                if (pShopAttackspeed == -3)
                {
                    pAttackSpeedText.text = "Max";
                }
            }
            else
            {
                Debug.Log("max AttackSpeed-upgrade");
            }
        }
    }

    public void PUpgradeMeatWall()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(majorSoul);

        if (soulAmount >= pShopBaseHealthCost)
        {
            Scr_Manager_Resources.Instance.SpendResource(majorSoul, pShopBaseHealthCost);
            if (pShopBaseHealth < 15)
            {
                pShopBaseHealth += 5;
                if (pShopBaseHealth == 15)
                {
                    pBaseHealthText.text = "Max";
                }
            }
        }
    }

    public void PUpgradeSoulGain()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(majorSoul);

        if (soulAmount >= pShopSoulGainCost)
        {
            if (pShopSoulGain <= 3)
            {
                Scr_Manager_Resources.Instance.SpendResource(majorSoul, pShopSoulGainCost);
                pShopSoulGain += 1;
                if (pShopSoulGain == 3)
                {
                    pSoulGainText.text = "Max";
                }
            }
        }
    }

    public void PUpgradeCostReduction()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(majorSoul);

        if (soulAmount >= pShopCostReductionCost)
        {
            if (pShopCostReduction > -3)
            {
                Scr_Manager_Resources.Instance.SpendResource(majorSoul, pShopCostReductionCost);
                pShopCostReduction -= 1;
                if (pShopCostReduction == -3)
                {
                    pCostReductionText.text = "Max";
                }
            }
        }
    }

    public void PUpgradeBase()
    {
        soulAmount = Scr_Manager_Resources.Instance.GetResourceAmount(majorSoul);

        if (soulAmount >= pShopUpgradeBaseCost)
        {
            if (pShopUpgradeBase < 2)
            {
                Scr_Manager_Resources.Instance.SpendResource(majorSoul, pShopUpgradeBaseCost);
                pShopUpgradeBase += 1;

                //UpgradeBasefunction();
                if (pShopUpgradeBase == 1)
                {
                    SceneManager.LoadScene("Scn_Level02");
                }

                if (pShopUpgradeBase == 2)
                {
                    SceneManager.LoadScene("Castle");
                    pUpgradeBaseText.text = "Max";
                }
            }
        }
    }

    #endregion

    public void UpgradeBasefunction()
    {
        if (upgradeBase1 = false)
        {
            Debug.Log("scene level 2");
            upgradeBase1 = true;
            SceneManager.LoadScene("Scn_Level02");
            Debug.Log("scene level 2");
        }

        if (upgradeBase1 = true)
        {
            if (upgradeBase2 = false)
            {
                upgradeBase2 = true;
                Debug.Log("scene level 3");
                SceneManager.LoadScene("Castle");
                Debug.Log("scene level 3");
            }
        }

    }



}
