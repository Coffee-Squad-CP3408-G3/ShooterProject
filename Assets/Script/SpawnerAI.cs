using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour
{
    static float timer;
    static int secondsPassed = 0;
    static float valueModifier = 0;
    static GameObject[] spawners;
    static GameObject controller;

    void Start() {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        controller = GameObject.FindGameObjectWithTag("SpawnController");
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 6) {
            secondsPassed++;
            timer = 0;;
            Instantiate(controller.GetComponent<Enemies>().enemies[0], spawners[0].transform.position, Quaternion.identity);

        }
    }
}
