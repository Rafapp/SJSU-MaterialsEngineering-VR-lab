using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager Instance;

    [SerializeField]
    private GameObject arrow1, arrow2;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;
    }

    // Flip arrow states, one must be enabled and one disabled in order to flip
    public void SwitchArrows()
    {
        arrow1.SetActive(!arrow1.activeSelf);
        arrow2.SetActive(!arrow1.activeSelf);
    }

    
}
