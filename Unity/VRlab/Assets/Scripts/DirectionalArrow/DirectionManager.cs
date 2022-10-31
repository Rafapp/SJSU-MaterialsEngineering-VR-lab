using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int currentPrompt;

    private void Awake()
    {
        currentPrompt = 0;
    }

    private void Update()
    {
        DirectionSystem.transform.LookAt(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Update question
        if (collision.gameObject.name == currentPrompt.ToString()) {
            currentPrompt++;
        }
    }
}
