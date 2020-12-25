using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectRandomPlacer), true)]
public class UpdatableDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ObjectRandomPlacer data = (ObjectRandomPlacer)target;

        if (GUILayout.Button("Respawn Objects"))
        {
            data.SpawnObjects();
        }
        if(GUILayout.Button("Destroy Objects"))
        {
            data.RemoveAllSpawnedObjects(); 
        }

    }
}
