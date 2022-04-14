using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageQuiz : MonoBehaviour
{
    [SerializeField]
    string[] optionsText;

    [SerializeField]
    int[] solutions;

    [SerializeField]
    private TextMeshPro option1, option2, option3, option4, questionNumber;

    public int selectedSolution;
    public int currentNumber;

    private void Awake()
    {

        // Whenever lever is pulled, update possible options
        PullLever.pulledLeverEvent += UpdateOptions;
    }

    // Update button colors, and answer selected after receiveing a butotn press
    private void ReceiveSelection(int id)
    {
       
    }

    // Updates question options depending on current question
    private void UpdateOptions()
    {
       
        
    }

    // Displays the solutions when the correct button is pressed
    private void DisplaySolutions()
    {

    }

    private bool CheckSolution(int selection, int answer)
    {
        return selection == answer;
    }
    private void OnDisable()
    {
        PullLever.pulledLeverEvent -= UpdateOptions;
    }
}
