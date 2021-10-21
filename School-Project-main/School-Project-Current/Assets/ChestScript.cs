using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private bool HasItDropped = false;

    Rigidbody2D rb;
    Rigidbody2D rb2;
    Rigidbody2D rb3;

    GameObject spawnedWeapon;
    GameObject spawnedWeapon2;
    GameObject spawnedWeapon3;

    public Sprite openedChestSprite;

    SpriteRenderer chestSprite;
    public GameObject[] Weapons;

    int randomWeapon;

    float bulletForce = 1.5f;

    bool oneTime = true;

    bool canOpenChest = false;

    private void Start()
    {
        chestSprite = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        if (HasItDropped && bulletForce >= 0 && oneTime)
        {
            if (spawnedWeapon != null)
            {
                rb = spawnedWeapon.GetComponent<Rigidbody2D>();
                rb.AddForce(-transform.up * bulletForce, ForceMode2D.Impulse);
                rb.AddForce(-transform.right * bulletForce, ForceMode2D.Impulse);
            }

            if (spawnedWeapon2 != null)
            {
                rb2 = spawnedWeapon2.GetComponent<Rigidbody2D>();
                rb2.AddForce(-transform.up * bulletForce, ForceMode2D.Impulse);
            }

            if (spawnedWeapon3 != null)
            {
                rb3 = spawnedWeapon3.GetComponent<Rigidbody2D>();
                rb3.AddForce(-transform.up * bulletForce, ForceMode2D.Impulse);
                rb3.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
            }

            Invoke("sleep", .1f);
            oneTime = false;
        }

        if (canOpenChest && HasItDropped == false && Input.GetKeyDown(KeyCode.R))
        {
            chestSprite.sprite = openedChestSprite;
            DropDownItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canOpenChest = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canOpenChest = false;
        }
    }

    private void DropDownItem()
    {
        randomWeapon = UnityEngine.Random.Range(0, Weapons.Length);
        spawnedWeapon = Instantiate(Weapons[randomWeapon], new Vector2(transform.position.x -2, transform.position.y - 1), Quaternion.identity);
        
        randomWeapon = UnityEngine.Random.Range(0, Weapons.Length);
        spawnedWeapon2 = Instantiate(Weapons[randomWeapon], new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
        
        randomWeapon = UnityEngine.Random.Range(0, Weapons.Length);
        spawnedWeapon3 = Instantiate(Weapons[randomWeapon], new Vector2(transform.position.x + 2, transform.position.y - 1), Quaternion.identity);

        HasItDropped = true;
    }

    private void sleep()
    {
        if (spawnedWeapon != null)
        {
            rb.Sleep();
        }

        if (spawnedWeapon2 != null)
        {
            rb2.Sleep();
        }
        
        if (spawnedWeapon3 != null)
        {
            rb3.Sleep();
        }
    }


}