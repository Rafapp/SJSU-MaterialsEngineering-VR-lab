using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLineRenderer : MonoBehaviour
{
    enum handleType { left, right, quiz}

    [SerializeField]
    private GameObject specimen;

    [SerializeField]
    private handleType type;

    private LineRenderer rend;

    private void Awake()
    {
        rend = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        rend.SetPosition(0, transform.position);
        if (type == handleType.left)
        {
            Vector3 point = new Vector3(specimen.transform.position.x, specimen.transform.position.y, specimen.transform.position.z + (specimen.transform.localScale.z / 2));
            rend.SetPosition(1, point);
        }
        else if (type == handleType.right)
        {
            Vector3 point = new Vector3(specimen.transform.position.x, specimen.transform.position.y, specimen.transform.position.z - (specimen.transform.localScale.z / 2));
            rend.SetPosition(1, point);
        }
        else if (type == handleType.quiz)
        {
            rend.SetPosition(1, specimen.transform.position);
        }
        
    }
}
