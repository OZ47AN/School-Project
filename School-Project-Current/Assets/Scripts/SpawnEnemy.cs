using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;

    [SerializeField] Collider2D firstDoor;
    [SerializeField] Collider2D secondDoor;

    private bool SpawnEnemyOnce = true;

    [SerializeField] Animator firstDoorAnimation;
    [SerializeField] Animator secondDoorAnimation;
    private GameObject temp;

    private GameObject spawnedEnemy;

    public GameObject enemySpawnTarget;

    GameObject[] enemySpawnSpots;
    public static bool wallsDown;

    bool oneTime;
    bool enemyIsSpawned;

    int posX;
    int posY;

    int randomAmountOfEnemies;

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("GhostEnemy").Length == 0 && enemyIsSpawned == true)
        {
            firstDoorAnimation.SetBool("DoorOpen", true);
            secondDoorAnimation.SetBool("DoorOpen", true);
            firstDoor.isTrigger = true;
            secondDoor.isTrigger = true;
            enemyIsSpawned = false;

            for (int i = 0; i < randomAmountOfEnemies; i++)
            {
                Destroy(enemySpawnSpots[i]);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            randomAmountOfEnemies = Random.Range(1, 3);
            Debug.Log(randomAmountOfEnemies);

            for (int i = 0; i < randomAmountOfEnemies; i++)
            {
                posX = Random.Range(-7, 7);
                posY = Random.Range(-7, 7);

                Instantiate(enemySpawnTarget, new Vector2(transform.position.x + posX, transform.position.y + posY), Quaternion.identity);

                StartCoroutine(spawnEnemy());
            }

            firstDoor.isTrigger = false;
            secondDoor.isTrigger = false;
            firstDoorAnimation.SetBool("DoorOpen", false);
            secondDoorAnimation.SetBool("DoorOpen", false);
            oneTime = true;
        }
    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSecondsRealtime(1);

        enemySpawnSpots = GameObject.FindGameObjectsWithTag("enemySpawnTarget");

        for (int i = 0; i < randomAmountOfEnemies; i++)
        {
            Vector2 enemySpawn = enemySpawnSpots[i].transform.position;
            Instantiate(Enemy, enemySpawn, Quaternion.identity);
            enemyIsSpawned = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
