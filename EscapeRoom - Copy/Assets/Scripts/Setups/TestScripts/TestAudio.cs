using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
	void Update ()
    {
        FindObjectOfType<AudioManager>().Play("AmbientBackground");
    }
}
