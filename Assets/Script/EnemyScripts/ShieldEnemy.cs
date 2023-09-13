using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : EnemyAI
{
    float chargeCooldown = 0;
    float chargeDuration = 0;
    bool canCharge = true;
    bool isCharging = false;    
    private void Update()
    {   
        enemyNav.SetDestination(player.transform.position);

        if(!canCharge) {
            chargeCooldown += Time.deltaTime;
            if(chargeCooldown >= 15) canCharge = true;
        }

        if(Vector3.Distance(transform.position, player.transform.position) > 5 && Vector3.Distance(transform.position, player.transform.position) < 15 && canCharge) {
            enemyNav.speed = 15;
            enemyNav.acceleration = 12;
            isCharging = true;
            canCharge = false;
            enemyNav.SetDestination(player.transform.position);
            }

        if(isCharging) {
            chargeDuration += Time.deltaTime;
            if(chargeDuration >= 1) {
                enemyNav.speed = enemyData.EnemySpeed;
                enemyNav.acceleration = 8;
                chargeDuration = 0;
                isCharging = false;
            }
        }

    }
}
