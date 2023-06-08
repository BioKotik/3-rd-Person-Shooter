using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance => instance;
    public static float loadingProgress => instance.loading != null ? instance.loading.progress : 0;

    private static SceneTransition instance;
    private AsyncOperation loading;

    public void SwitchToScene(string sceneName)
    {
        loading = SceneManager.LoadSceneAsync(sceneName);
    }

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this);
    }
}
