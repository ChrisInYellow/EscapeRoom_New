using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string[] allScenes;
    [Range(0, 2)]
    public int whichSceneToLoad;

    public void LoadScene ()
    {
        SceneManager.LoadScene(allScenes[whichSceneToLoad]);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }
}
