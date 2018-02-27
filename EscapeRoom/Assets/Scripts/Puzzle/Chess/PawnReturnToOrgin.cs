using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnReturnToOrgin : MonoBehaviour
{
    //Keeps track of initial values in chess pieces.
    private Quaternion startRotation;
    private Vector3 startPosition;

    //Sets initial values in chess pieces.
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    //When a chess piece exits surrounding box collider call ReturnToOrigin.
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ChessPlayArea")
        {
            ReturnToOrigin();
        }
    }

    //Resets a chess pieces velocity, rotation and position when called.
    public void ReturnToOrigin()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.rotation = startRotation;
        transform.position = startPosition;
    }
}
