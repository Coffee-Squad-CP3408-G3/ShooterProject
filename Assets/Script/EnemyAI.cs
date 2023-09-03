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

    private void LateUpdate()
    {
        enemy.SetDestination(player.transform.position);
    }
}