using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public MainMenuComponent mainMenuWindow;
    public LoadingComponent loadingWindow;

    private void Start()
    {
        PrepareUi();
    }

    private void PrepareUi()
    {
        mainMenuWindow.Set(OnStart);

        mainMenuWindow.gameObject.SetActive(true);
        loadingWindow.gameObject.SetActive(false);
    }

    private void OnStart()
    {
        mainMenuWindow.gameObject.SetActive(false);
        loadingWindow.gameObject.SetActive(true);

        SceneTransition.Instance.SwitchToScene("GameScene");
    }
}
