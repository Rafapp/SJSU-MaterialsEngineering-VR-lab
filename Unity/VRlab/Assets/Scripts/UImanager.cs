using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text UItext;
    private void OnEnable()
    {
        TensileLabManager.questionChange += updateText;
    }
    private void updateText()
    {
        switch (TensileLabManager.Instance.currentQuestion)
        {
            case (1):
                UItext.text = "Well done! Now look at the graphs at your right, drag and drop solutions to the quiz and press check.";
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
    private void OnDestroy()
    {
        TensileLabManager.questionChange -= updateText;
    }
}
