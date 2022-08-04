using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    [SerializeField]
    GameObject singleSpecimenGraph, polymerGraph, metalGraph, ceramicGraph, allGraph;

    private GraphWindowController singleSpecimenGraphController, polymerGraphController, metalGraphController, ceramicGraphController, allGraphController;

    public static GraphManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;

        singleSpecimenGraphController = singleSpecimenGraph.GetComponentInChildren<GraphWindowController>();
        polymerGraphController = polymerGraph.GetComponentInChildren<GraphWindowController>();
        metalGraphController = metalGraph.GetComponentInChildren<GraphWindowController>();
        ceramicGraphController = ceramicGraph.GetComponentInChildren<GraphWindowController>();
        allGraphController = allGraph.GetComponentInChildren<GraphWindowController>();
    }
    private void testGraph()
    {
        TensileLabManager.Instance.currentSpecimen = TensileLabManager.SpecimenType.Metal;
        RenderGraph();
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
                polymerGraphController.RenderGraph(0, true);
                allGraphController.RenderGraph(0, false);
                return;
            case (TensileLabManager.SpecimenType.Metal):
                singleSpecimenGraphController.clearChildren();
                singleSpecimenGraphController.RenderGraph(1, true);
                metalGraphController.RenderGraph(1, true);
                allGraphController.RenderGraph(1, false);
                return;
            case (TensileLabManager.SpecimenType.Ceramic):
                singleSpecimenGraphController.clearChildren();
                singleSpecimenGraphController.RenderGraph(2, true);
                ceramicGraphController.RenderGraph(2, true);
                allGraphController.RenderGraph(2, false);
                return;

        }
    }
    public void OnDisable()
    {
        TensileLabManager.questionChange -= RenderGraph;
    }
}
