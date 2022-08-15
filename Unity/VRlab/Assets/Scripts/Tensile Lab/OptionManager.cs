using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] initialPositions;

    [SerializeField]
    private GameObject[] optionObjects;

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
    private void ResetOptions() {
        
        for (int i = 0; i < optionObjects.Length; i++)
        {
            optionObjects[i].transform.parent = null;

            optionObjects[i].transform.position = initialPositions[i].position;
            optionObjects[i].transform.rotation = initialPositions[i].rotation;

            optionScripts[i].text.text = optionText[i + (TensileLabManager.Instance.currentQuestion * 4) - 4];
            optionScripts[i].optionMaterial.color = new Color32(0, 255, 255, 255);
            optionScripts[i].optionMaterial.color = new Color32(0, 255, 255, 255);
        }
    }
    private void OnDisable()
    {
        TensileLabManager.questionChange -= ResetOptions;
    }
}
