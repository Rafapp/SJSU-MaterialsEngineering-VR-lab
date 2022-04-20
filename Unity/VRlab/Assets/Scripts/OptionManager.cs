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
    private void Start()
    {
        ResetOptions();
    }
    private void GetOptionProperties()
    {
        for (int i = 0; i < optionObjects.Length; i++)
        {
            optionScripts[i] = optionObjects[i].GetComponent<Option>();
        }
    }
    private void ResetOptions() {
        print("Resetting options");
        for (int i = 0; i < optionObjects.Length; i++)
        {
            optionScripts[i].optionMaterial.color = new Color(0, 255, 255, 255);
            optionScripts[i].text.text = optionText[i + (TensileLabManager.Instance.currentQuestion * 4) - 4];
            optionObjects[i].transform.position = initialPositions[i].position;
            optionObjects[i].transform.rotation = initialPositions[i].rotation;
        }
    }

    public void CheckSolution(int correctSolution) { 

    }

    private void OnDisable()
    {
        TensileLabManager.questionChange -= ResetOptions;
    }
}
