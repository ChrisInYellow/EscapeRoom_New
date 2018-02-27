using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserSpawn : MonoBehaviour
{
    public UnityEvent puzzleSolved = new UnityEvent();

    public bool triggered;
    public bool master;
    public bool servant;
    public LayerMask mirrorLayerMask;
    public LineRenderer laser;
    public GameObject laserManager;
    public GameObject particleManager;

    private GameObject lastMirror;
    private bool openedLock;

    void Start()
    {
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, transform.position);
    }

    private void Update()
    {
        SpawningOrder();
    }

    public void SpawningOrder()
    {
        int frameOffset = Time.frameCount % 6;
        if ((frameOffset == 4) || (master && frameOffset == 0) || (servant && frameOffset == 2))
        {
            LaserSpawner();
        }
    }

    public void LaserSpawner()
    {
        if (!triggered)
        {
            laserManager.transform.gameObject.SetActive(false);

            if (lastMirror != null && lastMirror.GetComponent<LaserSpawn>() != null)
            {
                lastMirror.GetComponent<LaserSpawn>().Untrigger();
            }
            return;
        }
        else
        {
            laserManager.transform.gameObject.SetActive(true);
        }
        BeamInteraction();
    }

    //Raycast for drawing laser and code for collisions involving it.
    public void BeamInteraction()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, mirrorLayerMask))
        {
            particleManager.SetActive(true);
            GameObject hitObject = hit.transform.gameObject;

            if (!openedLock && hitObject.CompareTag("LockBoxLock"))
            {
                Solve();
            }

            if (lastMirror != null)
            {
                if (lastMirror != hitObject && lastMirror.GetComponent<LaserSpawn>() != null)
                {
                    lastMirror.GetComponent<LaserSpawn>().triggered = false;
                    lastMirror.transform.GetChild(0).gameObject.SetActive(false);
                }
            }

            laser.SetPosition(1, hit.point);

            particleManager.transform.position = hit.point;

            var laserSpawn = hitObject.GetComponent<LaserSpawn>();

            if (laserSpawn != null)
            {
                if (!laserSpawn.triggered)
                {
                    laserSpawn.transform.GetChild(0).gameObject.SetActive(true);
                    laserSpawn.Trigger();
                    particleManager.transform.gameObject.SetActive(false);
                }
                else if (laserSpawn.triggered && lastMirror != null && hitObject != lastMirror)
                {
                    lastMirror.transform.gameObject.SetActive(false);
                    lastMirror.GetComponent<LaserSpawn>().Untrigger();
                    lastMirror = null;
                }
            }
            lastMirror = hitObject;
        }
        else
        {
            if (lastMirror != null && lastMirror.GetComponent<LaserSpawn>() != null)
            {
                lastMirror.GetComponent<LaserSpawn>().Untrigger();
                lastMirror.transform.GetChild(0).gameObject.SetActive(false);
                lastMirror = null;
            }
            particleManager.SetActive(false);
        }

    }

    public void Trigger()
    {
        triggered = true;
    }

    public void Untrigger()
    {
        triggered = false;
    }

    public void Solve()
    {
        openedLock = true;
        puzzleSolved.Invoke();
    }
}
