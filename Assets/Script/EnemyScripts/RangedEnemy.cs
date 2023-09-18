using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyAI
{
    // public EnemyAimRange enemyAimRange;
    public RangedStartAiming rangedStartAiming;
    public RangedMaxRange rangedMaxRange;
    float enemyShootCooldown = 0;
    float enemyAimDuration = 0;
    bool enemyCanShoot = true;
    bool enemyIsAiming = false;    
    

    private void Update()
    {   
        if (rangedMaxRange.playerInRange) {
            if (rangedStartAiming.enemyIsAiming) {
                if (enemyCanShoot) {
                    if (enemyAimDuration <= 15) {
                        enemyAimDuration += Time.deltaTime;
                    }
                    if (enemyAimDuration >= 15) {
                        playerStats.PlayerTakeDamage(enemyData.EnemyDamage);
                        enemyCanShoot = false;
                        enemyShootCooldown = 0;
                        Debug.Log("You got shot");
                    }
                        
                }
                if(!enemyCanShoot) {
                    enemyShootCooldown += Time.deltaTime;
                    if (enemyShootCooldown >= 30) {
                        enemyCanShoot = true;
                    }
                }
            }
            
        }
        

    }
}
