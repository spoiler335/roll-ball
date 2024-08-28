using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public static class EditorWindowTools
{
    [MenuItem("Sushant/PlayFromInit &X")]
    public static void PlayFromInit()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Init.unity");
        EditorApplication.isPlaying = true;
    }

    [MenuItem("Sushant/Load Init Scene &I")]
    public static void LoadInitScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Init.unity");
    }

    [MenuItem("Sushant/Load GamePlayScene &G")]
    public static void LoadGameplayScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/GamePlay.unity");
    }
}
