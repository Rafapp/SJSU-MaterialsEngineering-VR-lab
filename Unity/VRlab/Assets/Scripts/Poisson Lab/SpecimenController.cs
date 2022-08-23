using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenController : MonoBehaviour
{
    [SerializeField]
    private Transform handle1, handle2;

    [SerializeField]
    private GameObject specimen, transparentSpecimen;

    [SerializeField]
    private float poissonRatio, offset;

    private Vector3 initialScale;

    private float initialDistance;

    private void Awake()
    {
        initialDistance = (handle1.position - handle2.position).magnitude;
        initialScale = gameObject.GetComponent<Transform>().localScale;

        // Elongate or compress the shape using the handles, center shape
        specimen.transform.localScale = new Vector3(specimen.transform.localScale.z * poissonRatio + offset, specimen.transform.localScale.z * poissonRatio + offset,
            ((handle1.position - handle2.position).magnitude - (handle1.transform.localScale.z)));

        // Update the transparent shape to match
        transparentSpecimen.transform.localScale = specimen.transform.localScale;
    }
    private void Update()
    {
        //Note: This is intensive, must only happen when grabbing both handles

        // Elongate or compress the shape using the handles, center shape
        specimen.transform.localScale = new Vector3(specimen.transform.localScale.z * poissonRatio + offset, specimen.transform.localScale.z * poissonRatio + offset,
            ((handle1.position - handle2.position).magnitude - (handle1.transform.localScale.z)));

        // Center the cube between the handles
        specimen.transform.localPosition = (handle1.localPosition + handle2.localPosition)*0.5f;
        transparentSpecimen.transform.localPosition = (handle1.localPosition + handle2.localPosition) * 0.5f;
    }
    public float getValue()
    {
        // Return a compression or extension value between -1 and 1
        return Mathf.Clamp((handle1.position - handle2.position).magnitude - initialDistance, -1f, 1f);
    }
}
