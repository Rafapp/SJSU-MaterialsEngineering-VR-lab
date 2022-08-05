using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text UItext;
    private void OnEnable()
    {
        TensileLabManager.questionChange += updateText;
        ConfirmButton.confirmButtonEvent += specimenText;
    }

    // The check button will make the "default text" run which just says, grab another specimen
    private void updateText()
    {
        switch (TensileLabManager.Instance.currentQuestion)
        {
            case (1):
                UItext.text = "Well done! Now look at the graphs at your right, drag and drop solutions to the quiz and press check    .";
                return;
            case (2):
                UItext.text = "Amazing! Look at the graph again, and solve the quiz";
                return;
            case (3):
                UItext.text = "You're great! You may solve the third quiz. After finishing, remove the specimen from the machine and pull lever";
                return;
            case (4):
                UItext.text = "Great job! Please respond the final quiz";
                return;
        }
    }

    private void specimenText()
    {
        if (TensileLabManager.Instance.currentQuestion >= 4)
            UItext.text = "Now, please pull the lever again with an empty specimen";
        else
        UItext.text = "Good. Check answers until all are right. After all are correct, test another specimen";
    }
    private void OnDestroy()
    {
        TensileLabManager.questionChange -= updateText;
        ConfirmButton.confirmButtonEvent -= specimenText;
    }
}
