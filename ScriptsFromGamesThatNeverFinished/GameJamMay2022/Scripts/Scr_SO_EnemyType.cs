using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyType")]
public class Scr_SO_EnemyType : ScriptableObject
{
    public string nameString;
    public Transform prefab;
    public Scr_Resource_GenerationData resourceGenerationData;
    public int damage;
}
