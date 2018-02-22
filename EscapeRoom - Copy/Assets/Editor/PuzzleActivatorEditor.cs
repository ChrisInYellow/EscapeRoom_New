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

        GUILayout.Box("Puzzles");
        if (GUILayout.Button("Painting Puzzle"))
        {
            activator.puzzle0();
        }

        if (GUILayout.Button("Flashlight Puzzle"))
        {
            activator.puzzle1();
        }
        
        if (GUILayout.Button("Combination Puzzle"))
        {
            activator.puzzle2();
        }

        if (GUILayout.Button("Chess Puzzle"))
        {
            activator.puzzle3();
        }

        if (GUILayout.Button("Eye Scanner puzzle"))
        {
            activator.puzzle4();
        }

        if (GUILayout.Button("Laser Puzzle"))
        {
            activator.puzzle5();
        }
        
        if (GUILayout.Button("Scale Puzzle"))
        {
            activator.puzzle6();
        }

        GUILayout.Box("Fuse");
        if (GUILayout.Button("Fuse Laser"))
        {
            activator.puzzle7();
        }

        GUILayout.Box("Credits");
        if (GUILayout.Button("Activate credits"))
        {
            activator.puzzle8();
        }
    }
}
