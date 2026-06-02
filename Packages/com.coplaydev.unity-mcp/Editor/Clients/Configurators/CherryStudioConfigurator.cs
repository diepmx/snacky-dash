using System;
using System.Collections.Generic;
using System.IO;
using MCPForUnity.Editor.Constants;
using MCPForUnity.Editor.Models;
using MCPForUnity.Editor.Services;
using UnityEditor;

namespace MCPForUnity.Editor.Clients.Configurators
{
    public class CherryStudioConfigurator : JsonFileMcpConfigurator
    {
        public const string ClientName = "Cherry Studio";

        public CherryStudioConfigurator() : base(new McpClient
        {
            name = ClientName,
            windowsConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Cherry Studio", "config"),
            macConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Library", "Application Support", "Cherry Studio", "config"),
            linuxConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "Cherry Studio", "config")
        })
        { }

        public override bool SupportsAutoConfigure => false;

        public override IList<string> GetInstallationSteps() => new List<string>
        {
            "Open Cherry Studio",
            "Go to Settings (⚙️) → MCP Server",
            "Click 'Add Server' button",
            "For HTTP mode:",
            "  - Name: unity-mcp",
            "  - Type: HTTP",
            "  - URL: Copy from the Manual Configuration JSON below",
            "Click Save and restart Cherry Studio",
            "",
            "Note: Cherry Studio uses UI-based configuration.",
            "Use the manual snippet below as reference for the values to enter."
        };

        public override McpStatus CheckStatus(bool attemptAutoRewrite = true)
        {
            client.SetStatus(McpStatus.NotConfigured, "Cherry Studio requires manual UI configuration");
            return client.status;
        }

        public override void Configure()
        {
            throw new InvalidOperationException(
                "Cherry Studio uses UI-based configuration. " +
                "Please use the Manual Configuration snippet and Installation Steps to configure manually."
            );
        }

        public override string GetManualSnippet()
        {
            EditorConfigurationCache.Instance.SetUseHttpTransport(true);
            return base.GetManualSnippet() + "\n\n" +
                   "# Cherry Studio Configuration Instructions:\n" +
                   "# Cherry Studio uses UI-based configuration, not a JSON file.\n" +
                   "# \n" +
                   "# To configure:\n" +
                   "# 1. Open Cherry Studio\n" +
                   "# 2. Go to Settings (⚙️) → MCP Server\n" +
                   "# 3. Click 'Add Server'\n" +
                   "# 4. Enter the following values from the JSON above:\n" +
                   "#    - Name: unity-mcp\n" +
                   "#    - Type: HTTP\n" +
                   "#    - URL: (copy 'url' value from JSON)\n" +
                   "#    - Active: true\n" +
                   "# 5. Click Save\n" +
                   "# 6. Restart Cherry Studio";
        }
    }
}
