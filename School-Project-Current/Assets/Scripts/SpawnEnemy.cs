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

    public static bool enteredRoom;

    bool oneTime;

    void Start()
    {

    }


    void Update()
    {
        GameObject[] bottomObjects = GameObject.FindGameObjectsWithTag("Bottom");

        for (int i = 1; i < bottomObjects.Length; i++)
        {
            GameObject temp = bottomObjects[i];
            Destroy(temp);
        }

        if (enteredRoom == true && oneTime == false)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);

            firstDoor.isTrigger = false;
            secondDoor.isTrigger = false;
            firstDoorAnimation.SetBool("DoorOpen", false);
            secondDoorAnimation.SetBool("DoorOpen", false);

            Debug.Log("works");
            oneTime = true;
        }

        if (wallsDown == true)
        {
            firstDoorAnimation.SetBool("DoorOpen", true);
            secondDoorAnimation.SetBool("DoorOpen", true);
            firstDoor.isTrigger = true;
            secondDoor.isTrigger = true;
        }
    }
}
