﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(LaserSpawn))]
public class LaserSpawnEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LaserSpawn laserSpawn = (LaserSpawn)target;
        if (GUILayout.Button("Realign Laser Left"))
        {
            laserSpawn.RealignLaserLeft();
        }
        if(GUILayout.Button("Realign Laser Right"))
        {
            laserSpawn.RealignLaserRight();
        }

    }
}