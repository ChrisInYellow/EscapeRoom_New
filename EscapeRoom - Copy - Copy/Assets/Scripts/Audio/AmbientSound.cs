using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    public static AmbientSound instance;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }
    }

    void Start ()
    {
        FindObjectOfType<AudioManager>().Play("AmbientBackground");
    }
	
	void Update ()
    {
		
	}
}
