using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Fader))]
public class FaderEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Fader fader = (Fader)target;
        if (GUILayout.Button("Fade"))
        {
            fader.Fade();
        }
        if (GUILayout.Button("Fade To White"))
        {
            fader.FadeToWhite();
        }
    }
}