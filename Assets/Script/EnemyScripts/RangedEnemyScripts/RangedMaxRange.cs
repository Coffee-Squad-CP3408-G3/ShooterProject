using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMaxRange : MonoBehaviour
{
    public bool playerInRange = false;
    public RangedStartAiming rangedStartAiming;
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }
    public void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            playerInRange = false;
            rangedStartAiming.enemyIsAiming = false;

        }
    }
}
