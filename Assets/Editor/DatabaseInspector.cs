using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Database.ObjectDatabase))]
public class DatabaseInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var database = (Database.ObjectDatabase) target;
        if (GUILayout.Button("Regenerate Database"))
        {
            database.Regenerate();
        }
    }
}
