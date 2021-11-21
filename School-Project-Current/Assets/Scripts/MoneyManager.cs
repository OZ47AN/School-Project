using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyAmountText;
    public GameObject keyItemFrame;


    void Update()
    {
        moneyAmountText.text = "Money Amount: " + BuyWeapon.moneyAmount.ToString();

        if (KeyScript.pickedUpKey == true)
        {
            keyItemFrame.SetActive(true);
        }
        else
        {
            keyItemFrame.SetActive(false);
        }
    }
}
