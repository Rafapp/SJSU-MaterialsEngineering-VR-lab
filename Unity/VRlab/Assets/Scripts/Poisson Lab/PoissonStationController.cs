using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoissonStationController : MonoBehaviour
{
    [SerializeField]
    private Slider graphSlider;

    [SerializeField]
    private GameObject Cube, Cylinder;

    private SpecimenController CubeScript, CylinderScript;
    private void Awake()
    {
        CubeScript = Cube.GetComponent<SpecimenController>();
        CylinderScript = Cylinder.GetComponent<SpecimenController>();
    }
    private void Update()
    {
        SetSlider(CubeScript.GetCompressionValue());
    }

    private void SetSlider(float value)
    {
        graphSlider.value = value + .5f;
    }
}
