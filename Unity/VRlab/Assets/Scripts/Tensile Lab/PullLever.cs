using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullLever : MonoBehaviour
{
    [SerializeField]
    private Animator leverAnimator;

    public static event Action pulledLeverEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            leverAnimator.SetTrigger("leverAnim");
            pulledLeverEvent?.Invoke();
        }
    }
}
