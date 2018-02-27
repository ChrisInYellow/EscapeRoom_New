using UnityEngine;

public class DirectionalLightController : MonoBehaviour 
{
    [HideInInspector]
    public GameObject MainGameLight;
    [HideInInspector]
    public GameObject InspectorLight;

    void Awake () 
	{
        MainGameLight.SetActive(true);
        InspectorLight.SetActive(false);
	}
}
