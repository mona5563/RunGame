using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1.0f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(int sceneNumber)
    {
        StartCoroutine(FadeOut(sceneNumber));
    }

    IEnumerator FadeIn()
    {
        float alpha = 1.0f;

        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator FadeOut(int sceneNumber)
    {
        float alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneNumber);
    }
}
