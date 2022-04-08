using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullLever : MonoBehaviour
{
    public Animator leverAnimator;
    public Animator graphAnimator1, graphAnimator2;

    public static event Action pulledLeverEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            print("hand detected");
            leverAnimator.SetTrigger("leverAnim");
            pulledLeverEvent?.Invoke();
        }
    }
}
