using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyAmountText;

    void Update()
    {
        moneyAmountText.text = "Money Amount: " + BuyWeapon.moneyAmount.ToString();
    }
}
