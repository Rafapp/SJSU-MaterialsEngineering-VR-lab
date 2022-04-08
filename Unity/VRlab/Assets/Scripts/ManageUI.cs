using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageUI : MonoBehaviour
{
    [SerializeField]
    GameObject graphObject1, graphObject2;

    [SerializeField]
    Image graph1Background, graph2Background, graph1Line, graph2Line;
    

    private Animator graph1Animator, graph2Animator;

    [SerializeField]
    Sprite[] graphGrids;

    [SerializeField]
    Sprite[] graphLines;

    private int currentQuestion;
    private void Awake()
    {
        PullLever.pulledLeverEvent += UpdateGraphs;

        graph1Animator = graphObject1.GetComponent<Animator>();
        graph2Animator = graphObject2.GetComponent<Animator>();

        graph1Background.sprite = graphGrids[0];
        graph1Line.sprite = graphGrids[0];
        
        graph2Background.sprite = graphGrids[3];
        graph2Line.sprite = graphGrids[3];
    }
    private void UpdateGraphs()
    {
        switch (ManageTensileLab.Instance.currentSpecimen)
        {
            // Ceramic, grey graph
            case ManageTensileLab.SpecimenType.Ceramic:
                graph1Animator.SetTrigger("AnimateGraph");
                graph1Background.sprite = graphGrids[0];
                graph1Line.sprite = graphLines[0];
                break;

            // Metal, orange
            case ManageTensileLab.SpecimenType.Metal:
                graph1Animator.SetTrigger("AnimateGraph");
                graph1Background.sprite = graphGrids[1];
                graph1Line.sprite = graphLines[1];
                break;

            // Polymer, purple
            case ManageTensileLab.SpecimenType.Polymer:
                graph1Animator.SetTrigger("AnimateGraph");
                graph1Background.sprite = graphGrids[2];
                graph1Line.sprite = graphLines[2];
                break;
        }
        if (ManageTensileLab.Instance.currentQuestion == 4)
        {
            print("All elements tested");
            graph2Animator.SetTrigger("AnimateGraph");
            graph2Background.sprite = graphGrids[3];
            graph2Line.sprite = graphLines[3];
        }
    }
}
