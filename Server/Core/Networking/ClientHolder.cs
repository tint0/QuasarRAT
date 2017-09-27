using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace xServer.Core.Networking
{
    public class ClientHolder
    {
        public string ClientId { get; private set; }

        public Client Client { get; set; }

        public bool IsSleeping { get; set; }

        // Info
        public int ImageIndex { get; private set; }

        public IPEndPoint EndPoint { get; private set; }

        public string UserAtPc { get; private set; }

        public string OperatingSystem { get; private set; }

        public DateTime LastConnected { get; private set; }

        public string Tag { get; private set; }

        public string AccountType { get; private set; }

        public string LastConnectedDiff { get
            {
                if (Client != null)
                {
                    return "Connected";
                }
                else
                {
                    var diff = DateTime.UtcNow - LastConnected;
                    int diffInSec = (int)diff.TotalSeconds;
                    int diffInMin = (int)diff.TotalMinutes;
                    int diffInMs = (int)diff.TotalMilliseconds;
                    if (diffInMin != 0)
                    {
                        return diffInMin + "m";
                    }
                    else if (diffInSec != 0)
                    {
                        return diffInSec + "s";
                    }
                    else
                    {
                        return diffInMs + "ms";
                    }
                }
            }
        }

        public int SleepInterval { get; set; }

        public string Status { get
            {
                if (IsSleeping && Client == null) return "Sleeping";
                if (IsSleeping && Client != null) return "Transitioning to Sleep";
                if (!IsSleeping && Client == null) return "Transitioning to Interactive";
                if (!IsSleeping && Client != null) return "Interactive";
                return "";
            }
        }


        public ClientHolder(string id)
        {
            ClientId = id;
            IsSleeping = true;
            SleepInterval = 5000;
        }

        public void AssignNewClient(Client client)
        {
            if (client != null)
            {
                Client = client;
                client.ClientHolder = this;
                ImageIndex = client.Value.ImageIndex;
                EndPoint = client.EndPoint;
                UserAtPc = client.Value.UserAtPc;
                Tag = client.Value.Tag;
                AccountType = client.Value.AccountType;
                OperatingSystem = client.Value.OperatingSystem;
            }
        }

        public void Sleep()
        {
            if (!IsSleeping)
            {
                IsSleeping = true;
            }
            Client = null;
            LastConnected = DateTime.UtcNow;
        }

        public bool Equals(ClientHolder h)
        {
            return this.ClientId == h.ClientId;
        }
    }
}
