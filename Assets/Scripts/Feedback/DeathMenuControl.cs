using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _background;
    [SerializeField] GameObject _score;
    [SerializeField] GameObject _bretry;
    [SerializeField] GameObject _breturn;
    public void StartMenuCorrutine()
    {
          print("me LLamo");
        StartCoroutine(ActiveDeathMenu());
    }

    public IEnumerator ActiveDeathMenu(){
      
        Time.timeScale = 0;
        _background.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        _score.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
      _bretry.SetActive(true);
      _breturn.SetActive(true);
    }

    private void OnDestroy() {
        Time.timeScale = 1;
    }
}
