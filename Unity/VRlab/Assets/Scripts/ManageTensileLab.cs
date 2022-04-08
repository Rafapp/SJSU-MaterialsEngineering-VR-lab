using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ManageTensileLab : MonoBehaviour
{
    // Variables and instances
    public enum SpecimenType
    {
        Metal, Ceramic, Polymer, Null
    }

    public static ManageTensileLab Instance;

    public int currentQuestion;

    public SpecimenType currentSpecimen;

    SpecimenType lastSpecimen = SpecimenType.Null;

    // GameObjects
    [SerializeField]
    GameObject specimenSocket;

    // GameObject components
    

    private XRSocketInteractor specimenSocketInteractor;

    #region Unity Functions
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;

        specimenSocketInteractor = specimenSocket.GetComponent<XRSocketInteractor>();

        // Update current question if correct specimen is tested
        PullLever.pulledLeverEvent += UpdateQuestion;
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
    #endregion

    #region Lab Functions
    private void UpdateQuestion()
    {
        print("updating question");
        currentSpecimen = checkSpecimen();
        if (currentSpecimen != lastSpecimen)
        {
            currentQuestion++;
            lastSpecimen = currentSpecimen;
        }
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
