using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : MonoBehaviour
{
    [SerializeField]
    private WhiteboardController whiteboardScript;

    private RaycastHit hit;


    [SerializeField]
    private float rayLength;

    private void LateUpdate()
    {
        // CPU intensive, might need fix in the future
        Ray r = new Ray(gameObject.transform.position , new Vector3(-1, 0, 0));
        if (Physics.Raycast(r, out hit, rayLength))
        {
            if (hit.collider.name == "Whiteboard")
            {
                whiteboardScript.Draw(hit.textureCoord.x, hit.textureCoord.y);
            }
        }
        else
        {
            whiteboardScript.lastPaintX = whiteboardScript.lastPaintY = 0;
        }
    }
}
