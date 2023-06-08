using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuComponent : MonoBehaviour
{
    public Button startButton;

    public void Set(UnityAction startButtonAction)
    {
        startButton.onClick.AddListener(startButtonAction);
    }
}
