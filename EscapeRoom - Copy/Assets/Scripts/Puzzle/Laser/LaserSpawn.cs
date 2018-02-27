﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserSpawn : MonoBehaviour
{
    public UnityEvent puzzleSolved = new UnityEvent();

    public bool triggered;
    public bool master;
    public bool servant;
    public LayerMask mirror;
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
        if (master && Time.frameCount % 6 == 0)
        {
            LaserSpawner();
        }
        else if (servant && Time.frameCount % 6 == 2)
        {
            LaserSpawner();
        }
        else if (Time.frameCount % 6 == 4)
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
                lastMirror.GetComponent<LaserSpawn>().triggered = false;
            }
            return;
        }
        else
            laserManager.transform.gameObject.SetActive(true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, mirror))
        {
            particleManager.transform.gameObject.SetActive(true);
            GameObject hitMirror = hit.transform.gameObject;

            if (!openedLock && hitMirror.tag == "LockBoxLock")
            {
                Solve();
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

            if (laserSpawn != null)
            {
                if (!laserSpawn.triggered)
                {
                    hitMirror.transform.GetChild(0).gameObject.SetActive(true);
                    laserSpawn.triggered = true;
                    particleManager.transform.gameObject.SetActive(false);
                }
                else if (laserSpawn.triggered && lastMirror != null && hitMirror != lastMirror)
                {
                    lastMirror.transform.gameObject.SetActive(false);
                    lastMirror.GetComponent<LaserSpawn>().triggered = false;
                    lastMirror = null;
                }
            }
            lastMirror = hitMirror;
        }
        else
        {
            if (lastMirror != null && lastMirror.GetComponent<LaserSpawn>() != null)
            {
                lastMirror.GetComponent<LaserSpawn>().triggered = false;
                lastMirror.transform.GetChild(0).gameObject.SetActive(false);
                lastMirror = null;
            }
            particleManager.transform.gameObject.SetActive(false);
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
