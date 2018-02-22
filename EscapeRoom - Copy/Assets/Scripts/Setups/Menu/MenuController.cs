using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
=======
//using UnityEditor;
>>>>>>> b07475ab5f3f8a1c368c540e6532ce31ac5ccdbc
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

    public void ExitGame()
    {
<<<<<<< HEAD
        Application.Quit();
=======
        if (Application.isEditor)
        {
           // EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
>>>>>>> b07475ab5f3f8a1c368c540e6532ce31ac5ccdbc
    }
}
