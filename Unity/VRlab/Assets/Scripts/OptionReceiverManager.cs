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
        PullLever.pulledLeverEvent += Reposition;

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
            optionReceiverObjects[i].transform.position = solutionReceiverPositions[ i + (TensileLabManager.Instance.currentQuestion * 4)].position;
        }
        
    }
    private void CheckSolution() {

    }
    private void OnDestroy()
    {
        ConfirmButton.confirmButtonEvent -= CheckSolution;
        PullLever.pulledLeverEvent -= Reposition;
    }
}
