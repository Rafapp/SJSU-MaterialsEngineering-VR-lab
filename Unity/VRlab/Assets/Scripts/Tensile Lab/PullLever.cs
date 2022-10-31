using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullLever : MonoBehaviour
{
    [SerializeField]
    private Animator leverAnimator;

    private bool waiting;

    public static event Action pulledLeverEvent;
    private void Awake()
    {
        waiting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand" && waiting == false)
        {
            waiting = true;
            leverAnimator.SetTrigger("leverAnim");
            pulledLeverEvent?.Invoke();
            Invoke("ResetWait", 5);
        }
    }

    // Add wait time so that we don't collide with the handle after pulling once
    private void ResetWait() { waiting = false; }
    
}
