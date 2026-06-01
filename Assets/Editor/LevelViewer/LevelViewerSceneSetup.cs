using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelViewerSceneSetup
{
    [MenuItem("Tools/Level Viewer/Create 3D Level Viewer Scene")]
    public static void Create3DLevelViewerScene()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

        // Camera - top-down orthographic
        var cameraGO = new GameObject("Main Camera");
        var cam = cameraGO.AddComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = 15;
        cam.backgroundColor = new Color(0.32f, 0.62f, 0.24f);
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.nearClipPlane = -50;
        cam.farClipPlane = 100;
        cameraGO.transform.position = new Vector3(8, 20, 10);
        cameraGO.transform.rotation = Quaternion.Euler(90, 0, 0);
        cameraGO.AddComponent<AudioListener>();
        cameraGO.tag = "MainCamera";

        // Level Viewer Manager
        var viewerGO = new GameObject("LevelViewer3D");
        viewerGO.AddComponent<LevelViewer.LevelViewer3DManager>();

        // Directional light for 3D objects
        var lightGO = new GameObject("Directional Light");
        var light = lightGO.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.8f;
        light.color = new Color(1f, 0.96f, 0.9f);
        lightGO.transform.rotation = Quaternion.Euler(50, -30, 0);

        // Ambient light (secondary)
        var fillLightGO = new GameObject("Fill Light");
        var fillLight = fillLightGO.AddComponent<Light>();
        fillLight.type = LightType.Directional;
        fillLight.intensity = 0.6f;
        fillLight.color = new Color(0.8f, 0.85f, 1f);
        fillLightGO.transform.rotation = Quaternion.Euler(30, 150, 0);

        // Save
        string path = "Assets/Scenes/LevelViewer3D.unity";
        EditorSceneManager.SaveScene(scene, path);
        Debug.Log($"[LevelViewer] 3D Scene created at {path}. Press Play to use!");
        Selection.activeGameObject = viewerGO;
    }

    [MenuItem("Tools/Level Viewer/Create 2D Level Viewer Scene")]
    public static void Create2DLevelViewerScene()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

        var cameraGO = new GameObject("Main Camera");
        var cam = cameraGO.AddComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = 5;
        cam.backgroundColor = new Color(0.12f, 0.12f, 0.15f);
        cam.clearFlags = CameraClearFlags.SolidColor;
        cameraGO.AddComponent<AudioListener>();
        cameraGO.tag = "MainCamera";

        var viewerGO = new GameObject("LevelViewer");
        viewerGO.AddComponent<LevelViewer.LevelViewerManager>();

        var lightGO = new GameObject("Directional Light");
        var light = lightGO.AddComponent<Light>();
        light.type = LightType.Directional;
        lightGO.transform.rotation = Quaternion.Euler(50, -30, 0);

        string path = "Assets/Scenes/LevelViewerScene.unity";
        EditorSceneManager.SaveScene(scene, path);
        Debug.Log($"[LevelViewer] 2D Scene created at {path}. Press Play to use!");
        Selection.activeGameObject = viewerGO;
    }

    [MenuItem("Tools/Level Viewer/Open 3D Level Viewer")]
    public static void Open3DScene()
    {
        string path = "Assets/Scenes/LevelViewer3D.unity";
        if (System.IO.File.Exists(path))
            EditorSceneManager.OpenScene(path);
        else if (EditorUtility.DisplayDialog("Level Viewer", "3D Scene not found. Create it?", "Create", "Cancel"))
            Create3DLevelViewerScene();
    }

    [MenuItem("Tools/Level Viewer/Open 2D Level Viewer")]
    public static void Open2DScene()
    {
        string path = "Assets/Scenes/LevelViewerScene.unity";
        if (System.IO.File.Exists(path))
            EditorSceneManager.OpenScene(path);
        else if (EditorUtility.DisplayDialog("Level Viewer", "2D Scene not found. Create it?", "Create", "Cancel"))
            Create2DLevelViewerScene();
    }
}
