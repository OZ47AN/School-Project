using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;

    public TextMeshProUGUI ContentField;

    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        ContentField.text = content;
        int headerLength = headerField.text.Length;
        int contenLength = headerField.text.Length;
        layoutElement.enabled = (headerLength > characterWrapLimit || contenLength > characterWrapLimit) ? true : false;
    }
    private void Update()
    {
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contenLength = headerField.text.Length;
            layoutElement.enabled = (headerLength > characterWrapLimit || contenLength > characterWrapLimit) ? true : false;
        }
        Vector2 position = Input.mousePosition;
        transform.position = position;
        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;
        rectTransform.pivot = new Vector2(0, 0);

    }

}