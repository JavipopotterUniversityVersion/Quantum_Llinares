using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Image _fadeImage;
    [SerializeField] float _fadeTime = 1.0f;

    public void LoadScene(string scene) => StartCoroutine(LoadSceneRoutine(scene));
    public void LoadScene(string scene, bool white = false, UnityAction action = null)
    {
        if(white) _fadeImage.color = Color.white;
        else _fadeImage.color = Color.black;

        StartCoroutine(LoadSceneRoutine(scene, action));
    }
    public void LoadSceneInstantly(string scene) 
    {
        SceneManager.LoadScene(scene);
    }

    IEnumerator LoadSceneRoutine(string scene, UnityAction action = null)
    {
        for(float i = 0; i < _fadeTime; i += 0.01f)
        {
            _fadeImage.color = Color.Lerp(_fadeImage.color, Color.black, i/_fadeTime);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 1);
        action?.Invoke();

        SceneManager.LoadScene(scene);
    }

    public void Unfade() => StartCoroutine(UnfadeRoutine());
    IEnumerator UnfadeRoutine()
    {
        for(float i = 0; i < _fadeTime; i += Time.deltaTime)
        {
            _fadeImage.color = Color.Lerp(Color.black, Color.clear, i/_fadeTime);
            yield return new WaitForEndOfFrame();
        }
        _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 0);
    }

    public void Fade() => StartCoroutine(FadeRoutine());
    
    IEnumerator FadeRoutine()
    {
        for(float i = 0; i < _fadeTime; i += Time.deltaTime)
        {
            _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, i/_fadeTime);
            yield return new WaitForEndOfFrame();
        }
        _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 1);
    }
}
