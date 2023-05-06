using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [System.Serializable]
    enum labType {
        typeA,
        typeB
    };

    [SerializeField]
    labType type;

    public void OnStartButton() {
        if (type == labType.typeA)
            SceneManager.LoadScene(1);
        else if(type == labType.typeB)
            SceneManager.LoadScene(3);
    }

}
