using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PoissonStationController : MonoBehaviour
{
    [SerializeField]
    private Slider graphSlider;

    [SerializeField]
    private GameObject Cube, Cylinder;

    [SerializeField]
    private GameObject CubeMesh, CylinderMesh;

    private Vector3 lastSizeCube, lastSizeCylinder;

    private SpecimenController CubeScript, CylinderScript;
    private void Awake()
    {
        lastSizeCube = Cube.transform.localScale;
        lastSizeCylinder = Cylinder.transform.localScale;

        CubeScript = Cube.GetComponent<SpecimenController>();
        CylinderScript = Cylinder.GetComponent<SpecimenController>();
    }
    private void Update()
    {
        if (CubeMesh.transform.localScale != lastSizeCube) {
            lastSizeCube = CubeMesh.transform.localScale;
            
            SetSlider(CubeScript.GetHandleValue());

            
        }
        else if(CylinderMesh.transform.localScale != lastSizeCylinder)
        {
            lastSizeCylinder = CylinderMesh.transform.localScale;
            SetSlider(CylinderScript.GetHandleValue());
        }
    }

    private void SetSlider(float value)
    {
        graphSlider.value = value + .5f;
    }
}
