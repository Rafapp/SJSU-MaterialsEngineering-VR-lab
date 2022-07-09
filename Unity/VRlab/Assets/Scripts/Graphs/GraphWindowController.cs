using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GraphWindowController : MonoBehaviour
{
    [System.Serializable]
    public class Graph {
        public string specimenName;
        [Header("The number of subdivision lines in the X and Y axis")]
        public int xSubdivisions, ySubdivisions;

        public TMP_FontAsset textFont;

        [Header("Speed with which the graph renders")]
        public float graphSpeed;

        [Header("Size of graph points")]
        public float pointSize;

        [Header("Thickness of lines connecting points")]
        public float lineThickness;

        [Header("Thickness of cartesian X and Y lines")]
        public float originLineThickness;

        [Header("X and Y offset between cartesian lines, and the borders of the graph")]
        public float xAxisOffset, yAxisOffset;

        [Header("Length of the divisions perpendicular to the cartesian line")]
        public float originDivisionLength;

        [Header("Size of the font used in X and Y axis numbering, and labels")]
        public float fontSize;

        [Header("Offset between the graph line and the numbers")]
        public float numberOriginOffset;

        [Header("Color for the numbers in the X and Y axis numbering")]
        public Color numberFontColor;

        [Header("Color for the graph title, and X,Y axis labels")]
        public Color labelTitleColor;

        [Header("Graph title, x label, and y label")]
        public string graphTitle, xLabel, yLabel;

        public Color pointColor, lineColor, originLineColor;
        public float[] xValues, yValues;
    }

    [SerializeField]
    private Sprite pointSprite;

    [SerializeField]
    private Graph[] graphs;

    private RectTransform graphContainer;

    private float xMax, yMax;

    // Polymer x and y data
    double[] xDataPolymer = { 0.0011849, 0.00213482, 0.00332087, 0.00498456, 0.00736662, 0.009272, 0.0121322, 0.0140381, 0.0166594, 0.019044, 0.0226169, 0.0276222, 0.0347687, 0.0392953, 0.0431071, 0.0481081, 0.0523977, 0.0545428, 0.0574023, 0.0597877, 0.061459, 0.0631317, 0.0652833, 0.0667192, 0.0681555, 0.0707885, 0.0741391, 0.0786841, 0.0810756, 0.0858588, 0.0920761, 0.0982929, 0.105466, 0.117659, 0.130091, 0.139176, 0.146827, 0.157586, 0.167627, 0.176951, 0.1901, 0.205162, 0.213051, 0.224766, 0.235762, 0.246282, 0.259908, 0.268754, 0.278794, 0.281903 };
    double[] yDataPolymer = { 1.52909, 2.4609, 3.82275, 5.25632, 6.52269, 7.57402, 8.84042, 9.82008, 11.0626, 11.9467, 13.8821, 16.1043, 19.8556, 22.1495, 24.1088, 26.9521, 28.9592, 29.915, 31.277, 32.0655, 32.3762, 32.4958, 32.4959, 32.281, 32.0183, 31.5407, 31.0153, 30.6334, 30.5141, 30.2516, 30.037, 29.8941, 29.8229, 29.7521, 29.6812, 29.5624, 29.4913, 29.4442, 29.3971, 29.35, 29.3031, 29.3041, 29.2569, 29.3055, 29.354, 29.3547, 29.4512, 29.4518, 29.4764, 29.4288 };

    // Metal x and y data
    double[] xDataMetal = { 0.000159017, 0.000297423, 0.000488966, 0.000755318, 0.00104255, 0.00129747, 0.00153209, 0.001819, 0.00197895, 0.0021595, 0.00231918, 0.00244646, 0.00263717, 0.00290145, 0.00327081, 0.00362896, 0.00394492, 0.00435533, 0.00463951, 0.00507079, 0.00550194, 0.00703625, 0.00916844, 0.0108742, 0.0140725, 0.0172708, 0.0215352, 0.0270789, 0.0324094, 0.0373134, 0.0405117, 0.047548, 0.0569296, 0.0680171, 0.0782516, 0.0899787, 0.102772, 0.116418, 0.130277, 0.142431, 0.156503, 0.169296, 0.183156, 0.195522, 0.20597, 0.21791, 0.230064, 0.243284, 0.254371, 0.267377, 0.277399, 0.286567, 0.295522, 0.302559, 0.310661, 0.317271, 0.324307, 0.33177, 0.33774, 0.34435, 0.350107, 0.35565, 0.360554, 0.364606, 0.366311 };
    double[] yDataMetal = { 8.80549, 20.6814, 36.5151, 60.5511, 83.7354, 101.827, 124.451, 145.653, 160.924, 173.645, 187.217, 195.13, 205.585, 216.314, 227.314, 233.786, 239.129, 243.896, 247.545, 251.46, 254.525, 259.384, 266.947, 272.829, 280.672, 288.796, 297.199, 306.443, 314.846, 322.409, 326.05, 334.734, 345.098, 356.303, 363.305, 372.549, 382.073, 390.476, 398.88, 406.443, 413.725, 421.008, 427.171, 432.213, 437.255, 440.336, 444.258, 446.779, 447.619, 448.179, 448.459, 447.339, 446.218, 443.697, 440.336, 437.535, 432.773, 427.451, 421.569, 414.846, 408.964, 401.12, 392.997, 386.275, 383.473 };

    // Ceramic x and y data
    double[] xDataCeramic = { 1.73E-05, 4.10E-05, 5.82E-05, 7.98E-05, 0.00011857, 0.000157379, 0.000200511, 0.000237197, 0.000278128, 0.000308323, 0.000351432, 0.000409622, 0.000441974, 0.000498008, 0.000541106, 0.000579949, 0.00061659, 0.000655398, 0.000692085 };
    double[] yDataCeramic = { 6.68858, 13.7458, 20.4363, 27.4955, 39.7549, 53.1321, 68.3682, 82.1199, 95.1225, 105.899, 120.39, 139.711, 151.231, 169.809, 183.927, 198.422, 210.683, 224.06, 237.812  };

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

        // POLYMER = GRAPHS[0] set data
        graphs[0].xValues = xDataPolymer.Select(d => (float)d).ToArray(); 
        graphs[0].yValues = yDataPolymer.Select(d => (float)d).ToArray();

        //METAL = GRAPHS[1] set data
        graphs[1].xValues = xDataMetal.Select(d => (float)d).ToArray();
        graphs[1].yValues = yDataMetal.Select(d => (float)d).ToArray();

        // CERAMIC = GRAPHS[2] set data
        graphs[2].xValues = xDataCeramic.Select(d => (float)d).ToArray();
        graphs[2].yValues = yDataCeramic.Select(d => (float)d).ToArray();

        // --TEST ONLY--TEST ONLY--TEST ONLY--
        //RenderGraph(graphs[2]);
    }
    public void RenderGraph(int index, bool renderNumbers)
    {
        StartCoroutine(SlowRenderGraph(graphs[index], renderNumbers));
    }
    IEnumerator SlowRenderGraph(Graph graph, bool renderNumbers)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;

        xMax = Mathf.Max(graph.xValues); // Maximum possible X value (from data)
        yMax = Mathf.Max(graph.yValues); // Maximum possible Y value (from data)

        GameObject previousPointObject = null;

        // Draw the X and Y origin lines
        DrawOriginLines(graphWidth, graphHeight, graph, renderNumbers);

        // Render the many labels
        RenderTitleAndLabels(graph);

        // Will need to find a way for this for loop to run slow so we can see the plot going
        for (int i = 0; i < graph.xValues.Length; i++)
        {
            // Normalize to local graph size
            float xPos = ((graph.xValues[i] / xMax) * (graphWidth - graph.xAxisOffset));
            float yPos = ((graph.yValues[i] / yMax) * (graphHeight - graph.yAxisOffset));

            // Render the point, store it as a gameobject
            GameObject currentPointObject = createPoint(new Vector2(xPos + graph.xAxisOffset / 2,
                yPos + graph.yAxisOffset / 2), graph);

            // Check if we have 2 starting points, if so connect them, and start connecting all
            if (previousPointObject != null)
            {
                ConnectPoints(previousPointObject.GetComponent<RectTransform>().anchoredPosition,
                currentPointObject.GetComponent<RectTransform>().anchoredPosition, graph);
            }
            previousPointObject = currentPointObject;
            yield return new WaitForSeconds(graph.graphSpeed);
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

    // Draw X and Y  cartesian lines, with the corresponding divisions
    private void DrawOriginLines(float graphContainerWidth, float graphContainerHeight, Graph graph, bool renderNumbers)
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
        xLineTransform.sizeDelta = new Vector2(graphContainerWidth - graph.xAxisOffset + graph.originLineThickness,
            graph.originLineThickness);

        // Set dimensions of the Y line
        yLineTransform.sizeDelta = new Vector2(graph.originLineThickness,
             graphContainerHeight - graph.yAxisOffset + graph.originLineThickness);

        // Position correctly X and Y lines
        xLineTransform.anchoredPosition = new Vector2(graphContainerWidth / 2,
            graph.yAxisOffset / 2);
        
        yLineTransform.anchoredPosition = new Vector2(graph.xAxisOffset/2,
            graphContainerHeight / 2);

        // Render X divisions
        float xFraction = xLineTransform.sizeDelta.x / graph.xSubdivisions;
        for (int i = 0; i < graph.xSubdivisions + 1; i++) {
            // Position and render the X subdivisions
            Vector2 position = new Vector2(xFraction*i + graph.xAxisOffset/2, graph.yAxisOffset / 2);
            Vector2 size = new Vector2(graph.lineThickness, graph.originDivisionLength);
            RenderOriginDivision(position, size, graph);

            // Render the corresponding number
            float numberFractionX = Mathf.Max(graph.xValues) / graph.xSubdivisions;
            Vector3 xOriginTextAngle = new Vector3(0,0,90);
            Vector2 offset = new Vector2(0, graph.numberOriginOffset + graph.originDivisionLength);

            if (renderNumbers)
                RenderOriginNumber(position - offset, graph, numberFractionX*i, xOriginTextAngle);
        }

        // Render Y divisions
        float yFraction = yLineTransform.sizeDelta.y / graph.ySubdivisions;
        for (int i = 0; i < graph.ySubdivisions + 1; i++)
        {
            // Position and render the Y subdivisions
            Vector2 position = new Vector2(graph.xAxisOffset / 2, yFraction * i + graph.yAxisOffset / 2);
            Vector2 size = new Vector2(graph.originDivisionLength, graph.lineThickness);
            RenderOriginDivision(position, size, graph);

            // Render the corresponding number
            float numberFractionY = Mathf.Max(graph.yValues) / graph.ySubdivisions;
            Vector3 yOriginTextAngle = new Vector3(0, 0, 0);
            Vector2 offset = new Vector2(graph.numberOriginOffset + graph.originDivisionLength, 0);

            if(renderNumbers)
                RenderOriginNumber(position - offset, graph, numberFractionY * i, yOriginTextAngle);
        }
    }
    // Render division at (x,y) given a vector2 position, and a length
    private void RenderOriginDivision(Vector2 position, Vector2 size, Graph graph) {
        // Create division
        GameObject division = new GameObject("division", typeof(Image));

        // Set same color as X and Y axis
        division.GetComponent<Image>().color = graph.originLineColor;

        // Parent to graph container
        division.transform.SetParent(graphContainer, false);
        division.transform.SetParent(graphContainer, false);

        // Get transform, and set anchors to (0,0)
        RectTransform divisionTransform = division.GetComponent<RectTransform>();
        divisionTransform.anchorMin = new Vector2(0, 0);
        divisionTransform.anchorMax = new Vector2(0, 0);

        // Set size, and position
        divisionTransform.sizeDelta = size;
        divisionTransform.anchoredPosition = position;
    }

    // Render numbers for the X and Y origin subdivisions, helper function
    private void RenderOriginNumber(Vector2 position, Graph graph, float number, Vector3 angle)
    {
        // Get text component and set parameters
        GameObject text = new GameObject("text", typeof(TextMeshPro));
        TMP_Text textComponent = text.GetComponent<TMP_Text>();
        graph.numberFontColor.a = 1;
        textComponent.fontSize = graph.fontSize;
        textComponent.text = Math.Round(number, 2).ToString();
        textComponent.color = graph.numberFontColor;
        textComponent.alignment = TextAlignmentOptions.Center;
        textComponent.alignment = TextAlignmentOptions.Midline;
        textComponent.font = graph.textFont;

        // Get and set rect transform, set position
        RectTransform transform = text.GetComponent<RectTransform>();
        transform.anchorMin = new Vector2(0, 0);
        transform.anchorMax = new Vector2(0, 0);
        transform.transform.SetParent(graphContainer, false);

        transform.anchoredPosition = position;
        transform.localEulerAngles = angle;
    }

    // Render the graph's title, the Y label and the X label
    private void RenderTitleAndLabels(Graph graph)
    {
        Vector3 horizontal = new Vector3(0, 0, 0);
        Vector3 vertical = new Vector3(0, 0, 90);
        // Render the title
        RenderText(graph, new Vector2(graphContainer.sizeDelta.x / 2, graphContainer.sizeDelta.y - graph.fontSize/2), graph.graphTitle, horizontal);

        // Render the x label
        RenderText(graph, new Vector2(graphContainer.sizeDelta.x / 2, graph.yAxisOffset/2 - graph.fontSize/2), graph.xLabel, horizontal);

        // Render the y label
        RenderText(graph, new Vector2(graph.xAxisOffset/2 - graph.fontSize/2, graphContainer.sizeDelta.y / 2), graph.yLabel, vertical);

    }
    private void RenderText(Graph graph, Vector2 position, String textStr, Vector3 angle)
    {
        // Create graph title, and position it
        GameObject text = new GameObject("titleText", typeof(TextMeshPro));
        TMP_Text textComponent = text.GetComponent<TMP_Text>();
        RectTransform textTransform = text.GetComponent<RectTransform>();
        textComponent.text = textStr;
        textComponent.enableWordWrapping = false;

        textComponent.alignment = TextAlignmentOptions.Center;
        textComponent.alignment = TextAlignmentOptions.Midline;

        textComponent.fontSize = graph.fontSize;
        textTransform.transform.SetParent(graphContainer, false);
        textTransform.anchorMin = textTransform.anchorMax = new Vector2(0, 0);
        textTransform.anchoredPosition = position - new Vector2(0, textTransform.sizeDelta.y / 2);
        textTransform.localEulerAngles = angle;

        // Set color for all text
        graph.labelTitleColor.a = 1;
        textComponent.font = graph.textFont;
        textComponent.color = graph.labelTitleColor;
    }
    public void clearChildren()
    {
        foreach (Transform child in graphContainer.transform) {
            if(child.gameObject.name != "Background")
                GameObject.Destroy(child.gameObject);
        }
    }

    // Y max: 383.783
    // X max: .366

}
