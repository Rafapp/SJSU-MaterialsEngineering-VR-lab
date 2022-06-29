using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphWindowController : MonoBehaviour
{
    [SerializeField]
    private float pointSize, lineThickness;

    [SerializeField]
    Color pointColor, lineColor;

    [SerializeField]
    private Sprite pointSprite;

    private RectTransform graphContainer;

    private float[] ceramicXValues, ceramicYValues; // Ceramic
    private float[] metalXValues, metalYValues; // Metal
    private float[] polymerXValues, polymerYValues; // Polymer

    private float xMax, yMax;


    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        // Ceramic data
        ceramicXValues = new float[] { 0, 10, 20, 30, 40, 50, 60, 70, 100 };
        ceramicYValues = new float[] { 0, 10, 20, 30, 40, 50, 60, 70, 100 };

        // Metal data
        metalXValues = new float[] { };
        metalXValues = new float[] { };

        // Polymer data
        polymerXValues = new float[] { };
        polymerXValues = new float[] { };

        // --TEST ONLY--TEST ONLY--TEST ONLY--
        RenderGraph(ceramicXValues, ceramicYValues);
    }
    // Creates a pint in graphContainer given a x,y vector2 position < size.x, size.y
    private GameObject createPoint(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));

        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = pointSprite;
        gameObject.GetComponent<Image>().color = pointColor;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(pointSize,pointSize);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return gameObject;
    }

    private void RenderGraph(float[] xValues, float[] yValues)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;

        xMax = Mathf.Max(xValues); // Maximum possible X value (from data)
        yMax = Mathf.Max(yValues); // Maximum possible Y value (from data)

        GameObject previousPointObject = null;

        // Will need to find a way for this for loop to run slow so we can see the plot going
        for (int i = 0; i < xValues.Length; i++)
        {
            // Normalize to local graph size
            float xPos = (xValues[i] / xMax) * graphWidth; 
            float yPos = (yValues[i] / yMax) * graphHeight;

            // Render the point
            GameObject currentPointObject = createPoint(new Vector2(xPos, yPos));

            // Check if we have 2 starting points, if so connect them
            if (previousPointObject != null)
            {
                ConnectPoints(previousPointObject.GetComponent<RectTransform>().anchoredPosition,
                currentPointObject.GetComponent<RectTransform>().anchoredPosition);

            }
            previousPointObject = currentPointObject;
        }
    }

    private void ConnectPoints(Vector2 pointA, Vector2 pointB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));

        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = lineColor;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (pointB - pointA).normalized;
        float distance = Vector2.Distance(pointA, pointB);


        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance - pointSize, lineThickness);
        rectTransform.anchoredPosition = pointA + dir * distance * .5f;

        // Rotate at angle between the 2 points
        rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan(dir.y/dir.x));
    }

    private void RenderXaxis()
    {

    }
    private void RenderYaxis()
    {

    }
}
