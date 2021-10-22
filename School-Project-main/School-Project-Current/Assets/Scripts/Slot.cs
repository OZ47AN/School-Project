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
                    PlayerMovement.Weapon = 1;
                }
                else if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.GetChild(0).name == "StaffInv(Clone)")
                {
                    PlayerMovement.Weapon = 2;
                }
                else if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.GetChild(0).name == "RifleInv(Clone)")
                {
                    PlayerMovement.Weapon = 3;
                }
                if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.GetChild(0).name == "BowInv(Clone)")
                {
                    PlayerMovement.Weapon = 4;
                }
                
            }
           
            else if (SelectedInvSlot.currentSlot == i && inventory.slots[i].transform.childCount == 0)
            {
                PlayerMovement.Weapon = 0;
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
