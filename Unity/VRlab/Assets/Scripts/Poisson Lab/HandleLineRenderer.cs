using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLineRenderer : MonoBehaviour
{
    [SerializeField]
    private Transform specimenTransform;

    private LineRenderer rend;

    private void Awake()
    {
        rend = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        rend.SetPosition(0, transform.position);
        rend.SetPosition(1, specimenTransform.position);
    }
}
