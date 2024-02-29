using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Menu_Loader : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadSceneAsync("Scn_PauseMenu", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Scn_UpgradeMenu", LoadSceneMode.Additive);
    }
}
