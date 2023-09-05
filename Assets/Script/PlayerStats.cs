using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Further stats to add: Movement speed, Damage Resist, Damage Multiplier, etc.
    public float PlayerHealth = 1f;

    public void PlayerTakeDamage(float EnemyDamage) {
        PlayerHealth -= EnemyDamage;
        if (PlayerHealth <= 0) {
            Destroy(gameObject);
            Debug.Log("You died");
        }
    }
}
