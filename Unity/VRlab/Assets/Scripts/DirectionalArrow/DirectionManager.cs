using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DirectionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject DirectionSystem;

    [SerializeField]
    private Transform direction;

    [SerializeField]
    private Collider[] colliders;

    [SerializeField]
    private string[] prompts;

    [SerializeField]
    private TMP_Text text;

    private int currentPrompt;

    private void Awake()
    {
        currentPrompt = 0;
        direction = colliders[currentPrompt].transform;
        text.text = prompts[currentPrompt];
    }

    private void Update()
    {
        DirectionSystem.transform.LookAt(direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Update question
        if (other.gameObject.name == currentPrompt.ToString()) {
            currentPrompt++;
            direction = colliders[currentPrompt].transform;
            text.text = prompts[currentPrompt];
        }
    }
}
