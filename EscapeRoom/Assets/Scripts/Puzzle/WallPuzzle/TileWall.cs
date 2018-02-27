
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWall : MonoBehaviour
{
    private float rotateAngle = 90f;
    private float duration = 0.5f;
    private bool coolDown;
    private bool spin = false;

    [HideInInspector]
    public bool correctPosition = false;
    [HideInInspector]
    public bool isRight = false;
    [Range(0, 3)]
    public int correctSide;
    public int sideOfCube = 0;
    public bool importantTile;

    private WallPuzzleSingleton tileWallManager;

    private void OnDrawGizmos()
    {
        if (importantTile == true)
        {
            Gizmos.color = new Color(255, 0, 100, 1f);
            Gizmos.DrawCube(transform.position, new Vector3(.19f, .19f, .19f));
        }
    }

    public void Start()
    {
        tileWallManager = WallPuzzleSingleton.GetInstance();
        if (importantTile)
        {
            if (sideOfCube == correctSide)
            {
                isRight = true;
            }
            tileWallManager.CheckTiles(gameObject, isRight);
        }
    }

    public void FixedUpdate()
    {
        if (spin == true)
        {
            transform.Rotate(Vector3.up, rotateAngle * Time.deltaTime * (1 / duration));
        }
    }

    public void PlayAnim()
    {
        if (coolDown)
            return;
        coolDown = true;
        spin = true;
        Invoke("StopAnim", duration);

        sideOfCube += 1;

        if (sideOfCube > 3)
        {
            sideOfCube = 0;
        }

        if (sideOfCube == correctSide)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }

        if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
    }

    public void StopAnim()
    {
        coolDown = false;
        spin = false;

        if (importantTile)
        {
            CorrectSideSelected();
        }
    }

    public void CorrectSideSelected()
    {
        tileWallManager.CheckTiles(gameObject, isRight);
    }
}
