using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using xServer.Core.Networking;

namespace xServer.Core.PortForward.Local
{
    public class LocalPortForwardServer
    {
        public int ServerId { get; }

        public int LocalPort { get; private set; }
        private Socket _listenSocket;

        public string RemoteHost { get; private set; }
        public int RemotePort { get; private set; }

        public List<LocalPortForwardClient> ForwardClients { get; private set; }
        private object _forwardClientsLock = new object();

        private Client _client;

        public bool IsUp { get; private set; }

        public LocalPortForwardServer(Client c, string remoteHost, int remotePort, int localPort)
        {
            ServerId = LocalPortForwardTracker.GetNewId();
            this.LocalPort = localPort;
            this.RemoteHost = remoteHost;
            this.RemotePort = remotePort;
            this._client = c;

            this._listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ForwardClients = new List<LocalPortForwardClient>();
        }

        public void StartServer()
        {
            try
            {
                this._listenSocket.Bind(new IPEndPoint(IPAddress.Any, this.LocalPort));
            }
            catch (SocketException ex)
            { 
                if (ex.ErrorCode == 10048)
                {
                    MessageBox.Show("Port already in use");
                }
                Disconnect();
                return;
            }
            catch
            {
                Disconnect();
                return;
            }
            this._listenSocket.Listen(100);
            this._listenSocket.BeginAccept(AsyncAccept, null);
            IsUp = true;
        }

        private void AsyncAccept(IAsyncResult ar)
        {
            try
            {
                LocalPortForwardClient fwdClient = new LocalPortForwardClient(_client, this, _listenSocket.EndAccept(ar), RemoteHost, RemotePort);
                lock (_forwardClientsLock)
                {
                    ForwardClients.Add(fwdClient);
                }
                this._listenSocket.BeginAccept(AsyncAccept, null);
            }
            catch
            {
                /* Server stopped listening */
            }
        }

        public void Disconnect()
        {
            try
            {
                _listenSocket.Close();
            }
            catch { }

            // Reverse loop for safe disconnect (remove)
            for (int i=ForwardClients.Count-1; i>=0; i--)
            {
                ForwardClients[i].Disconnect();
            }

            lock (_forwardClientsLock)
            {
                ForwardClients.Clear();
            }

            _client.Value.LocalPortForwardTracker.RemoveServer(ServerId);
        }

        public void RemoveClient(int id)
        {
            lock (_forwardClientsLock)
            {
                for (int i = 0; i < ForwardClients.Count; i++)
                {
                    if (ForwardClients[i].ClientId == id)
                    {
                        ForwardClients.RemoveAt(i);
                        break;
                    }
                }
            }
        }

    }
}
