using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;
using TMPro;

public class PetScript : MonoBehaviour
{
    public GameObject Player;
    public Animator Textbubble;
    public TextMeshPro text;

    public string[] BubbleTexts;

    bool hideTextbubble;
    bool oneTime = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        StartCoroutine(textbubble());
    }

    IEnumerator textbubble()
    {
        if ((gameObject.transform.position - Player.transform.position).sqrMagnitude > 20 && hideTextbubble == false && oneTime == false)
        {
            int randomText = Random.Range(0, BubbleTexts.Length);
            Debug.Log(BubbleTexts[randomText]);
            text.text = BubbleTexts[randomText];
            Textbubble.SetBool("Textbubble", true);
            oneTime = true;
            yield return new WaitForSecondsRealtime(2f);
            hideTextbubble = true;
        }
        else if((gameObject.transform.position - Player.transform.position).sqrMagnitude < 20 && hideTextbubble)
        {
            Textbubble.SetBool("Textbubble", false);
            hideTextbubble = false;
            oneTime = false;
        }
    }
}
