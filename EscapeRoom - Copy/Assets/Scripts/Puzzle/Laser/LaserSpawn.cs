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
    public LayerMask blockable; 
    private Vector3 result; 
    private Quaternion laserRotation;
    private GameObject lastMirror; 



    // Use this for initialization
    void Start () {
         //mirrorDirections = Directions.None; 
         gameObject.transform.Rotate(Vector3.zero);
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, transform.position);
        laser.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(false);
        laser.transform.GetChild(0).GetChild(2).transform.gameObject.SetActive(false);

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

        Debug.DrawLine(transform.position, transform.position + transform.forward * 5f, Color.red);
       if ( Physics.Raycast(transform.position, transform.forward,out hit, 5f,mirror))
       {
            GameObject hitMirror = hit.transform.gameObject;
            lastMirror = hitMirror; 

            if(hitMirror.GetComponent<LaserSpawn>().triggered == false)
            {
                hitMirror.GetComponent<LaserSpawn>().laser.enabled = true;
                hitMirror.GetComponent<LaserSpawn>().triggered = true; 
                laser.transform.GetChild(0).transform.gameObject.SetActive(false);
                laser.SetPosition(1, new Vector3(laser.GetPosition(1).x, laser.GetPosition(1).y, hit.transform.position.z));
                laser.transform.GetChild(0).GetChild(0).transform.position = hit.transform.position;
                laser.transform.GetChild(0).GetChild(2).transform.position = hit.transform.position;

                laser.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true);
                laser.transform.GetChild(0).GetChild(2).transform.gameObject.SetActive(true);
            }
       }

       else
        {
            if (lastMirror != null)
            {
                lastMirror.GetComponent<LaserSpawn>().triggered = false;
                lastMirror.GetComponent<LaserSpawn>().laser.enabled = false;
            }
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, blockable))
        {
            laser.SetPosition(1, transform.position + transform.forward * 5f); 
            Debug.Log(hit);
            laser.SetPosition(1, new Vector3( laser.GetPosition(1).x, laser.GetPosition(1).y, hit.transform.position.z));
            laser.transform.GetChild(0).GetChild(0).transform.position = hit.transform.position;
            laser.transform.GetChild(0).GetChild(2).transform.position = hit.transform.position;

            laser.transform.GetChild(0).GetChild(0).transform.gameObject.SetActive(true); 
            laser.transform.GetChild(0).GetChild(2).transform.gameObject.SetActive(true);

        }


        else
        {
            laser.SetPosition(1, transform.position + transform.forward * 5f); 
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
