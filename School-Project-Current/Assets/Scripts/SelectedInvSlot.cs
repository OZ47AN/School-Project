using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedInvSlot : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    private Image slot1Color;
    private Image slot2Color;
    private Image slot3Color;

    public static int currentSlot = 10;

    Color red = new Color(244, 65, 65);
    Color orange = new Color(255, 150, 150);

    private void Start()
    {
        slot1Color = slot1.GetComponent<Image>();
        slot2Color = slot2.GetComponent<Image>();
        slot3Color = slot3.GetComponent<Image>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSlot = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSlot = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSlot = 2;
        }


        if (currentSlot == 0)
        {
            slot1Color.color = Color.red;
        }
        else
        {
            slot1Color.color = Color.white;
        }

        if (currentSlot == 1)
        {
            slot2Color.color = Color.red;
        }
        else
        {
            slot2Color.color = Color.white;
        }

        if (currentSlot == 2)
        {
            slot3Color.color = Color.red;
        }
        else
        {
            slot3Color.color = Color.white;
        }
    }
}
