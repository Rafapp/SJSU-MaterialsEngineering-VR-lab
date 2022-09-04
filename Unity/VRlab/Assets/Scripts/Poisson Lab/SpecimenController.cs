using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenController : MonoBehaviour
{
    private enum ObjectType{ Cylinder, Cube }

    [SerializeField]
    private Transform handle1, handle2;

    [SerializeField]
    private GameObject specimen, transparentSpecimen;

    [SerializeField]
    private float poissonRatio, cubeOffset, cylinderOffset;

    private Vector3 transparentOffset;

    [SerializeField]
    private ObjectType obj;

    public float initialDistance;

    private void Awake()
    {
        transparentOffset = new Vector3(.01f, .01f, .01f);

        initialDistance = (handle1.position - handle2.position).magnitude;

        if (obj == ObjectType.Cube)
        {
            // Elongate or compress the shape using the handles, center shape
            specimen.transform.localScale = new Vector3(specimen.transform.localScale.z * poissonRatio + cubeOffset, specimen.transform.localScale.z * poissonRatio + cubeOffset,
                ((handle1.position - handle2.position).magnitude - (handle1.transform.localScale.z)));

            // Update the transparent shape to match
            transparentSpecimen.transform.localScale = specimen.transform.localScale + transparentOffset;
        }
        if (obj == ObjectType.Cylinder) {
            // Elongate or compress the shape using the handles, center shape
            specimen.transform.localScale = new Vector3(specimen.transform.localScale.y * poissonRatio + cylinderOffset,
                ((handle1.position - handle2.position).magnitude - (handle1.transform.localScale.z)) / 2, specimen.transform.localScale.y * poissonRatio + cylinderOffset);

            // Update the transparent shape to match
            transparentSpecimen.transform.localScale = specimen.transform.localScale + transparentOffset;
        }
    }
    private void Update()
    {
        //Note: This is intensive, must only happen when grabbing both handles, must add logic with VR handles

        if (obj == ObjectType.Cube)
        {
            // Elongate or compress the shape using the handles, center shape
            specimen.transform.localScale = new Vector3(specimen.transform.localScale.z * poissonRatio + cubeOffset, specimen.transform.localScale.z * poissonRatio + cubeOffset,
                ((handle1.position - handle2.position).magnitude - (handle1.transform.localScale.z)));

            // Center the cube between the handles
            specimen.transform.localPosition = (handle1.localPosition + handle2.localPosition) * 0.5f;
            transparentSpecimen.transform.localPosition = (handle1.localPosition + handle2.localPosition) * 0.5f;
        }
        else if (obj == ObjectType.Cylinder)
        {
            // Elongate or compress the shape using the handles, center shape
            specimen.transform.localScale = new Vector3(specimen.transform.localScale.y * poissonRatio + cylinderOffset,
                ((handle1.position - handle2.position).magnitude - (handle1.transform.localScale.z)) / 2, specimen.transform.localScale.y * poissonRatio + cylinderOffset);

            // Center the cylinder between the handles
            specimen.transform.localPosition = (handle1.localPosition + handle2.localPosition) * 0.5f;
            transparentSpecimen.transform.localPosition = (handle1.localPosition + handle2.localPosition) * 0.5f;
        }
    }

    public float GetCompressionValue()
    {
        return (handle1.position - handle2.position).magnitude - initialDistance;
    }
}
