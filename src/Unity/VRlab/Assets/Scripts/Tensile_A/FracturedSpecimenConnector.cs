using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FracturedSpecimenConnector : MonoBehaviour
{
    private XRSocketInteractor socketInteractor;
    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }
    public void connectSpecimen()
    {
        IXRSelectInteractable specimenInteractable = socketInteractor.GetOldestInteractableSelected();
        GameObject specimen = specimenInteractable.transform.gameObject;
        if (specimen.name.Equals("Ceramic") || specimen.name.Equals("Metal") || specimen.name.Equals("Polymer"))
        {
            specimen.GetComponent<Specimen>().ConnectSpecimen();
        }
    }
}
