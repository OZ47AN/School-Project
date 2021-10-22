using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    float HoverTime;
    bool isHovering = false;
    public string content;   
    [Multiline()]
    public string header;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    } 
    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
        HoverTime = 0;
        isHovering = false;
    }
   
    void Update()
    {
        if (isHovering)
        {
            HoverTime += Time.deltaTime;
        }

        if (HoverTime > 0.5)
        {
            TooltipSystem.Show(content, header);  
        }

    }
    
   
}
