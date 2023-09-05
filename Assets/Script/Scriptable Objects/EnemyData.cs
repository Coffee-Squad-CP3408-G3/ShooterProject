using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Enemy", menuName="Enemies/NewEnemy")]

public class EnemyData : ScriptableObject {
    [Header("Info")]
    public new string name;
    public float EnemyHealth;
    public float EnemyDamage = 1f;
    public float EnemySpeed;
    public float EnemyDamageRate;
    public float EnemyValue;
}