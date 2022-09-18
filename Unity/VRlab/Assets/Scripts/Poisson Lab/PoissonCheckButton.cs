using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoissonCheckButton : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            PoissonQuizManager.Instance.CheckSolutions();
            GetComponent<Animation>().Play();
        }
    }
    [ContextMenu("test click")]
    private void click() {
        PoissonQuizManager.Instance.CheckSolutions();
        GetComponent<Animation>().Play();
    }
}
