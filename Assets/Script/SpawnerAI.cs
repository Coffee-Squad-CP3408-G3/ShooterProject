using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour
{
    static float timer;
    public static int secondsPassed = 0;
    static float currentBudget = 0;
    static GameObject[] spawners;
    static GameObject controller;
    static GameObject[] enemyList;
    static int chosenEnemy;

    void Start() {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        controller = GameObject.FindGameObjectWithTag("SpawnController");
        enemyList = controller.GetComponent<Enemies>().enemies;
        currentBudget = 20;

        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this.transform.parent.gameObject);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3) {
            timer = 0;
            secondsPassed++;
            currentBudget += 1 + (secondsPassed * 0.01f);
        
        if(currentBudget > 0) {
            if (Random.Range(0,10) > 8 - (secondsPassed * 0.05f)) {
                chosenEnemy = Random.Range(0, enemyList.Length);
                if(enemyList[chosenEnemy].GetComponent<EnemyAI>().enemyData.EnemyValue <= currentBudget) {
                    Instantiate(enemyList[chosenEnemy], spawners[Random.Range(0,2)].transform.position, Quaternion.identity);
                    currentBudget -= enemyList[chosenEnemy].GetComponent<EnemyAI>().enemyData.EnemyValue;
                    }
                }
            }
        }
    }
}
