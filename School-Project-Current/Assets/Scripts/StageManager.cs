using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
	public GameObject greenWall;
    public GameObject blueWall;

    private bool onlyOneTime = true;
    public static bool canLoadNewScene;

    private void Start()
    {
        canLoadNewScene = false;
    }

    private void Update()
    {
        if (PlayerWeapon.nextStage == 1 && onlyOneTime == true && canLoadNewScene == true)
        {
            Invoke("greenWallColor", .5f);
            onlyOneTime = false;
        }
        else if (PlayerWeapon.nextStage == 2 && onlyOneTime == true && canLoadNewScene == true)
        {
            Invoke("blueWallColor", .5f);
            onlyOneTime = false;
        }
    }

    public void greenWallColor()
    {
        greenWall.SetActive(true);
    }

    public void blueWallColor()
    {
        greenWall.SetActive(false);
        blueWall.SetActive(true);
    }
}