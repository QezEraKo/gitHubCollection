using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDownScript : MonoBehaviour
{
    private GameObject me;
  
    private BattleManager_reworked BattleManager;

    private void Start()
    {
        me = this.gameObject;
}
    private void OnMouseOver()
    {
    }

    private void OnMouseExit()
    {

    }
    private void OnMouseDown()
    {
        //BattleManager.GetComponent<BattleManager_reworked>().heroList;
        BattleManager = GameObject.FindObjectOfType(typeof(BattleManager_reworked)) as BattleManager_reworked;
        BattleManager.ClickedEnemy(this.gameObject);

    }
}
