using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour
{
    GameObject[] spawners;
    GameObject spawner;
    string timer;
    string minutes;
    string seconds;

    public Text score_Text;
    
    public void Start()
    {

        minutes = (SpawnerAI.secondsPassed / 60).ToString();
        seconds = (SpawnerAI.secondsPassed % 60).ToString();
        timer = ($" {minutes} minutes and {seconds} seconds");
        score_Text.text = "You survived for a total of " + timer;
    }

}
