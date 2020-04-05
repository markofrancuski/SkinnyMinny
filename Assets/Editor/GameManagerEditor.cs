using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    GameManager script;
    private void OnEnable()
    {
        script = target as GameManager;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Start Game"))
        {
            script.StartGame();
        }

         base.OnInspectorGUI();
    }
}
