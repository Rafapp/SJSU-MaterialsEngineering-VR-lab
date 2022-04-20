using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfirmButton : MonoBehaviour
{
    [SerializeField]
    private Animator leverAnimator;

    public static event Action confirmButtonEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            leverAnimator.SetTrigger("buttonAnim");
            confirmButtonEvent?.Invoke();
        }
    }
}
