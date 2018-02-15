using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LockBoxTurner))]
public class RotateLockEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        LockBoxTurner lockBoxTurner = (LockBoxTurner)target;

        if (GUILayout.Button("Turn"))
        {
            lockBoxTurner.StartRotation();
        }
    }
}
