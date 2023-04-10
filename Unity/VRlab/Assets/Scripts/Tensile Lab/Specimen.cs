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
    public Animator brokenAnimator;
    private Vector3 initialPos;
    private Quaternion initialRot;

    private void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
        print("init:" + initialRot);
        meshRenderer = GetComponent<MeshRenderer>();
        brokenChild.SetActive(false);
    }
    public void BreakSpecimen()
    {
        meshRenderer.enabled = false;
        brokenChild.SetActive(true);
        if(brokenAnimator)
            brokenAnimator.SetTrigger("break");
    }
    public void ConnectSpecimen()
    {
        if (meshRenderer.enabled == true) return;
        meshRenderer.enabled = true;
        meshRenderer.material = FracturedMaterial;
        brokenChild.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // If we drop specimen, reset to table
        if (collision.gameObject.CompareTag("floor")) {
            transform.position = initialPos;
            transform.rotation = initialRot;
            print("final:" + transform.rotation);
        }
    }
}
