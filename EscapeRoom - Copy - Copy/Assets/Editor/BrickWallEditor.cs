using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WallPuzzleSingleton))]
public class BrickWallEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WallPuzzleSingleton wallPuzzleSingleton = (WallPuzzleSingleton)target;
        if (GUILayout.Button("Complete wall puzzle"))
        {
            wallPuzzleSingleton.PuzzleDone();
        }
    }
}
