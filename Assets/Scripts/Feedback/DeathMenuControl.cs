using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeathMenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _background;
    [SerializeField] GameObject _score;
    [SerializeField] GameObject _bretry;
    [SerializeField] GameObject _breturn;

    EventSystem _ev;
    [SerializeField] GameObject _leadboard;
    public void StartMenuCorrutine()
    {
          // print("me LLamo");
        StartCoroutine(ActiveDeathMenu());
        _ev = FindFirstObjectByType<EventSystem>();
    }

    public IEnumerator ActiveDeathMenu(){
      
        Time.timeScale = 0;
        _background.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        _score.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
      _bretry.SetActive(true);
      //_ev.currentInputModule. firstSelectedGameObject = _bretry;
      EventSystem.current.SetSelectedGameObject(_bretry);
      _breturn.SetActive(true);
      _leadboard.SetActive(true);
    }

    private void OnDestroy() {
        Time.timeScale = 1;
    }
}
