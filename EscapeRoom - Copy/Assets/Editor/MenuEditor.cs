using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MenuController))]
public class MenuEditor : Editor 
{	
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MenuController menuController = (MenuController)target;
        if (GUILayout.Button("Click to start"))
        {
            menuController.LoadScene();
        }
        if (GUILayout.Button("Click to exit"))
        {
            menuController.ExitGame();
        }
    }
}
