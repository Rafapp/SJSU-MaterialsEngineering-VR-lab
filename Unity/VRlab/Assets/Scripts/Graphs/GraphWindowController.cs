using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphWindowController : MonoBehaviour
{
    [System.Serializable]
    public class Graph {
        public string specimenName;
        public float pointSize, lineThickness, originLineThickness, xAxisOffset, yAxisOffset;
        public Color pointColor, lineColor, originLineColor;
        public float[] xValues, yValues;
    }

    [SerializeField]
    private Sprite pointSprite;

    [SerializeField]
    private Graph[] graphs;

    private RectTransform graphContainer;

    private float xMax, yMax;


    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

        // --TEST ONLY--TEST ONLY--TEST ONLY--
        RenderGraph(graphs[0]);
    }

    private void RenderGraph(Graph graph)
    {
        float graphHeight = graphContainer.sizeDelta.y - (2*graph.yAxisOffset);
        float graphWidth = graphContainer.sizeDelta.x - (2 * graph.xAxisOffset);

        // Draw the X and Y origin lines
        DrawOriginLines(graphWidth, graphHeight, graph);

        xMax = Mathf.Max(graph.xValues); // Maximum possible X value (from data)
        yMax = Mathf.Max(graph.yValues); // Maximum possible Y value (from data)

        GameObject previousPointObject = null;

        // Will need to find a way for this for loop to run slow so we can see the plot going
        for (int i = 0; i < graph.xValues.Length; i++)
        {
            // Normalize to local graph size
            float xPos = (graph.xValues[i] / xMax) * graphWidth; 
            float yPos = (graph.yValues[i] / yMax) * graphHeight;

            // Render the point, store it as a gameobject
            GameObject currentPointObject = createPoint(new Vector2(xPos + graph.xAxisOffset, 
                yPos + graph.yAxisOffset), graph);

            // Check if we have 2 starting points, if so connect them, and start connecting all
            if (previousPointObject != null)
            {
                ConnectPoints(previousPointObject.GetComponent<RectTransform>().anchoredPosition,
                currentPointObject.GetComponent<RectTransform>().anchoredPosition, graph);
            }
            previousPointObject = currentPointObject;
        }
    }

    // Creates a point in graphContainer given a x,y vector2 position < size.x, size.y
    private GameObject createPoint(Vector2 anchoredPosition, Graph graph)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));

        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = pointSprite;

        // Make sure color is not transparent
        graph.pointColor.a = 1;
        gameObject.GetComponent<Image>().color = graph.pointColor;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(graph.pointSize, graph.pointSize);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return gameObject;
    }

    // Connect graph points using lines
    private void ConnectPoints(Vector2 pointA, Vector2 pointB, Graph graph)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);

        // Make sure color is not transparent
        graph.lineColor.a = 1;
        gameObject.GetComponent<Image>().color = graph.lineColor;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (pointB - pointA).normalized;
        float distance = Vector2.Distance(pointA, pointB);


        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance - graph.pointSize, graph.lineThickness);
        rectTransform.anchoredPosition = pointA + dir * distance * .5f;

        // Rotate at angle between the 2 points
        rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan(dir.y/dir.x));
    }

    // Draw X and Y  cartesian lines
    private void DrawOriginLines(float graphContainerWidth, float graphContainerHeight, Graph graph)
    {
        // Create images for the lines
        GameObject xLine = new GameObject("xLine", typeof(Image));
        GameObject yLine = new GameObject("yLine", typeof(Image));

        // Make sure color is not transparent
        graph.originLineColor.a = 1;

        // Set line colors
        xLine.GetComponent<Image>().color = graph.originLineColor;
        yLine.GetComponent<Image>().color = graph.originLineColor;

        // Make them children of the graphcontainer
        xLine.transform.SetParent(graphContainer, false);
        yLine.transform.SetParent(graphContainer, false);

        // Get their transforms, set anchors
        RectTransform xLineTransform = xLine.GetComponent<RectTransform>();
        xLineTransform.anchorMin = new Vector2(0, 0);
        xLineTransform.anchorMax = new Vector2(0, 0);

        RectTransform yLineTransform = yLine.GetComponent<RectTransform>();
        yLineTransform.anchorMin = new Vector2(0, 0);
        yLineTransform.anchorMax = new Vector2(0, 0);

        // Set dimensions of the X line
        xLineTransform.sizeDelta = new Vector2(graphContainerWidth - 2 * graph.xAxisOffset,
            graph.originLineThickness);

        // Set dimensions of the Y line
        yLineTransform.sizeDelta = new Vector2(graph.originLineThickness,
             graphContainerHeight - 2 * graph.yAxisOffset);

        // Position correctly X and Y lines
        xLineTransform.anchoredPosition = new Vector2(graphContainerWidth / 2, graph.yAxisOffset + graph.originLineThickness/2);
        yLineTransform.anchoredPosition = new Vector2(graph.xAxisOffset + graph.originLineThickness / 2, graphContainerHeight/2);
    }
}
