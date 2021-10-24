using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour

{
    public GameObject newButton;
    public GameObject canvas;

    int xPosition = -8;
    int yPosition;

    int anzahlButtons = 0;
    int maxButtons = 5;

    public int[] buff = new int[5];


    public void Upgrade1()
    {
        if (anzahlButtons < maxButtons)
        {
            xPosition = xPosition + 3;
            yPosition = Random.Range(-4, 4);

            buff[anzahlButtons] = yPosition;

            GameObject myButton = Instantiate(newButton, new Vector2(xPosition, yPosition), Quaternion.identity, canvas.transform) as GameObject;

            Debug.Log(buff[anzahlButtons]);

            anzahlButtons += 1;
        }
    }
}

//x min: 50 x max: 870;
//y min: 50 y max: 470;
//unten links 50/50
//oben rechts 50/470
//Die Mitte ist 460 und 260