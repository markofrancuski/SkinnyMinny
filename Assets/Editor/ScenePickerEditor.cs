using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ScenePickerEditor : EditorWindow
{

    [MenuItem("Window/Custom Windows/Scene Picker")]
    public static void ShowWindow()
    {
        GetWindow<ScenePickerEditor>("Scene Picker");
    }

    private void OnGUI()
    {

        if (GUILayout.Button("SplashScene"))
        {
            //Load Splash Scene
            EditorSceneManager.OpenScene("Assets/Scenes/SplashScene.unity");
        }

        if (GUILayout.Button("Main Menu Scene"))
        {
            //Load Main Menu Scene
            EditorSceneManager.OpenScene("Assets/Scenes/MainMenuScene.unity");
        }

        if (GUILayout.Button("Game Scene"))
        {
            //Load Game Scene
            EditorSceneManager.OpenScene("Assets/Scenes/GameScene.unity");
        }

        if (GUILayout.Button("Option Scene"))
        {
            //Load Splash Scene
            EditorSceneManager.OpenScene("Assets/Scenes/OptionScene.unity");
        }
        if (GUILayout.Button("Skins Scene"))
        {
            //Load Splash Scene
            //EditorSceneManager.OpenScene("Assets/Scenes/Main Menu Scene.unity");
        }
    }

}
