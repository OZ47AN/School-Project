using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Ammunition : MonoBehaviour
{
    public TextMeshProUGUI rifleAmmunationText;
    public TextMeshProUGUI bombAmountText;

    void Start()
    {
        
    }

    void Update()
    {
        rifleAmmunationText.text = "Ammunation: " + PlayerMovement.rifleAmmunation.ToString();
        bombAmountText.text = "Bombs left: " + PlayerMovement.bombsAmount.ToString();
    }
}
