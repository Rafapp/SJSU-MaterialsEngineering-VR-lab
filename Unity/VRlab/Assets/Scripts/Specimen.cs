using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(MeshRenderer))]
public class Specimen : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public GameObject brokenChild;
    public Material FracturedMaterial;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        brokenChild.SetActive(false);
    }
    public void BreakSpecimen()
    {
        meshRenderer.enabled = false;
        brokenChild.SetActive(true);
    }
    public void ConnectSpecimen()
    {
        if (meshRenderer.enabled == true) return;
        meshRenderer.enabled = true;
        meshRenderer.material = FracturedMaterial;
        brokenChild.SetActive(false);
    }
}
