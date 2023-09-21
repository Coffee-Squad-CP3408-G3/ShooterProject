using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("ClassSelect", LoadSceneMode.Single);
    }
}
