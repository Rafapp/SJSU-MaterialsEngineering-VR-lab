using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    [SerializeField]
    GameObject singleSpecimenGraph, multipleSpecimenGraph;

    private GraphWindowController singleSpecimenGraphController, multipleSpecimenGraphController;

    public static GraphManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;

        singleSpecimenGraphController = singleSpecimenGraph.GetComponentInChildren<GraphWindowController>();
        multipleSpecimenGraphController = multipleSpecimenGraph.GetComponentInChildren<GraphWindowController>();
    }
    private void OnEnable()
    {
        TensileLabManager.questionChange += RenderGraph;
        
    }
    private void RenderGraph()
    {
        switch (TensileLabManager.Instance.currentSpecimen)
        {
            case (TensileLabManager.SpecimenType.Polymer):
                singleSpecimenGraphController.clearChildren();
                singleSpecimenGraphController.RenderGraph(0, true);
                multipleSpecimenGraphController.RenderGraph(0, false);
                return;
            case (TensileLabManager.SpecimenType.Metal):
                singleSpecimenGraphController.clearChildren();
                singleSpecimenGraphController.RenderGraph(1, true);
                multipleSpecimenGraphController.RenderGraph(1, false);
                return;
            case (TensileLabManager.SpecimenType.Ceramic):
                singleSpecimenGraphController.clearChildren();
                singleSpecimenGraphController.RenderGraph(2, true);
                multipleSpecimenGraphController.RenderGraph(2, false);
                return;

        }
    }
    public void OnDisable()
    {
        TensileLabManager.questionChange -= RenderGraph;
    }
}
