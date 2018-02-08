using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ImportantTile : MonoBehaviour 
{
    public Transform parent;
    TileWall tileWallScript;

    void Start () 
	{
        tileWallScript = GetComponent<TileWall>();
        if (tileWallScript.importantTile == true)
        {
            transform.SetParent(parent);
        }
	}
}
