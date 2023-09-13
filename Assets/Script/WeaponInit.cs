using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInit : MonoBehaviour
{
    public GameObject[] weapon;
    public GameObject weaponPosition;
    GameObject FirstGun;
    GameObject SecondGun;
    int ActiveWeapon;
    void Start()
    {
        FirstGun = Instantiate(weapon[1], weaponPosition.transform.position, Quaternion.identity, weaponPosition.transform);
        SecondGun = Instantiate(weapon[0], weaponPosition.transform.position, Quaternion.identity, weaponPosition.transform);
        SecondGun.SetActive(false);
        FirstGun.tag = "HeldWeapon";
        ActiveWeapon = 2;
    }
    
    void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            if(ActiveWeapon == 2) {
                FirstGun.SetActive(false);
                SecondGun.SetActive(true);
                FirstGun.GetComponent<Gun>().gunData.reloading = false;
                SecondGun.tag = "HeldWeapon";
                FirstGun.tag = "Untagged";
                ActiveWeapon = 1;
            }

            else {
                SecondGun.SetActive(false);
                FirstGun.SetActive(true);
                SecondGun.GetComponent<Gun>().gunData.reloading = false;
                FirstGun.tag = "HeldWeapon";
                SecondGun.tag = "Untagged";
                ActiveWeapon = 2;
            }
        }
    }
}