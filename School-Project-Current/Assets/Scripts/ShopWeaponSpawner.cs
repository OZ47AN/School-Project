using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeaponSpawner : MonoBehaviour
{
    public Transform firstShopWeapon;
    public Transform secondShopWeapon;
    public Transform thirdShopWeapon;

    public GameObject[] Weapons;

    void Start()
    {
        int randomWeaponSpawner =  Random.Range(0, Weapons.Length);
        Instantiate(Weapons[randomWeaponSpawner], firstShopWeapon.position, Quaternion.identity);
        randomWeaponSpawner = Random.Range(0, Weapons.Length);
        Instantiate(Weapons[randomWeaponSpawner], secondShopWeapon.position, Quaternion.identity);
        randomWeaponSpawner = Random.Range(0, Weapons.Length);
        Instantiate(Weapons[randomWeaponSpawner], thirdShopWeapon.position, Quaternion.identity);
    }
}
