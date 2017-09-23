using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xServer.Core.Networking;

namespace xServer.Core.PortForward.Local
{
    public class LocalPortForwardTracker
    {
        private static int _currentServerId = 0;
        public List<LocalPortForwardServer> ForwardServers { get; }
        private object _forwardServersLock = new object();
        private Client _client;


        public LocalPortForwardTracker(Client c)
        {
            ForwardServers = new List<LocalPortForwardServer>();
            this._client = c;
        }

        public static int GetNewId()
        {
            return _currentServerId++;
        }

        public LocalPortForwardServer CreateServer(string remoteHost, int remotePort, int localPort)
        {
            LocalPortForwardServer server = new LocalPortForwardServer(_client, remoteHost, remotePort, localPort);
            lock (_forwardServersLock)
            {
                ForwardServers.Add(server);
            }
           
            return server;
        }

        public LocalPortForwardClient GetClientById(int id)
        {
            lock (_forwardServersLock)
            {
                for (int i = 0; i < ForwardServers.Count; i++)
                {
                    for (int j = 0; j < ForwardServers[i].ForwardClients.Count; j++)
                    {
                        if (ForwardServers[i].ForwardClients[j].ClientId == id)
                        {
                            return ForwardServers[i].ForwardClients[j];
                        }
                    }
                }
            }
            return null;
        }

        public List<LocalPortForwardClient> GetClientsList()
        {
            List<LocalPortForwardClient> clients = new List<LocalPortForwardClient>();
            for (int i = 0; i < ForwardServers.Count; i++)
            {
                clients.AddRange(ForwardServers[i].ForwardClients);
            }
            return clients;
        }

        public void RemoveServer(int id)
        {
            lock (_forwardServersLock)
            {
                for (int i = 0; i < ForwardServers.Count; i++)
                {
                    if (ForwardServers[i].ServerId == id)
                    {
                        ForwardServers.RemoveAt(i);
                        break;
                    }
                }
            }
        }


    }
}
