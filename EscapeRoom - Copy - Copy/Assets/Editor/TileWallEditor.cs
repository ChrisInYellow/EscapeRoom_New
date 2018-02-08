using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileWall))]
public class TileWallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TileWall tileWall = (TileWall)target;
        if (GUILayout.Button("Spin"))
        {
            tileWall.PlayAnim();
        }
    }
}
