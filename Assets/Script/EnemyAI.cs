using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {   
        enemy.SetDestination(player.transform.position);
        
    if(Vector3.Distance(transform.position, player.transform.position) < 3f) {
        enemy.SetDestination(transform.position);
    }
    }
}