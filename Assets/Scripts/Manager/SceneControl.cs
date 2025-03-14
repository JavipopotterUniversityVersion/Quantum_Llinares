using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void LoadScn(string scn){
        SceneManager.LoadScene(scn);
    }

    public void Quit(){
        Application.Quit();
    }
}
