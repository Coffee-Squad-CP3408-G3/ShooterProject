using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] public EnemyData enemyData;
    protected NavMeshAgent enemyNav;
    protected GameObject player;
    protected GameObject playerCam;
    protected PlayerStats playerStats;
    protected float health;
    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        health = enemyData.EnemyHealth;
        enemyNav.speed = enemyData.EnemySpeed; 
    }

    private void Update()
    {   
        enemyNav.SetDestination(player.transform.position);
        
        if(Vector3.Distance(transform.position, player.transform.position) < enemyData.EnemyStopRange) {
            enemyNav.SetDestination(transform.position);
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            playerStats.PlayerTakeDamage(enemyData.EnemyDamage);
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);

        }
    }
}