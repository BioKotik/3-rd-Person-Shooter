using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void OnGameEnd()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        GameUIManager.Instance.ShowLoseScreen();
    }
}
