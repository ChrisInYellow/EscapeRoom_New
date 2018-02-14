
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
    //[HideInInspector]
    public int sideOfCube = 0;
    [Range(0, 3)]
    public int correctSide;
    //Temporary solution for checking which of the tiles that are the correct path
    public bool importantTile;
    [HideInInspector]
    public bool isRight = false;
    
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
        PlayAnim();
    }

    public void FixedUpdate()
    {
        if (spin == true)
        {
            transform.Rotate(Vector3.up, rotateAngle * Time.deltaTime * (1 / duration));
            FindObjectOfType<AudioManager>().Play("WallTileTouch");
        }
    }

    public void PlayAnim ()
    {
        if (tileWallManager.stopPuzzle)
            return;
        if (!coolDown)
        {
            coolDown = true;
            spin = true;
            Invoke("StopAnim", duration);
        }

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
    }

    public void StopAnim ()
    {
        coolDown = false;
        spin = false;

        if(importantTile)
            {
                CorrectSideSelected();
            }
    }

    public void CorrectSideSelected ()
    {
        tileWallManager.CheckTiles(gameObject, isRight);
    }
}
