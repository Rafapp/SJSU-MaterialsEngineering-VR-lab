using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SpecimenController : MonoBehaviour
{
    private enum ObjectType{ Cylinder, Cube }

    [SerializeField]
    private Transform handle1, handle2;

    [SerializeField]
    private GameObject specimen, transparentSpecimen;

    [SerializeField]
    private float poissonRatio, cubeOffset, cylinderOffset;

    private Vector3 transparentOffset, initialCube, initialCylinder;

    [SerializeField]
    private ObjectType obj;

    private float initialHandleDistance;

    [SerializeField]
    private float rangeLimitInPercent;

    [SerializeField]
    private TMP_Text pascalText;

    private void Awake()
    {
        // We slightly increase the transparent shape for some offset
        transparentOffset = new Vector3(.01f, .01f, .01f);

        // Initial handle distance
        initialHandleDistance = GetHandleValue();

        if (obj == ObjectType.Cube)
        {
            // Initial cube dimensions
            initialCube = specimen.transform.localScale;

            // Update the transparent shape to match
            transparentSpecimen.transform.localScale = initialCube + transparentOffset;
        }
        if (obj == ObjectType.Cylinder) {

            // Initial cylinder dimensions
            initialCylinder = specimen.transform.localScale;

            // Update the transparent shape to match
            transparentSpecimen.transform.localScale = initialCylinder + transparentOffset;
        }
    }
    private void Update()
    {
        // S = <handle * poisson * initialX, handle * poisson * initialY, handle>
        float handleSeparation = (handle1.position - handle2.position).magnitude;

        if (handleSeparation <= initialHandleDistance + (initialHandleDistance * rangeLimitInPercent) &&
            handleSeparation >= initialHandleDistance - (initialHandleDistance * rangeLimitInPercent))
        {
            UpdateText();
            Vector3 scale = specimen.transform.localScale;

            //Note: This is intensive, must only happen when grabbing both handles, must add logic with VR handles
            if (obj == ObjectType.Cube)
            {
                // Elongate or compress the shape using the handles, center shape
                specimen.transform.localScale = new Vector3((poissonRatio * scale.z) + cubeOffset, (poissonRatio * scale.z) + cubeOffset, handleSeparation);
            }
            else if (obj == ObjectType.Cylinder)
            {
                // Elongate or compress the shape using the handles, center shape
                specimen.transform.localScale = new Vector3((poissonRatio * scale.y) + cylinderOffset, handleSeparation/2, (poissonRatio * scale.y) + cylinderOffset); ;
            }
        }
    }

    public float GetHandleValue()
    {
        return (handle1.position - handle2.position).magnitude - initialHandleDistance;
    }

    private void UpdateText() {
        float roundedHandle = (float)Math.Round(GetHandleValue(), 3) * 1000.0f;

        if (GetHandleValue() > initialHandleDistance)
            pascalText.text = (-roundedHandle).ToString() + " MPa";
        else
            pascalText.text = roundedHandle.ToString() + " MPa";

    }
}
