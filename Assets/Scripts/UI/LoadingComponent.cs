using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingComponent : MonoBehaviour
{
    public TMP_Text percentage;
    public Slider progressBar;

    private readonly string loadingText = "Loading... {0}%";

    public void SetLoadingValue(float value)
    {
        percentage.text = string.Format(loadingText, (int)(value * 100));
        progressBar.value = value * 100;
    }

    private void Awake()
    {
        SetDefault();
    }

    private void Start()
    {
        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        float progress = 0f;

        while (progress < 1f)
        {
            progress = SceneTransition.loadingProgress;
            SetLoadingValue(progress);
            yield return null;
        }

        SetLoadingValue(1f);
    }   

    private void SetDefault()
    {
        percentage.text = loadingText;
        progressBar.value = 0;
    }
}
