using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyWeapon : MonoBehaviour
{
    private Inventory inventory;

    public GameObject itemButtonRifle;
    public GameObject itemButtonPistol;
    public GameObject itemButtonStaff;

    public static int moneyAmount = 20;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void BuyPistol()
    {
        if (moneyAmount >= 10)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButtonPistol, inventory.slots[i].transform, false);
                    moneyAmount -= 10;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    public void BuyMagicStaff()
    {
        if (moneyAmount >= 5)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButtonStaff, inventory.slots[i].transform, false);
                    moneyAmount -= 5;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    public void BuyRifle()
    {
        if (moneyAmount >= 15)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButtonRifle, inventory.slots[i].transform, false);
                    moneyAmount -= 15;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
