using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour
{
    static float timer;
    static int secondsPassed = 0;
    static float valueModifier = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60) {secondsPassed++;}
        

    }
}
