using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoissonArrowManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private GameObject directionalArrow;

    [SerializeField]
    private float offset;

    [SerializeField]
    private Transform pointAt, cameraTransform;

    private void Update()
    {
        directionalArrow.transform.rotation = Quaternion.Euler(0,Vector3.Angle(directionalArrow.transform.position, pointAt.transform.position) + offset,0);
    }


}
