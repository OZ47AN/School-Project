using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowSlider : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        Debug.Log(slider.value);

        if (Input.GetKey(KeyCode.G) && slider.value < 5)
        {
            slider.value += Time.deltaTime * 7;
        }
     

        if (!Input.GetKey(KeyCode.G))
        {
            if (slider.value == 5)
            {
                PlayerMovement.canShootBow = true;
                slider.value = 0;
            }
            else
            {
                slider.value = 0;

            }
        }
    }
}
