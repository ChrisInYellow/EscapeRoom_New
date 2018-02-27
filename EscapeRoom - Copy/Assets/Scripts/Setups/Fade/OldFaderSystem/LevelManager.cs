using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 


public class LevelManager : MonoBehaviour {

    public Fader fader;
    public string pendingScene; 

public void SceneTransition()
    {
        //fader.Fade();

    }
public void LoadNewScene()
    {
        
            Debug.Log("Hello world");
            SceneManager.LoadScene(pendingScene);
    }
}
