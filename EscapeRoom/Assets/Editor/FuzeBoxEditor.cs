using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FuzeBox))]
public class FuzeBoxEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FuzeBox fuzeBox = (FuzeBox)target;
        if (GUILayout.Button("Fuze is inserted"))
        {
            fuzeBox.OnSnapped();
        }
        if (GUILayout.Button("Fuze is ejected"))
        {
            fuzeBox.ShootOutFuze();
        }
    }
}
