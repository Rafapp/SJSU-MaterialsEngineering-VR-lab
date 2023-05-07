using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStation : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            anim.SetTrigger("ButtonAnimation");
            Invoke("ReloadScene", 2f);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
