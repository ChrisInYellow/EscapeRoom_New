using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawn : MonoBehaviour
{

    private Transform startPosition;
    private Vector3 storageVector;
    private GameObject self;
    private GameObject respawner; 
    // Use this for initialization
    void Start()
    {

        startPosition = transform;
    }

    public void OnTriggerEnter(Collider other)
    {
        Instantiate(transform.gameObject, startPosition);
        Destroy(gameObject);

    }
}
