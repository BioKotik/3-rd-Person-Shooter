using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance => instance;

    private static GameUIManager instance;

    public LoseScreen loseScreen;
    public Text killCount;

    private void Awake()
    {
        instance = this;
        SetDefault();
    }

    private void SetDefault()
    {
        killCount.text = "0";
        loseScreen.gameObject.SetActive(false);
    }

    public void SetKillCount(int killCount)
    {
        this.killCount.text = killCount.ToString();
    }

    public void ShowLoseScreen(int killCount)
    {
        loseScreen.gameObject.SetActive(true);
        loseScreen.SetKillCount(killCount);
    }
}
