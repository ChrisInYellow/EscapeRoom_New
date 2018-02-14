using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DoorSlamScript))]
public class DoorSlamEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DoorSlamScript doorSlam = (DoorSlamScript)target;
        if (GUILayout.Button("Slam door"))
        {
            doorSlam.DoorSlamActivate();
        }
    }
}
