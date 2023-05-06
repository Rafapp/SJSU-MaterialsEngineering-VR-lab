using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolidShapeController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] handles;

    [SerializeField]
    private GameObject solidShape;

    private RectTransform solidShapeRect;

    private float lastHandleSeparation;

    private void Awake()
    {
        solidShapeRect = solidShape.GetComponent<RectTransform>();
        lastHandleSeparation = GetHandleSeparation(handles);
    }
    private void Update()
    {
        if (GetHandleSeparation(handles) != lastHandleSeparation)
        {
            // image - separationOffset = separation
            float separation = GetHandleSeparation(handles);
            solidShapeRect.sizeDelta = new Vector2(separation,separation);
        }
    }

    private float GetHandleSeparation(GameObject[] theHandles)
    {
        return (theHandles[0].transform.position - theHandles[1].transform.position).magnitude;
    }


}
