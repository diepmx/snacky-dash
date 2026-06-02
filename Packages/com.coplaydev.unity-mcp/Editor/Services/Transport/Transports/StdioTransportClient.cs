using System;
using System.Threading.Tasks;
using MCPForUnity.Editor.Helpers;

namespace MCPForUnity.Editor.Services.Transport.Transports
{
    /// <summary>
    /// Adapts the existing TCP bridge into the transport abstraction.
    /// </summary>
    public class StdioTransportClient : IMcpTransportClient
    {
        private TransportState _state = TransportState.Disconnected("stdio");

        public bool IsConnected => StdioBridgeHost.IsRunning;
        public string TransportName => "stdio";
        public TransportState State => _state;

        public Task<bool> StartAsync()
        {
            _state = TransportState.Disconnected("stdio", "Stdio transport is disabled for this project");
            return Task.FromResult(false);
        }

        public Task StopAsync()
        {
            _state = TransportState.Disconnected("stdio");
            return Task.CompletedTask;
        }

        public Task<bool> VerifyAsync()
        {
            _state = TransportState.Disconnected("stdio", "Stdio transport is disabled for this project");
            return Task.FromResult(false);
        }

        public Task ReregisterToolsAsync()
        {
            // In stdio mode, Python re-syncs tools automatically on reconnection
            // after domain reload. No proactive push mechanism exists over TCP.
            return Task.CompletedTask;
        }

    }
}
