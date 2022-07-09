using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    GameObject graphObject, graphObject2;

    [SerializeField]
    Image graphBackground, graphLine;

    private Animator graphAnimator;

    [SerializeField]
    [Header("0 = ceramic(grey),\n 1 = metal(yellow),\n 2 = Polymer(purple),\n 3 = allGraphs")]
    Sprite[] graphGrids;

    [SerializeField]
    Sprite[] graphLines;

    private int currentQuestion;

    private void UpdateQuiz()
    {

    }
}
