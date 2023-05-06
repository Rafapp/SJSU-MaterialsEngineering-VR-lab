using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Option : MonoBehaviour
{
    public int optionID;
    public Material optionMaterial;
    public TMP_Text text;
    private void Awake()
    {
        optionMaterial = GetComponent<Renderer>().material;
        text = GetComponentInChildren<TMP_Text>();
    }
}
