using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Soldier", menuName="Player/Soldier")]
public class PlayerData : ScriptableObject {
    [Header("Affects Player Character")]
    public float PlayerHealthModifier;
    public float PlayerSpeedModifier;
    public float PlayerDamageResist;
    public bool PlayerInvincible = false;

    [Header("Affects Gun")]
    public float PlayerDamageModifier;
    public int AmmoModifier;
    public float FireRateModifier;

}