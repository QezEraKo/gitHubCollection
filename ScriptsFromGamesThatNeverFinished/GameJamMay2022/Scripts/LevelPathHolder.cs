using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPathHolder : MonoBehaviour
{
    [SerializeField] public List<Scr_Coords_Waypoint> enemyPath = new List<Scr_Coords_Waypoint>();

    public static LevelPathHolder Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

}
