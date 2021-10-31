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

    public static bool wallsDown;

    bool oneTime;

    int posX;
    int posY;

    void Start()
    {
        posX = Random.Range(-10, 10);
        posY = Random.Range(-10, 10);
        Debug.Log(posX + posY);
    }


    void Update()
    {
        GameObject[] bottomObjects = GameObject.FindGameObjectsWithTag("Bottom");

        for (int i = 3; i < bottomObjects.Length; i++)
        {
            GameObject temp = bottomObjects[i];
            Destroy(temp);
        }

        if (wallsDown == true)
        {
            firstDoorAnimation.SetBool("DoorOpen", true);
            secondDoorAnimation.SetBool("DoorOpen", true);
            firstDoor.isTrigger = true;
            secondDoor.isTrigger = true;
            wallsDown = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(Enemy, new Vector2(transform.position.x + posX, transform.position.y + posY), Quaternion.identity);

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
