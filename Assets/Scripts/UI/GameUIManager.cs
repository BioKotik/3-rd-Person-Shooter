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

    public void UpdateKillCount(int value)
    {
        killCount.text = value.ToString();
    }

    public void IncreaseKillCount()
    {
        killCount.text = (Convert.ToInt32(killCount.text) + 1).ToString();
    }

    public void ShowLoseScreen()
    {
        loseScreen.gameObject.SetActive(true);
    }
}
