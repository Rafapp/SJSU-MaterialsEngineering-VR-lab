using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenController : MonoBehaviour
{
    [SerializeField]
    private Transform handle1, handle2;

    [SerializeField]
    private GameObject specimen;

    private float initialDistance;

    private void Awake()
    {
        initialDistance = (handle1.position - handle2.position).magnitude;
    }
    private void Update()
    {
        // This is intensive, must only happen when grabbing both handles
        // initial scale = distance bet. handles - handle diameter 
        specimen.transform.localScale = new Vector3(specimen.transform.localScale.x, specimen.transform.localScale.y, ((handle1.position - handle2.position).magnitude - (handle1.transform.localScale.z)));
        specimen.transform.localPosition = (handle1.localPosition + handle2.localPosition)*0.5f;
    }
}
