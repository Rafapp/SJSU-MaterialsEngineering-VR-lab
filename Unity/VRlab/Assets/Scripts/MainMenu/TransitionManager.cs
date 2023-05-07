using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [System.Serializable]
    private enum labType {
        type_A,
        type_B
    };

    [SerializeField]
    private labType type;

    public static TransitionManager Instance;

    private void Awake()
    {
        if (Instance == null && Instance != this) Instance = this;
        else Destroy(this);
    }

    public void OnStartPressed() {
        if (type == labType.type_A)
            SceneManager.LoadScene(1);
        else if (type == labType.type_B)
            SceneManager.LoadScene(3);
    }
}
