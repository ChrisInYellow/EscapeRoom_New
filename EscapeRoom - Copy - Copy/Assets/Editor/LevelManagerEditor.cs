
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelManager lvlmanager = (LevelManager)target;
        if (GUILayout.Button("Scene Transition"))
        {
            lvlmanager.SceneTransition();
        }
    }
}