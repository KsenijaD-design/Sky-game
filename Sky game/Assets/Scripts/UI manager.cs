using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [SerializeField] private CanvasGroup overlay;
    [SerializeField] private float fadeSpeed = 0.5f;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private int nextLevelIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endPanel.SetActive(false);
        overlay.gameObject.SetActive(true);
        StartCoroutine(FadeOutOverlay());
        
    }

    private void finish()
    {
        endPanel.SetActive(true);
    }

    private void OnEnable()
    {
        FinishGate.FinishRaice += finish;
    }

    private void OnDisable()
    {
        FinishGate.FinishRaice -= finish;
    }

    private IEnumerator FadeInOverlay()
    {
        while (overlay.alpha < 1.0f)
        {
            overlay.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
    private IEnumerator FadeOutOverlay()
    {
        while (overlay.alpha > 0)
        {
            overlay.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    public void Retry()
    {
        StartCoroutine(RetryCoroutine());
    }

    private IEnumerator RetryCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }
    private IEnumerator QuitCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        Application.Quit();
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }
    private IEnumerator NextLevelCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(nextLevelIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
