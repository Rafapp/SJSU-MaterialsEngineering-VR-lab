using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullLever : MonoBehaviour
{
    public Animator leverAnimator;
    public Animator graphAnimator1, graphAnimator2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            leverAnimator.SetTrigger("leverAnim");
            graphAnimator1.SetTrigger("graphAnim");
            graphAnimator2.SetTrigger("graphAnim");
        }
    }
}
