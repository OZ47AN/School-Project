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

    public static bool wallsDown;

    bool oneTime;
    bool enemyIsSpawned;

    int posX;
    int posY;


    void Start()
    {
        posX = Random.Range(-7, 7);
        posY = Random.Range(-7, 7);
        Debug.Log(posX + posY);
    }


    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("GhostEnemy").Length == 0 && enemyIsSpawned == true)
        {
            firstDoorAnimation.SetBool("DoorOpen", true);
            secondDoorAnimation.SetBool("DoorOpen", true);
            firstDoor.isTrigger = true;
            secondDoor.isTrigger = true;
            enemyIsSpawned = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject spawnedEnemy = Instantiate(Enemy, new Vector2(transform.position.x + posX, transform.position.y + posY), Quaternion.identity);
            enemyIsSpawned = true;
            firstDoor.isTrigger = false;
            secondDoor.isTrigger = false;
            firstDoorAnimation.SetBool("DoorOpen", false);
            secondDoorAnimation.SetBool("DoorOpen", false);

            Debug.Log("works");
            oneTime = true;
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
