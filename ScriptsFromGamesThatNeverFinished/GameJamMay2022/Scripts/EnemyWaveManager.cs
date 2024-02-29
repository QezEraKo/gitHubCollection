using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    Scr_SO_EnemyType_List enemyType_List;

    private Dictionary<Scr_SO_EnemyType, int> spawnTypeAmountDictionary;

    // private int amountToBeSpawned;

    // private float timer;
    // private float timerMax = 1f;

    private void Awake()
    {
        spawnTypeAmountDictionary = new Dictionary<Scr_SO_EnemyType, int>();

        Scr_SO_EnemyType_List enemyType_List = Resources.Load<Scr_SO_EnemyType_List>(typeof(Scr_SO_EnemyType_List).Name);

        int startingValues = 1;

        foreach (Scr_SO_EnemyType enemyType in enemyType_List.list)
        {
            spawnTypeAmountDictionary[enemyType] = startingValues;
        }
    }

    private void Start()
    {
        SetLevelSpawnDictionary();
        HandleSpawning();
    }

    private void SetLevelSpawnDictionary()
    {
        // spawnTypeAmountDictionary = new Dictionary<Scr_SO_EnemyType, int>();
        // foreach (Scr_SO_EnemyType enemyType in enemyType_List.list)
        // {
        //     spawnTypeAmountDictionary[enemyType] = 10;
        // }
    }

    private void HandleSpawning()
    {
        StartCoroutine(Spawn());
    }

    private Dictionary<Scr_SO_EnemyType, int> GetSpawnTypeDictionary()
    {
        return spawnTypeAmountDictionary;
    }

    private static IEnumerator Spawn()
    {
        Scr_SO_EnemyType_List enemyType_List = Resources.Load<Scr_SO_EnemyType_List>(typeof(Scr_SO_EnemyType_List).Name);

        foreach (Scr_SO_EnemyType enemyType in enemyType_List.list)
        {
            Enemy.Create(new Vector3(0, 0, 0), enemyType);
            yield return new WaitForSeconds(1f);
        }
    }


}
