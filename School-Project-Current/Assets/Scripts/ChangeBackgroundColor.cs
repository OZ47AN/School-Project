using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundColor : MonoBehaviour
{
    public Color greenWall;
    public Color blueWall;

    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    void Update()
    {
        if (PlayerWeapon.nextStage == 1)
        {
            cam.backgroundColor = greenWall;
        }
        else if (PlayerWeapon.nextStage == 2)
        {
            cam.backgroundColor = blueWall;
        }
    }
}
