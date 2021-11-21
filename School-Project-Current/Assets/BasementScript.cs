using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasementScript : MonoBehaviour
{
    public GameObject requestBubble;
    bool canUseStairs;
    bool oneTime;

    private void Start()
    {
        oneTime = true;
    }

    void Update()
    {
        if (canUseStairs == true && KeyScript.pickedUpKey == true && Input.GetKeyDown(KeyCode.F) && oneTime)
        {
            PlayerWeapon.nextStage += 1;
            PlayerWeapon.loadScene = true;
            Invoke("LoadScene", 1f);
            oneTime = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            requestBubble.SetActive(true);
            canUseStairs = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            requestBubble.SetActive(false);
            canUseStairs = false;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
