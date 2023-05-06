using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StudentIDmanager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text idText;
    public static StudentIDmanager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;
    }

    // Add number to the text
    public void addNumber(int number)
    {
        // 10 is for clear
        if (number == 10)
        {
            clear();
        }
        // 12 is for save
        else if (number == 12)
        {
            saveID();
        }
        // 13 is for Start
        else if (number == 13)
        {
            saveID();
            CSVDataWriter.Instance.Save();
        }
        // Numbers 0-9
        else idText.text += number.ToString();
    }
    // Clear all numbers
    public void clear()
    {
        idText.text = "";
    }
    // Save student ID
    public void saveID()
    {
        idText.text = "Student ID saved successfully";

    }
}
