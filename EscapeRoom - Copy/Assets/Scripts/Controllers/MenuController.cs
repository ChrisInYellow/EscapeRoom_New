using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string[] allScenes;
    [Range(0, 3)]
    public int whichSceneToLoad;

    public void LoadScene ()
    {
        SceneManager.LoadScene(allScenes[whichSceneToLoad]);
    }

    public void ExitGame ()
    {
        if (Application.isEditor)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
