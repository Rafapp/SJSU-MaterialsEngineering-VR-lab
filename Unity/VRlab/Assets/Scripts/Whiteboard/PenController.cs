using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : MonoBehaviour
{
    [SerializeField]
    private WhiteboardController whiteboardScript;

    private RaycastHit hit;

    bool isDrawing;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Whiteboard"))
        {
            isDrawing = true;
        }
        else isDrawing = false;
    }
    private void LateUpdate()
    {
        if (isDrawing)
        {
            Ray r = new Ray(gameObject.transform.position, new Vector3(-1, 0, 0));
            if (Physics.Raycast(r, out hit, 0.1f))
            {
                whiteboardScript.Draw(hit.textureCoord.x, hit.textureCoord.y);
            }
        }
        else {
            whiteboardScript.lastPaintX = whiteboardScript.lastPaintY = 0;
        }
    }
}
