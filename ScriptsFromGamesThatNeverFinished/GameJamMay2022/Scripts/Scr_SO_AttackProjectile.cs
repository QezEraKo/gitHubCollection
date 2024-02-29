using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AttackProjectileType")]
public class Scr_SO_AttackProjectile : ScriptableObject
{
    public string nameString;
    public Transform prefab;
    public Scr_SO_BuildingType buildingType;
    public int damage;
    public int attackSpeed;
    public int timeToReload;
}
