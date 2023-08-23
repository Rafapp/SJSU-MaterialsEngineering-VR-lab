using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStation : MonoBehaviour
{

    [SerializeField]
    private int sceneToLoad;

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
            StartCoroutine(ReloadScene(sceneToLoad));
        }
    }

    IEnumerator ReloadScene(int sceneNumber)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneNumber);
    }
}
