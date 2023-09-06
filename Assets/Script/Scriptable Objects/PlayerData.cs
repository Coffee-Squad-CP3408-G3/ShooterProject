using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ScriptableObject {
    [Header("Affects Player Character")]
    public float PlayerHealth;
    public float PlayerSpeedModifier;
    public float PlayerDamageResist;

    [Header("Affects Gun")]
    public float PlayerDamageModifier;
    public int AmmoModifier;
    public float FireRateModifier;


}