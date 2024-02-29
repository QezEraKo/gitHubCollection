using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class Scr_SO_BuildingType : ScriptableObject
{
    public string nameString;
    public Transform prefab;
    public Sprite sprite;
    public Scr_SO_AttackProjectile projectile;
}
