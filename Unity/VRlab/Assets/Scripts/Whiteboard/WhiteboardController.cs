using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WhiteboardController : MonoBehaviour
{
    private int strokeWidth, strokeHeight;
    private int textureWidth, textureHeight;
    public int lastPaintX, lastPaintY;

    [SerializeField]
    private Texture2D emptyWhiteboard;
    private Texture2D textureClone;
    private Renderer whiteboardRenderer;

    private Color32[] penColor;

    [Range(0, 1)]
    public float lerp = 0.05f;

    private void Start()
    {
        strokeWidth = 4;
        strokeHeight = 4;

        whiteboardRenderer = GetComponent<Renderer>();

        textureClone = Instantiate(emptyWhiteboard);
        whiteboardRenderer.material.mainTexture = textureClone;

        textureWidth = textureClone.width;
        textureHeight = textureClone.height;

        penColor = Enumerable.Repeat<Color32>(new Color32(0, 0, 0, 255),
            strokeWidth * strokeHeight).ToArray<Color32>();
    }
    public void ResetWhiteboard()
    {
        whiteboardRenderer.material.mainTexture = textureClone;
    }
    public void Draw(float x, float y)
    {
        try
        {
            int texturePosX = (int)(x * (float)textureWidth - (float)(strokeWidth / 2));
            int texturePosY = (int)(y * (float)textureHeight - (float)(strokeHeight / 2));

            textureClone.SetPixels32(texturePosX, texturePosY, strokeWidth, strokeHeight, penColor);

            if (lastPaintX != 0 && lastPaintY != 0)
            {
                int lerpCount = (int)(1 / lerp);
                for (int i = 0; i <= lerpCount; i++)
                {
                    int xVal = (int)Mathf.Lerp((float)lastPaintX, (float)texturePosX, lerp);
                    int yVal = (int)Mathf.Lerp((float)lastPaintY, (float)texturePosY, lerp);
                    textureClone.SetPixels32(xVal, yVal, strokeWidth, strokeHeight, penColor);
                }
            }
            textureClone.Apply();
            lastPaintX = texturePosX;
            lastPaintY = texturePosY;
        }
        catch
        {
            // Out of whiteboard range
        }
    }
}
