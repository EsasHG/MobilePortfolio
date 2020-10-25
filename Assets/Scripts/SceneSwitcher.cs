using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneSwitcher : MonoBehaviour
{
    public Image fadeToBlackImage;

    public Color solidColor = new Color(0,0,0,1);
    public Color transparentColor = new Color(0,0,0,0);

    private void Start()
    {
        FadeFromBlack();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ChangeScene(string sceneName)
    {
        fadeToBlackImage.gameObject.SetActive(true);
        fadeToBlackImage.DOColor(solidColor,0.3f).OnComplete(() => 
        { 
            SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
        });
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FadeFromBlack();
    }

    void FadeFromBlack()
    {
        fadeToBlackImage.gameObject.SetActive(true);
        fadeToBlackImage.color = solidColor;
        fadeToBlackImage.DOColor(transparentColor, 0.3f).OnComplete(() =>
        {
            fadeToBlackImage.gameObject.SetActive(false);
        });
    }

}
