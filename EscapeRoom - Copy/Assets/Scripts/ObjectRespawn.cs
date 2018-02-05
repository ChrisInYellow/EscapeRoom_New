using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawn : MonoBehaviour {

    private Transform startPosition;
    private Vector3 storageVector; 
    private GameObject self; 
	// Use this for initialization
	void Start () {

        startPosition = transform; 
	}

    public void OnTriggerEnter(Collider other)
    {
        Instantiate(transform.gameObject, startPosition); 
        Destroy(gameObject); 

    }
    // Update is called once per frame
    void Update () {
		
	}
}
