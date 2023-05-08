using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class OptionManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] initialPositions;

    [SerializeField]
    private GameObject[] optionObjects, optionReceivers;

    private Option[] optionScripts;

    [SerializeField]
    private string[] optionText;


    private void Awake()
    {
        optionScripts = new Option[optionObjects.Length];

        GetOptionProperties();

        TensileLabManager.questionChange += ResetOptions;
    }
    private void GetOptionProperties()
    {
        for (int i = 0; i < optionObjects.Length; i++)
        {
            optionScripts[i] = optionObjects[i].GetComponent<Option>();
        }
    }
    [ContextMenu("Reset")]
    private void ResetOptions() {
        if (TensileLabManager.Instance.currentQuestion > 1) {
            for (int i = 0; i < optionReceivers.Length; i++)
            {
                XRSocketInteractor interactor = optionReceivers[i].GetComponent<XRSocketInteractor>();
                interactor.socketActive = false;
            }
        }

        for (int i = 0; i < optionObjects.Length; i++)
        {
            optionObjects[i].transform.position = initialPositions[i].position;
            optionObjects[i].transform.rotation = initialPositions[i].rotation;

            optionScripts[i].text.text = optionText[i + (TensileLabManager.Instance.currentQuestion * 4) - 4];
            optionScripts[i].optionMaterial.color = new Color32(0, 255, 255, 255);
            optionScripts[i].optionMaterial.color = new Color32(0, 255, 255, 255);
        }
        Invoke("ResetSockets", 1);

        
    }

    private void ResetSockets() {
        for (int i = 0; i < optionReceivers.Length; i++)
        {
            XRSocketInteractor interactor = optionReceivers[i].GetComponent<XRSocketInteractor>();
            interactor.socketActive = true;
        }
    }

    private void OnDisable()
    {
        TensileLabManager.questionChange -= ResetOptions;
    }
}
