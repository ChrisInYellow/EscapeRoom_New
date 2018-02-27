using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(MirrorRotation))]
public class MirrorRotationEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MirrorRotation mirrorRotation = (MirrorRotation)target;
        if (GUILayout.Button("Realign Laser Left"))
        {
            mirrorRotation.RealignLaserLeft();
        }
        if(GUILayout.Button("Realign Laser Right"))
        {
            mirrorRotation.RealignLaserRight();
        }

    }
}
