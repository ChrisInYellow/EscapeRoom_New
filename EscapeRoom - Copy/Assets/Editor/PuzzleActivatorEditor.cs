using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PuzzleActivator))]
public class PuzzleActivatorEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PuzzleActivator activator = (PuzzleActivator)target;
        if (GUILayout.Button("Puzzle1"))
        {
            activator.puzzle1();
        }


        if (GUILayout.Button("Puzzle2"))
        {
            activator.puzzle2();
        }


        if (GUILayout.Button("Puzzle3"))
        {
            activator.puzzle3();
        }


        if (GUILayout.Button("Puzzle4"))
        {
            activator.puzzle4();
        }

        if (GUILayout.Button("Puzzle5"))
        {
            activator.puzzle5();
        }
    }
}
