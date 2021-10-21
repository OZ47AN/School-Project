using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChestScript : MonoBehaviour
{
    public GameObject Chest;

    bool oneTime = true;

    GameObject[] chestSpawnRooms;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject[] chestRooms = GameObject.FindGameObjectsWithTag("ChestSpawner");

        if (StageManager.canLoadNewScene == true && oneTime == true)
        {

            for (int i = 3; i < chestRooms.Length; i++)
            {
                GameObject temp = chestRooms[i];
                Destroy(temp);
            }

            Instantiate(Chest, transform.position, Quaternion.identity);
            oneTime = false;
        }
    }
}
