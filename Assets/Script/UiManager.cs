using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private float maxHealth;
    private Image healthBar;

    //public void UpdateAmmo(int count)
    //{
      //  ammoText.text = "Ammo: " + count;
    //}

    public void Update() {
        heldWeapon = GameObject.FindWithTag("HeldWeapon");
        playerHealth = player.GetComponent<PlayerStats>().PlayerHealth;
        ammoCount = heldWeapon.GetComponent<Gun>().gunData.currentAmmo;
        
        healthBar.fillAmount = playerHealth/playerMaxHealth;
        Debug.Log(playerHealth/playerMaxHealth);
        
    }
    public void UpdateAmmo()
    {
        maxHealth = PlayerHealth;
    }
    public void UpdateHealth(float PlayerHealth)
    {
        healthBar.fillAmount = PlayerHealth / maxHealth;
    }
}
