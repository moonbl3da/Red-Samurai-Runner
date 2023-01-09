using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingGame : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;
    AsyncOperation loading;
    public void LoadGame(int sceneIndex)
    {
        StartCoroutine(LoadSceneASync(sceneIndex));
    }

    IEnumerator LoadSceneASync(int sceneIndex)
    {
        loading = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while(!loading.isDone)
        {

            float progress = Mathf.Clamp01(loading.progress / .9f);
            slider.value = progress;
            progressText.text = (progress * 100.0f).ToString() + " %";

            yield return null;
        }
    }
 
}
