using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public static class URPRepairUtility
{
    [MenuItem("Tools/Snacky Dash/Repair URP Cameras")]
    public static void RepairURPCameras()
    {
        int repaired = 0;
        Camera[] cameras = Object.FindObjectsByType<Camera>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (Camera camera in cameras)
        {
            if (camera.GetComponent<UniversalAdditionalCameraData>() != null)
                continue;

            Undo.AddComponent<UniversalAdditionalCameraData>(camera.gameObject);
            repaired++;
        }

        if (repaired > 0)
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());

        Debug.Log($"URP camera repair completed. Added UniversalAdditionalCameraData to {repaired} camera(s).");
    }
}
