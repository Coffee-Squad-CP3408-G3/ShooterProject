using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInit : MonoBehaviour
{
    public GameObject[] weapon;
    public GameObject weaponPosition;
    void Start()
    {
        Instantiate(weapon[0], weaponPosition.transform.position, Quaternion.identity, weaponPosition.transform);
    }
}
