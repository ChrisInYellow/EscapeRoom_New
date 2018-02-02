using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnReturnToOrgin : MonoBehaviour
{

    Quaternion startRotation;
    Vector3 startPosition;

    //GameObject newPawn = ;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name + " has exit zone");
        if (other.gameObject.name == "ChessPlayArea")
        {
            ReturnToOrigin();
        }
    }

    public void ReturnToOrigin()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.rotation = startRotation;
        transform.position = startPosition;

        //Instantiate(gameObject, originPosition, originRotation);
        //Destroy(gameObject);
    }
}
