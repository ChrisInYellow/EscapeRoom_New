using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DoorController))]
public class DoorControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DoorController controller = (DoorController)target;
        if (GUILayout.Button("Open"))
        {
            controller.OpenDoor();
        }
    }
}