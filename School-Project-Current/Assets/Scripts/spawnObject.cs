using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Basement;

    public Transform parent;

    bool spawn = true;

    void Update()
    {
        if (gameObject.tag == "Boss" && spawn == true)
        {
            Instantiate(Boss, transform.position, Quaternion.identity);
            GameObject alreadyUsedRoom = parent.GetChild(0).gameObject;
            Destroy(alreadyUsedRoom);
            spawn = false;
        }
        if (gameObject.tag == "Basement" && spawn == true)
        {
            if (transform.parent.name == ("L") || transform.parent.name == ("L(Clone)"))
            {
                Quaternion spawnRotation = Quaternion.Euler(0, 0, 270);
                Instantiate(Basement, transform.position, spawnRotation);
                GameObject alreadyUsedRoom = parent.GetChild(0).gameObject;
                Destroy(alreadyUsedRoom);
            }
            if (transform.parent.name == ("B") || transform.parent.name == ("B(Clone)"))
            {
                Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
                Instantiate(Basement, transform.position, spawnRotation);
                GameObject alreadyUsedRoom = parent.GetChild(0).gameObject;
                Destroy(alreadyUsedRoom);
            }
            if (transform.parent.name == ("R") || transform.parent.name == ("R(Clone)"))
            {
                Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
                Instantiate(Basement, transform.position, spawnRotation);
                GameObject alreadyUsedRoom = parent.GetChild(0).gameObject;
                Destroy(alreadyUsedRoom);
            }
            if (transform.parent.name == ("T") || transform.parent.name == ("T(Clone)"))
            {
                Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);
                Instantiate(Basement, transform.position, spawnRotation);
                GameObject alreadyUsedRoom = parent.GetChild(0).gameObject;
                Destroy(alreadyUsedRoom);
            }
            spawn = false;
        }
    }
}
