using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    NavMeshAgent enemy;
    GameObject player;
    PlayerStats playerStats;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    private void Update()
    {   
        enemy.SetDestination(player.transform.position);
        
        if(Vector3.Distance(transform.position, player.transform.position) < EnemyStopRange) {
            enemy.SetDestination(transform.position);
        }

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            playerStats.PlayerTakeDamage(enemyData.EnemyDamage);
        }
    }

    public float health = 1f;

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}