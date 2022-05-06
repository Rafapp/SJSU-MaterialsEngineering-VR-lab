using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Specimen : MonoBehaviour
{
    public SkinnedMeshRenderer meshRenderer;
    public GameObject brokenChild;
    private void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        brokenChild.SetActive(false);
    }
    public void BreakSpecimen()
    {
        meshRenderer.enabled = false;
        brokenChild.SetActive(true);
    }
}
