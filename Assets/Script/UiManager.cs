using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    public Image healthBar;
    GameObject player;
    GameObject heldWeapon;
    int ammoCount;
    float playerHealth;
    float playerMaxHealth;

    public void Start() {
        player = GameObject.FindWithTag("Player");
        playerMaxHealth = 100 * player.GetComponent<PlayerStats>().playerData.PlayerHealthModifier;
    }

    public void Update() {
        heldWeapon = GameObject.FindWithTag("HeldWeapon");
        playerHealth = player.GetComponent<PlayerStats>().PlayerHealth;
        ammoCount = heldWeapon.GetComponent<Gun>().gunData.currentAmmo;
        
        healthBar.fillAmount = playerHealth/playerMaxHealth;
        Debug.Log(playerHealth/playerMaxHealth);
        
    }
    public void UpdateAmmo()
    {
        ammoText.text = "Ammo: " + ammoCount;
    }
}