using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    public Button mainMenuButton;
    public Button restartButton;
    public TMP_Text killCount;

    public void SetKillCount(int killCount)
    {
        this.killCount.text = killCount.ToString();
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        mainMenuButton.onClick.AddListener(OnMainMenu);
        restartButton.onClick.AddListener(OnRestartButton);
    }

    private void OnMainMenu()
    {
        SceneTransition.Instance.SwitchToScene("MainMenu");
        Debug.Log("Loading Main Menu");
    }

    private void OnRestartButton()
    {
        SceneTransition.Instance.SwitchToScene("GameScene");
        Debug.Log("Loading Game Scene");
    }
}
