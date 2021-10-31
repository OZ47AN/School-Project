using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    public Animator LoadSceneAnimtion;
    GameObject[] SpawnerObject;
    string[] spawnerTags = new string[] { "Enemy", "Enemy", "Boss", "Basement"};

    void Start()
    {
        Invoke("Test", 1.0f);
    }

    void Test()
    {
        GameObject[] Spawner = GameObject.FindGameObjectsWithTag("Spawner");

        if (Spawner.Length != 4)
        {
            SceneManager.LoadScene(0);
            StageManager.canLoadNewScene = false;
        }
        else
        {
            StageManager.canLoadNewScene = true;
            LoadSceneAnimtion.SetTrigger("StartGame");
            PathfindingScript.readyToScan = true;
        }

        for (int i = 0; i < Spawner.Length; i++)
        {
            Spawner[i].tag = spawnerTags[i];
        }
    }
}
