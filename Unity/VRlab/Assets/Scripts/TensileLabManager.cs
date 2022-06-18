using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class TensileLabManager : MonoBehaviour
{
    // Variables and instances
    public enum SpecimenType
    {
        Metal, Ceramic, Polymer, Null
    }
    // 0 metal, 1 polymer, 2 ceramic, 3 null
    public int specimenId;

    public static TensileLabManager Instance;

    public static event Action questionChange;

    public int currentQuestion = 0;

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
    #endregion

    #region Lab Functions
    private void UpdateQuestion()
    {
        currentSpecimen = checkSpecimen();
        if (currentSpecimen != lastSpecimen && currentSpecimen != SpecimenType.Null)
        {
            currentQuestion++;
            lastSpecimen = currentSpecimen;
            questionChange?.Invoke();
        }
        if (currentQuestion == 3 && currentSpecimen == SpecimenType.Null)
        {
            currentQuestion++;
            questionChange?.Invoke();
        }
    }

    private SpecimenType checkSpecimen() {
        IXRSelectInteractable specimenInteractable = specimenSocketInteractor.GetOldestInteractableSelected();
        GameObject specimen;
        try
        {
            specimen = specimenInteractable.transform.gameObject;
        }
        catch {
            specimenId = 3;
            return SpecimenType.Null;
        }
        switch (specimen.name) {
            case "Metal":
                specimen.GetComponent<Specimen>().BreakSpecimen();
                specimenId = 0;
                return SpecimenType.Metal;
            case "Polymer":
                specimen.GetComponent<Specimen>().BreakSpecimen();
                specimenId = 1;
                return SpecimenType.Polymer;
            case "Ceramic":
                specimen.GetComponent<Specimen>().BreakSpecimen();
                specimenId = 2;
                return SpecimenType.Ceramic;
        }
        return SpecimenType.Null;

    }
    #endregion
    private void OnDisable()
    {
        PullLever.pulledLeverEvent -= UpdateQuestion;
    }
}
