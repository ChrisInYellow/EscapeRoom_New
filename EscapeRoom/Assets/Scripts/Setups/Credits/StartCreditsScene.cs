using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCreditsScene : MonoBehaviour 
{
    public string whichSceneToLoad;

    public void OnTriggerEnter(Collider other)
    {
        LoadScene(); 
    }

    public void LoadScene ()
    {
        SceneManager.LoadScene(whichSceneToLoad);
    }
}
