using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class OptionReceiverManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] solutionReceiverPositions;

    [SerializeField]
    private GameObject[] optionReceiverObjects;

    private OptionReceiver[] optionReceiverScripts;

    [SerializeField]
    private int[] correctSolutionID;


    private void Awake()
    {
        ConfirmButton.confirmButtonEvent += CheckSolution;
        TensileLabManager.questionChange += Reposition;

        optionReceiverScripts = new OptionReceiver[optionReceiverObjects.Length];

        GetOptionReceiverProperties();
    }
    private void GetOptionReceiverProperties()
    {
        for (int i = 0; i < optionReceiverObjects.Length; i++)
        {
            optionReceiverScripts[i] = optionReceiverObjects[i].GetComponent<OptionReceiver>();
        }
    }
    private void Reposition()
    {
        for (int i = 0; i < optionReceiverObjects.Length; i++)
        {
            // 0 metal, 1 polymer, 2 ceramic, 3 null (final question)
            optionReceiverObjects[i].transform.position = solutionReceiverPositions[i + (TensileLabManager.Instance.specimenId * 3)].position;
        }
    }
    private void CheckSolution() {
        for (int i = 0; i < optionReceiverObjects.Length; i++)
        {
            IXRSelectInteractable optionInteractable = optionReceiverObjects[i].GetComponent<XRSocketInteractor>().GetOldestInteractableSelected();
            Option optionScript = optionInteractable.transform.gameObject.GetComponent<Option>();
            if (correctSolutionID[i + (TensileLabManager.Instance.specimenId * 3)] == optionScript.optionID)
                optionScript.optionMaterial.color = Color.green;
            else
                optionScript.optionMaterial.color = Color.red;
        }
    }
    private void OnDestroy()
    {
        ConfirmButton.confirmButtonEvent -= CheckSolution;
        TensileLabManager.questionChange -= Reposition;
    }
}
