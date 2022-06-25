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
    private void Awake()
    {
        PullLever.pulledLeverEvent += UpdateGraphs;

        graphAnimator = graphObject.GetComponent<Animator>();

        graphBackground.sprite = null;
        //graphLine.sprite = null;
        
    }
    private void UpdateGraphs()
    {
        switch (TensileLabManager.Instance.currentSpecimen)
        {
            // Ceramic, grey graph
            case TensileLabManager.SpecimenType.Ceramic:
                graphBackground.sprite = graphGrids[0];
                graphLine.sprite = graphLines[0];
                graphAnimator.SetTrigger("AnimateGraph");
                break;

            // Metal, orange
            case TensileLabManager.SpecimenType.Metal:
                graphBackground.sprite = graphGrids[1];
                graphLine.sprite = graphLines[1];
                graphAnimator.SetTrigger("AnimateGraph");
                break;

            // Polymer, purple
            case TensileLabManager.SpecimenType.Polymer:
                graphBackground.sprite = graphGrids[2];
                graphLine.sprite = graphLines[2];
                graphAnimator.SetTrigger("AnimateGraph");
                break;
        }
        if (TensileLabManager.Instance.currentQuestion == 4)
        {
            print("graphing allgraph");
            graphBackground.sprite = graphGrids[3];
            graphLine.sprite = graphLines[3];
            graphAnimator.SetTrigger("AnimateGraph");
        }
    }

    private void UpdateQuiz()
    {

    }

    private void OnDisable()
    {
        PullLever.pulledLeverEvent -= UpdateGraphs;
    }
}
