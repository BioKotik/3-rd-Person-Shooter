using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuComponent : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    public void Set(UnityAction startButtonAction, UnityAction exitButtonAction)
    {
        startButton.onClick.AddListener(startButtonAction);
        exitButton.onClick.AddListener(exitButtonAction);
    }
}
