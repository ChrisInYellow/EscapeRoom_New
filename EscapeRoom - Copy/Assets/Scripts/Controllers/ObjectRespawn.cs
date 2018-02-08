using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawn : MonoBehaviour
{

    private Vector3 startPosition;
    private Quaternion startRotation; 
    // Use this for initialization
    void Start()
    {

        startPosition = transform.position;
        startRotation = transform.rotation; 
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawner")
        {
            
            GameObject newInstance = Instantiate(transform.gameObject);
            newInstance.transform.position = startPosition;
            newInstance.transform.rotation = startRotation; 
            Destroy(gameObject);
        }

    }
}
