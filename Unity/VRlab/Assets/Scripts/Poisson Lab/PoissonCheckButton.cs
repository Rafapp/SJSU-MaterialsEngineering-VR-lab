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
            GetComponent<Animator>().SetTrigger("button");
        }
    }
}
