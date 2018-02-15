using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{

    public LineRenderer laser;
    public Vector3 amountOfDegrees;
    public enum Directions { None, Right, Left, Up, Down };
    public bool triggered;
    public bool master;
    public LayerMask mirror;
    public GameObject laserManager; 
    public GameObject particleManager; 
    private Vector3 result;
    private Quaternion laserRotation;
    private GameObject lastMirror;
    



    // Use this for initialization
    void Start()
    {
        //mirrorDirections = Directions.None; 
        gameObject.transform.Rotate(Vector3.zero);
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, transform.position);
        particleManager.transform.gameObject.SetActive(false); 

        if (triggered == false)
        {
            laserManager.transform.gameObject.SetActive(false); 

            //laser.GetComponentInChildren<ParticleSystem>().Stop(); 
        }
    }

    private void Update()
    {
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + transform.forward * 5f, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, mirror))
        {
            particleManager.transform.gameObject.SetActive(true); 
            GameObject hitMirror = hit.transform.gameObject;
            
            if(lastMirror != null)
            {
                if(lastMirror != hitMirror && lastMirror.GetComponent<LaserSpawn>() != null)
                {
                    lastMirror.GetComponent<LaserSpawn>().triggered = false;
                    //lastMirror.GetComponent<LaserSpawn>().laser.enabled = false;
                    lastMirror.transform.gameObject.SetActive(false);
                }
            }
            laser.SetPosition(1, new Vector3(hit.point.x, hit.point.y, hit.point.z));

            particleManager.transform.GetChild(0).GetComponent<ParticleSystem>().transform.position = laser.GetPosition(1);
            particleManager.transform.GetChild(1).GetComponent<ParticleSystem>().transform.position = laser.GetPosition(1);

            var laserSpawn = hitMirror.GetComponent<LaserSpawn>();

            if (laserSpawn != null && laserSpawn.triggered == false && laserSpawn.master == false)
            {
                if (hitMirror == lastMirror)
                {
                    //laserSpawn.laser.enabled = true;
                    hitMirror.transform.gameObject.SetActive(true); 
                    laserSpawn.triggered = true;
                    particleManager.transform.gameObject.SetActive(false);
                }
            }
           else if (laserSpawn != null && laserSpawn.triggered == true && laserSpawn.master == false)
            {
                if (lastMirror != null)
                {

                    if (hitMirror != lastMirror)
                    {
                        lastMirror.transform.gameObject.SetActive(false); 
                        lastMirror.GetComponent<LaserSpawn>().triggered = false;
                        //lastMirror.GetComponent<LaserSpawn>().laser.enabled = false;
                        lastMirror = null;
                    }
                }
            }
            lastMirror = hitMirror;
        }
        else
        {
            laser.SetPosition(1, transform.forward*10);
            if (lastMirror != null)
            {
                if (lastMirror.GetComponent<LaserSpawn>() != null)
                {
                    
                    lastMirror.GetComponent<LaserSpawn>().triggered = false;
                    lastMirror.transform.gameObject.SetActive(false);
                    //lastMirror.GetComponent<LaserSpawn>().laser.enabled = false;
                    lastMirror = null;
                }
            }
            particleManager.transform.gameObject.SetActive(false);
        }

    }

    public void RealignLaserLeft()
    {
            result = Vector3.Scale(amountOfDegrees, Vector3.up);
            transform.Rotate(result);

        }
    public void RealignLaserRight()
{
    result = Vector2.Scale(amountOfDegrees, Vector3.down);
    transform.Rotate(result);
}


}
