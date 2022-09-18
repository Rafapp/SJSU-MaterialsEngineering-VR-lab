using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoissonQuizManager : MonoBehaviour
{
    public static PoissonQuizManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;
    }

        [SerializeField]
    private GameObject checkButton;

    [SerializeField]
    private RectTransform[] solidSquaresRects, solidCirclesRects;

    [SerializeField]
    private Image[] solidSquaresImg, solidCirclesImg;

    [SerializeField]
    private RectTransform[] dottedSquares, dottedCircles;

    [ContextMenu("Check solutions test")]
    public void CheckSolutions()
    {
        // Check all squares (compressed, expansion)
        for (int i = 0; i < solidSquaresRects.Length; i++)
        {
            // 0 Poisson ratio, must be within .1 of size
            if (solidSquaresRects[0].sizeDelta.x < dottedSquares[0].sizeDelta.x + .1f &&
                solidSquaresRects[0].sizeDelta.x > dottedSquares[0].sizeDelta.x - .1f)
            {
                SetGreen(solidSquaresImg[0]);
            }
            else
            {
                SetRed(solidSquaresImg[0]);
            }

            // .20 Poisson ratio, must be bigger than dotted
            if (solidSquaresRects[1].sizeDelta.x > dottedSquares[1].sizeDelta.x)
            {
                SetGreen(solidSquaresImg[1]);
            }
            else
            {
                SetRed(solidSquaresImg[1]);
            }

            // .45 Poisson ratio, must be bigger than dotted
            if (solidSquaresRects[1].sizeDelta.x > dottedSquares[1].sizeDelta.x)
            {
                SetGreen(solidSquaresImg[2]);
            }
            else
            {
                SetRed(solidSquaresImg[2]);
            }
        }

        // Check all circles (tension, shrinkage)
        for (int i = 0; i < solidCirclesRects.Length; i++)
        {
            // 0 Poisson ratio, must be within .1 of size
            if (solidCirclesRects[0].sizeDelta.x < dottedCircles[0].sizeDelta.x + .1f &&
                solidCirclesRects[0].sizeDelta.x > dottedCircles[0].sizeDelta.x - .1f)
            {
                SetGreen(solidCirclesImg[0]);
            }
            else
            {
                SetRed(solidCirclesImg[0]);
            }

            // .20 Poisson ratio, must be smaller than dotted
            if (solidCirclesRects[1].sizeDelta.x < dottedCircles[1].sizeDelta.x)
            {
                SetGreen(solidCirclesImg[1]);
            }
            else
            {
                SetRed(solidCirclesImg[1]);
            }

            // .45 Poisson ratio
            if (solidCirclesRects[2].sizeDelta.x < dottedCircles[2].sizeDelta.x)
            {
                SetGreen(solidCirclesImg[2]);
            }
            else
            {
                SetRed(solidCirclesImg[2]);
            }
        }

        
    }
    private void SetGreen(Image img) { img.color = Color.green; }
    private void SetRed(Image img) { img.color = Color.red; }
}
