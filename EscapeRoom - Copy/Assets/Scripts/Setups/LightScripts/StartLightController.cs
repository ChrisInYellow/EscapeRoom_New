using UnityEngine;

public class StartLightController : MonoBehaviour 
{
    public GameObject mainLights;
    public GameObject hallWayLight;

    public void OnDoorSlamZoneEnter ()
    {
        mainLights.SetActive(true);
        hallWayLight.SetActive(false);
    }
}
