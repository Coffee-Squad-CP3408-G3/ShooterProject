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

    public void StartHealth(float PlayerHealth)
    {
        maxHealth = PlayerHealth;
    }
    public void UpdateHealth(float PlayerHealth)
    {
        healthBar.fillAmount = PlayerHealth / maxHealth;
    }
}
