using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelViewerSceneSetup
{
    [MenuItem("Tools/Level Viewer/Create Level Viewer Scene")]
    public static void CreateLevelViewerScene()
    {
        // Create new scene
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

        // Create Camera
        var cameraGO = new GameObject("Main Camera");
        var cam = cameraGO.AddComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = 5;
        cam.backgroundColor = new Color(0.12f, 0.12f, 0.15f);
        cam.clearFlags = CameraClearFlags.SolidColor;
        cameraGO.AddComponent<AudioListener>();
        cameraGO.tag = "MainCamera";

        // Create LevelViewer root
        var viewerGO = new GameObject("LevelViewer");
        viewerGO.AddComponent<LevelViewer.LevelViewerManager>();

        // Create directional light
        var lightGO = new GameObject("Directional Light");
        var light = lightGO.AddComponent<Light>();
        light.type = LightType.Directional;
        lightGO.transform.rotation = Quaternion.Euler(50, -30, 0);

        // Save scene
        string path = "Assets/Scenes/LevelViewerScene.unity";
        EditorSceneManager.SaveScene(scene, path);
        Debug.Log($"[LevelViewer] Scene created at {path}. Press Play to use the Level Viewer!");

        // Select the viewer object
        Selection.activeGameObject = viewerGO;
    }

    [MenuItem("Tools/Level Viewer/Open Level Viewer Scene")]
    public static void OpenLevelViewerScene()
    {
        string path = "Assets/Scenes/LevelViewerScene.unity";
        if (System.IO.File.Exists(path))
        {
            EditorSceneManager.OpenScene(path);
        }
        else
        {
            if (EditorUtility.DisplayDialog("Level Viewer", "Scene not found. Create it?", "Create", "Cancel"))
            {
                CreateLevelViewerScene();
            }
        }
    }
}
