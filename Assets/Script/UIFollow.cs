using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public float xOffset;
    public float yOffset;
    public RectTransform recTransform;

    void Update()
    {
        Vector2 Monster2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        recTransform.position = Monster2DPosition + new Vector2(xOffset, yOffset);

        if (Monster2DPosition.x > Screen.width || Monster2DPosition.x < 0 || Monster2DPosition.y > Screen.height || Monster2DPosition.y < 0)
        {
            recTransform.gameObject.SetActive(false);
        }
        else
        {
            recTransform.gameObject.SetActive(true);
        }
    }
}
