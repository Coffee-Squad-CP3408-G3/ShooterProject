using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedStartAiming : MonoBehaviour
{
    // public EnemyAimRange enemyAimRange;
    // public EnemyMaxRange enemyMaxRange;
    // float enemyShootCooldown = 0;
    // float enemyAimDuration = 0;
    // bool enemyCanShoot = true;
    public bool enemyIsAiming = false;    

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            enemyIsAiming = true;
        }
    }
    
    // private void OnCollisionEnter(Collision collision) {
    //     if (collision.gameObject.tag == "Player") {
    //         if (playerInRange) {
    //             enemyIsAiming = true;
    //         }
            
    //     }
    // }

    // private void EnemyAiming() {
    //     enemyAimDuration += Time.deltaTime;

    //     if(enemyAimDuration >= 15) {
    //         playerStats.PlayerTakeDamage(enemyData.EnemyDamage);
    //     }
    // }

    private void Update()
    {   
        // enemyNav.SetDestination(player.transform.position);

        // if(!enemyCanShoot) {
        //     enemyShootCooldown += Time.deltaTime;
        //     if(enemyShootCooldown >= 30) {
        //     enemyCanShoot = true;
        //     }
        // }

        // if(enemyIsAiming) {
        //     enemyNav.speed = 0;
        // }

    }

}
