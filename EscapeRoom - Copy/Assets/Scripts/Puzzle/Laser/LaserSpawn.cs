using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserSpawn : MonoBehaviour
{
    public UnityEvent puzzleSolved = new UnityEvent();

    public LineRenderer laser;
    public Vector3 amountOfDegrees;
    public bool triggered;
    public bool master;
    public bool servant; 
    public LayerMask mirror;
    public GameObject laserManager; 
    public GameObject particleManager; 
    private Vector3 result;
    private Quaternion laserRotation;
    private GameObject lastMirror;
    private bool openedLock;



    // Use this for initialization
    void Start()
    {
        gameObject.transform.Rotate(Vector3.zero);
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, transform.position);
        particleManager.transform.gameObject.SetActive(false); 
        laserManager.transform.gameObject.SetActive(false); 
        
    }

    private void Update()
    {
        if (master && Time.frameCount % 6 == 0)
        {
            LaserSpawner(); 
        }
        else if (servant && Time.frameCount % 6 == 2)
        {
            LaserSpawner(); 
        }
        else if(Time.frameCount % 6 == 4)
        {
            LaserSpawner();
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

    public void Trigger()
    {
        triggered = true;
    }

    public void Untrigger()
    {
        triggered = false;
    }

    public void LaserSpawner()
    {
        if (!triggered)
        {
            laserManager.transform.gameObject.SetActive(false);
            if (lastMirror != null)
                if (lastMirror.GetComponent<LaserSpawn>() != null)
                    lastMirror.GetComponent<LaserSpawn>().triggered = false;
            return;
        }
        else
            laserManager.transform.gameObject.SetActive(true);
            RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, mirror))
        {
            particleManager.transform.gameObject.SetActive(true);
            GameObject hitMirror = hit.transform.gameObject;

            if (!openedLock)
                if (hitMirror.tag == "LockBoxLock")
                {
                    openedLock = true;
                    Solve();
                    FindObjectOfType<AudioManager>().Play("Hint");
                }

            if (lastMirror != null)
            {
                if (lastMirror != hitMirror && lastMirror.GetComponent<LaserSpawn>() != null)
                {
                    lastMirror.GetComponent<LaserSpawn>().triggered = false;
                    lastMirror.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            laser.SetPosition(1, new Vector3(hit.point.x, hit.point.y, hit.point.z));

            particleManager.transform.GetChild(0).GetComponent<ParticleSystem>().transform.position = laser.GetPosition(1);
            particleManager.transform.GetChild(1).GetComponent<ParticleSystem>().transform.position = laser.GetPosition(1);

            var laserSpawn = hitMirror.GetComponent<LaserSpawn>();

            if (laserSpawn != null && !laserSpawn.triggered)
            {
                hitMirror.transform.GetChild(0).gameObject.SetActive(true);
                laserSpawn.triggered = true;
                particleManager.transform.gameObject.SetActive(false);
            }
            else if (laserSpawn != null && laserSpawn.triggered == true)
            {
                if (lastMirror != null)
                {

                    if (hitMirror != lastMirror)
                    {
                        lastMirror.transform.gameObject.SetActive(false);
                        lastMirror.GetComponent<LaserSpawn>().triggered = false;
                        lastMirror = null;
                    }
                }
            }
            lastMirror = hitMirror;
        }
        else
        {
            if (lastMirror != null)
            {
                if (lastMirror.GetComponent<LaserSpawn>() != null)
                {

                    lastMirror.GetComponent<LaserSpawn>().triggered = false;
                    lastMirror.transform.GetChild(0).gameObject.SetActive(false);
                    lastMirror = null;
                }
            }
            particleManager.transform.gameObject.SetActive(false);
        }
    }

    public void Solve()
    {
        puzzleSolved.Invoke();
    }
}
