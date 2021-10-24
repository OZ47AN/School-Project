using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnChestScript : MonoBehaviour
{
    public GameObject Chest;
    public GameObject Shop;

    bool oneTime = true;

    int randonAmountOfChests;

    GameObject[] chestSpawnRooms;

    void Start()
    {
        
    }

    void Update()
    {
        if (StageManager.canLoadNewScene == true && oneTime == true)
        {
            GameObject[] chestRooms = GameObject.FindGameObjectsWithTag("ChestSpawner");

            if (chestRooms.Length < 5)
            {
                randonAmountOfChests = Random.Range(1, 2);
            }
            else
            {
                randonAmountOfChests = Random.Range(2, 3);
            }
            Debug.Log("random:" + randonAmountOfChests);

            for (int i = 0; i < randonAmountOfChests; i++)
            {
                Vector2 roomPosChest = chestRooms[i].transform.position;
                Instantiate(Chest, roomPosChest, Quaternion.identity);

            }

            if (chestRooms.Length + 1 <= randonAmountOfChests)
            {
                Vector2 roomPosShop = chestRooms[randonAmountOfChests + 1].transform.position;
                Instantiate(Shop, roomPosShop, Quaternion.identity);
            }
            
            oneTime = false;
        }
    }
}