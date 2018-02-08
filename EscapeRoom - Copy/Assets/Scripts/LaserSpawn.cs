using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour {

    public LineRenderer laser;
    public Vector3 amountOfDegrees;
    public enum Directions { None, Right, Left, Up, Down };
    public Directions mirrorDirections;
    public bool triggered;
    private RaycastHit proximitycheck;
    public LayerMask mirror; 
    private Vector3 result; 
    private Quaternion laserRotation; 



    // Use this for initialization
    void Start () {
         //mirrorDirections = Directions.None; 
         gameObject.transform.Rotate(Vector3.zero);


        if (triggered == false)
        {
            laser.enabled = false;
            laser.transform.GetChild(0).transform.gameObject.SetActive(false); 
            //laser.GetComponentInChildren<ParticleSystem>().Stop(); 
        }
	}

    private void Update()
    {
        RaycastHit hit;

        Debug.DrawLine(transform.position, Vector3.up + transform.forward * 5f);
       if ( Physics.Raycast(transform.position, transform.forward,out hit, 5f,mirror))
        {
            GameObject hitMirror = hit.transform.gameObject;

            if(hitMirror.GetComponent<LaserSpawn>().triggered == false)
            {
                hitMirror.GetComponent<LaserSpawn>().laser.enabled = true;
                laser.transform.GetChild(0).transform.gameObject.SetActive(false);
            }
        }

    }

    public void RealignLaser()
    {
        if (mirrorDirections == Directions.Left)
        {
            result = Vector3.Scale(amountOfDegrees, Vector3.left); 
            transform.Rotate(result); 
        }
        if(mirrorDirections == Directions.Right)
        {
            result = Vector3.Scale(amountOfDegrees, Vector3.right); 
            transform.Rotate(result); 
        }
        if(mirrorDirections == Directions.Up)
        {
            result = Vector3.Scale(amountOfDegrees, Vector3.up);
            transform.Rotate(result); 
         
        }
        if (mirrorDirections == Directions.Down)
        {
            result = Vector2.Scale(amountOfDegrees, Vector3.down);
            transform.Rotate(result); 
        }
    }


}
