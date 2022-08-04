using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinpadButton : MonoBehaviour
{
    // 10 is for clear, 12 is for save
    [SerializeField]
    private int buttonNumber;

    private MeshRenderer meshRend;
    private Material mat;
    private Color initColor;
    private void Awake()
    {
        meshRend = GetComponent<MeshRenderer>();
        mat = meshRend.material;
        initColor = mat.color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            buttonPress();
        }
    }

    private void buttonPress()
    {
        StudentIDmanager.Instance.addNumber(buttonNumber);
        StartCoroutine("colorChange");
        
    }
    IEnumerator colorChange()
    {
        mat.color = Color.black;
        yield return new WaitForSeconds(.25f);
        mat.color = initColor;
    }
}
