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
    public Image redScreen;

    public void Start() {
        player = GameObject.FindWithTag("Player");
        playerMaxHealth = 100 * player.GetComponent<PlayerStats>().playerData.PlayerHealthModifier;
    }

    public void Update() {
        heldWeapon = GameObject.FindWithTag("HeldWeapon");  
        playerHealth = player.GetComponent<PlayerStats>().PlayerHealth;
        ammoCount = heldWeapon.GetComponent<Gun>().gunData.currentAmmo;
        
        healthBar.fillAmount = playerHealth/playerMaxHealth;
        ammoText.text = "Ammo: " + ammoCount;
        
        float redScreenAmount = (0.003f * (255 - (((playerHealth/playerMaxHealth) * 255))));
        Debug.Log(redScreenAmount);
        redScreen.color = new Color(redScreen.color.r, redScreen.color.g, redScreen.color.b, redScreenAmount);

    }
}