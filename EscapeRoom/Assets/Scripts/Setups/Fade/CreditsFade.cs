using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsFade : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MenuLoader());
    }

    private IEnumerator MenuLoader()
    {
        yield return new WaitForSeconds(48f);
        SceneManager.LoadScene("MainMenu");
    }
}
