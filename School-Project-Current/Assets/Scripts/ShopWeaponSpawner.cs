using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeaponSpawner : MonoBehaviour
{
    public Transform firstShopWeapon;
    public Transform secondShopWeapon;
    public Transform thirdShopWeapon;

    public GameObject canvas;

    public GameObject[] Weapons;

    void Start()
    {
        GameObject newCanvas = Instantiate(canvas, transform.position, Quaternion.identity);

        int randomWeaponSpawner =  Random.Range(0, Weapons.Length);
        Instantiate(Weapons[randomWeaponSpawner], firstShopWeapon.position, Quaternion.identity, newCanvas.transform);
        randomWeaponSpawner = Random.Range(0, Weapons.Length);
        Instantiate(Weapons[randomWeaponSpawner], secondShopWeapon.position, Quaternion.identity, newCanvas.transform);
        randomWeaponSpawner = Random.Range(0, Weapons.Length);
        Instantiate(Weapons[randomWeaponSpawner], thirdShopWeapon.position, Quaternion.identity, newCanvas.transform);
    }
}
