using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text mainText;
    [SerializeField] private GameObject elevatorPanel;
    public enum States { Walking, Running, Chilling, Jumping, Standing};

    public void ChangeMainText(States playerState)
    {
        switch (playerState)
        {
            case States.Walking:
                mainText.text = "Walking";
                break;
            case States.Running:
                mainText.text = "Running";
                break;
            case States.Chilling:
                mainText.text = "Chilling";
                break;
            case States.Jumping:
                mainText.text = "Jumping";
                break;
            default:
                mainText.text = "Standing";
                break;
        }
    }

    public void DisplayElevatorPanel()
    {
        elevatorPanel.SetActive(true);
    }

    public void CloseElevatorPanel()
    {
        elevatorPanel.SetActive(false);
    }
}
