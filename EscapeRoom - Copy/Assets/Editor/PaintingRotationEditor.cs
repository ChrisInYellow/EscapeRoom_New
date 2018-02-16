using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PaintingRotation))]
public class PaintingRotationEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PaintingRotation rotation = (PaintingRotation)target;
        if (GUILayout.Button("Rotate"))
        {
            rotation.StartRotation();
        }
    }
}
