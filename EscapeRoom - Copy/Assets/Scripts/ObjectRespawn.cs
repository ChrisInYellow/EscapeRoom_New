using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawn : MonoBehaviour
{

    private Transform startPosition;
    private Vector3 storageVector;
    private GameObject self;
    public GameObject respawner; 
    // Use this for initialization
    void Start()
    {

        startPosition = transform;
    }

    public void OnTriggerEnter(Collider respawner)
    {
        Instantiate(transform.gameObject, startPosition);
        Destroy(gameObject);

    }
}
