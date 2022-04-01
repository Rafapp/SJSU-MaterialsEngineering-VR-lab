using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TensileLabManager : MonoBehaviour
{
    // Variables and instances
    public static TensileLabManager Instance;
    private enum SpecimenType { 
        Metal, Ceramic, Polymer, Null
    }

    private SpecimenType currentSpecimen;

    // GameObjects
    [SerializeField]
    GameObject graphObject1, graphObject2, specimenSocket;

    // GameObject components
    [SerializeField]
    private Sprite[] GraphSprites;

    private XRSocketInteractor specimenSocketInteractor;

    #region Unity Functions
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;

        specimenSocketInteractor = specimenSocket.GetComponent<XRSocketInteractor>();

        // Functions to be called after lever pulled event
        PullLever.pulledLeverEvent += LeverPulledFunction;
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
    #endregion

    #region Lab Functions
    private void LeverPulledFunction()
    {
        
    }

    private SpecimenType checkSpecimen() {
        IXRSelectInteractable specimenInteractable = specimenSocketInteractor.GetOldestInteractableSelected();
        GameObject specimen = specimenInteractable.transform.gameObject;
        switch (specimen.name) {
            case "Metal":
                return SpecimenType.Metal;
            case "Polymer":
                return SpecimenType.Polymer;
            case "Ceramic":
                return SpecimenType.Ceramic;
        }
        return SpecimenType.Null;
    }
    #endregion
}
