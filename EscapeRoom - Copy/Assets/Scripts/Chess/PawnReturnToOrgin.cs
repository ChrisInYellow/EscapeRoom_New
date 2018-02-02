using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnReturnToOrgin : MonoBehaviour {

    Quaternion originRotation;
    Vector3 originPosition;
    bool outside;

    //GameObject newPawn = ;

	void Start () {
        originRotation = transform.rotation;
        originPosition = transform.position;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pawns")
        {
            outside = true;
        }
    }

    public void ReturnToOrigin()
    {
        if (outside)
        {
            Instantiate(gameObject, originPosition, originRotation);
            Transform.Destroy(gameObject);
        }
    }
}
