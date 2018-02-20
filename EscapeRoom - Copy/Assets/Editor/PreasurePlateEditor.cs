using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PreasurePlate))]
public class PreasurePlateEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PreasurePlate preasurePlate = (PreasurePlate)target;
        if (GUILayout.Button("Activate preasure plate"))
        {
            preasurePlate.enoughWeight.Invoke();
        }
    }
}
