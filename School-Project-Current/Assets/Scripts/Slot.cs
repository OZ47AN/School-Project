using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }

        SwitchWeapon();
    }

    public void SwitchWeapon()
    {
        for (int i = 0; i < 3; i++)
        {
            if (inventory.slots[i].transform.childCount > 0)
            {
                if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.GetChild(0).name == "WeaponInv(Clone)")
                {
                    PlayerWeapon.Weapon = 1;
                }
                else if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.GetChild(0).name == "StaffInv(Clone)")
                {
                    PlayerWeapon.Weapon = 2;
                }
                else if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.GetChild(0).name == "RifleInv(Clone)")
                {
                    PlayerWeapon.Weapon = 3;
                }
                else if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.GetChild(0).name == "BowInv(Clone)")
                {
                    PlayerWeapon.Weapon = 4;
                }
                else if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.GetChild(0).name == "BoomerangInv(Clone)")
                {
                    PlayerWeapon.Weapon = 5;
                }
            }
            else if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.childCount == 0)
            {
                PlayerWeapon.Weapon = 0;
            }
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public void UseItem()
    {

    }
}
