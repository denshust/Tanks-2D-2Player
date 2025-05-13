using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank", menuName = "Custom/MyTunkData")]
public class TankData : ScriptableObject
{
    public float moveSpeed = 5;
    public float bulletDamage = 10;
    public float bulletSpeed = 20;
    public float health = 100;
    public Sprite gunConektor, gun, hull, track, tower;
   
}
