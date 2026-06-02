using System;
using MCPForUnity.Editor.Constants;
using MCPForUnity.Editor.Services;
using UnityEditor;

namespace MCPForUnity.Editor
{
    public static class McpCiBoot
    {
        public static void StartStdioForCi()
        {
            try 
            { 
                EditorPrefs.SetBool(EditorPrefKeys.UseHttpTransport, true);
                EditorConfigurationCache.Instance.SetUseHttpTransport(true);
            }
            catch { /* ignore */ }
        }
    }
}
