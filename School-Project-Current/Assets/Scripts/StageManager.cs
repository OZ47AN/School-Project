using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
	public GameObject greenWall;
    private bool onlyOneTime = true;
    public static bool canLoadNewScene;

    private void Update()
    {
        if (PlayerMovement.nextStage == 1 && onlyOneTime == true && canLoadNewScene == true)
        {
            Invoke("ChangeWallColor", .5f);
            onlyOneTime = false;
        }
    }

    public void ChangeWallColor()
    {
        greenWall.SetActive(true);
    }
}
