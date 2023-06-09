using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int killCount = 0;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void OnEnemyDeath()
    {
        killCount++;
        GameUIManager.Instance.SetKillCount(killCount);
    }

    public void OnGameEnd()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        GameUIManager.Instance.ShowLoseScreen(killCount);
    }
}
