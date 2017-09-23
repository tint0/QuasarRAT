using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using xServer.Core.Networking;
using xServer.Core.PortForward.Local.Packets;

namespace xServer.Core.PortForward.Local
{
    public class LocalPortForwardClient
    {
        public const int BUFFER_SIZE = 8192;

        public int ClientId { get
            {
                return _homeSocket.Handle.ToInt32();
            } }
        public string _remoteHost { get; set; }
        public int _remotePort { get; set; }

        private Socket _homeSocket;
        private byte[] _buffer;

        public Client Client { get; private set; }
        //Stats
        public int LengthReceived { get; set; }
        public int LengthSent { get; set; }
        // prevent dup packets
        private bool _isDisconnectSent;

        public LocalPortForwardServer ForwardServer { get; private set; }
        public string ClientSocketInfo { get; private set; }
        

        public LocalPortForwardClient(Client c, LocalPortForwardServer server, Socket sock, string remoteHost, int remotePort)
        {
            this._homeSocket = sock;
            this._remoteHost = remoteHost;
            this._remotePort = remotePort;
            this.Client = c;
            this.ForwardServer = server;

            new LocalPortForwardConnect(ClientId, _remoteHost, _remotePort).Execute(Client);
        }

        public void HandleResponse(LocalPortForwardConnectResponse response)
        {
            if (response.IsConnected)
            {
                ClientSocketInfo = response.SocketInfo;
                _buffer = new byte[BUFFER_SIZE];
                try
                {
                    _homeSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, AsyncReceive, null);
                }
                catch
                {
                    Disconnect();
                    // prevent sending disconnect packet
                    _isDisconnectSent = true;
                }
            }
            else
            {
                Disconnect();
                _isDisconnectSent = true;
            }
        }

        private void AsyncReceive(IAsyncResult ar)
        {
            try
            {
                int received = _homeSocket.EndReceive(ar);
                if (received <= 0)
                {
                    Disconnect();
                    return;
                }
                LengthReceived += received;

                byte[] data = new byte[received];
                Array.Copy(_buffer, data, received);
                new LocalPortForwardData(ClientId, data).Execute(Client);

                LengthSent += data.Length;

                _homeSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, AsyncReceive, null);
            }
            catch
            {
                Disconnect();
            }
        }

        public void SendToHome(byte[] data)
        {
            try
            {
                _homeSocket.Send(data);
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
                _homeSocket.Close();
            }
            catch { }

            if (_isDisconnectSent)
            {
                new LocalPortForwardDisconnect(ClientId);
                _isDisconnectSent = true;
            }

            ForwardServer.RemoveClient(ClientId);
        }

    }
}
