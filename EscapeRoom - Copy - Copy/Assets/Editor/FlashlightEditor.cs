using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FlashLight))]
public class FlashlightEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FlashLight flashlight = (FlashLight)target;
        if (GUILayout.Button("Activate"))
        {
            flashlight.Activate();
        }
    }
}
