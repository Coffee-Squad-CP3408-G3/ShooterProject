using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public AudioSource deadAudio;
    //Further stats to add: Movement speed, Damage Resist, Damage Multiplier, etc.
    public PlayerData playerData;
    public float PlayerHealth = 100f;
    float IFrameTimer = 0;

    public void Start() {
        playerData.PlayerInvincible = false;
    }
    public void Update() {
        if (playerData.PlayerInvincible) {
            IFrameTimer += Time.deltaTime;
            Debug.Log(IFrameTimer);
            if (IFrameTimer >= 1.5f) {
                playerData.PlayerInvincible = false;
                IFrameTimer = 0;
            }
        }
    }

    public void PlayerTakeDamage(float EnemyDamage) {
        if (!playerData.PlayerInvincible) {
            PlayerHealth -= EnemyDamage;
            Debug.Log("Player takes damage");
            playerData.PlayerInvincible = true;
            Debug.Log("IFrames true");

            if (PlayerHealth < 100) {
                Debug.Log("Less than 1000");
            }
            if (PlayerHealth < 50) {
                Debug.Log("Less than 500");
            }

            if (PlayerHealth <= 0) {
                deadAudio.Play();
                Destroy(gameObject);
                Debug.Log("You died");
            }
        }

        
    }
}
