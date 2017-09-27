using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xServer.Core.Networking;

namespace xServer.Forms
{
    public partial class FrmManageClients : Form
    {
        public FrmMain FormMain { get; private set; }

        private readonly object _lockLstClientHolders = new object();

        private List<ClientHolder> _clientHolders;
        private readonly object _lockClientHolders = new object();

        private Timer _refreshTimer;

        public FrmManageClients(FrmMain frmMain)
        {
            FormMain = frmMain;

            _clientHolders = new List<ClientHolder>();

            _refreshTimer = new Timer();
            _refreshTimer.Tick += RefreshTimer_Tick;
            _refreshTimer.Interval = 1000;
            _refreshTimer.Start();

            InitializeComponent();
        }

        private void FrmManageClients_Load(object sender, EventArgs e)
        {
            // Client Connected Event -> Holder set client.IsSleeping -> Main UI
            // CLient Disconnected Event -> Both
            FormMain.ListenServer.ClientSleepCheck += OnClientSleepCheck;
            FormMain.ListenServer.ClientDisconnected += OnClientDisconnected;
        }

        private void OnClientSleepCheck(Client client)
        {
            // need to make more unique clientID
            var holder = _clientHolders.FirstOrDefault(h => h != null && h.ClientId == client.Value.Id);
            if (holder == null)
            {
                holder = new ClientHolder(client.Value.Id);
                lock (_lockClientHolders)
                {
                    _clientHolders.Add(holder);
                }
            }
            holder.AssignNewClient(client);

            if (holder.IsSleeping)
            {
                new Core.Packets.ServerPackets.DoSleep(true, holder.SleepInterval).Execute(holder.Client);
                holder.Sleep();
            }
        }

        private void OnClientDisconnected(Client client)
        {
            var holder = _clientHolders.FirstOrDefault(h => h != null && h.EndPoint.Port.Equals(client.EndPoint.Port));
            if (holder != null)
            {
                if (!holder.IsSleeping)
                {
                    lock (_lockClientHolders)
                    {
                        for (int i = _clientHolders.Count - 1; i >= 0 ; i--)
                        {
                            if (_clientHolders[i].EndPoint.Port.Equals(client.EndPoint.Port))
                            {
                                _clientHolders.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            lock (_lockClientHolders)
            {
                lstClientHolders.VirtualListSize = _clientHolders.Count;
                lstClientHolders.Refresh();
            }
        }

        public void LvClientHolders_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            lock (_lockClientHolders)
            {
                if (e.ItemIndex < _clientHolders.Count)
                {
                    ClientHolder holder = _clientHolders[e.ItemIndex];

                    e.Item = new ListViewItem(new string[]
                    {
                    holder.EndPoint.Address.ToString(),
                    holder.UserAtPc,
                    holder.OperatingSystem,
                    holder.Status,
                    holder.LastConnectedDiff,
                    holder.SleepInterval/1000 + "s"
                    });
                }
            }
        }

        private void setModeToSleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ClientHolder c in GetSelectedClients())
            {
                new Core.Packets.ServerPackets.DoSleep(true, c.SleepInterval).Execute(c.Client);
                c.Sleep();
            }
        }

        private void setToInteractiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ClientHolder c in GetSelectedClients())
            {
                c.IsSleeping = false;
            }
        }


        public void AddClientToListView(ClientHolder clientHolder)
        {
            try
            {
                ListViewItem lvi = new ListViewItem(new string[]
                {
                    clientHolder.EndPoint.Address.ToString(), clientHolder.Status
                })
                { Tag = clientHolder };

                lstClientHolders.Invoke((MethodInvoker)delegate
                {
                    lock (_lockLstClientHolders)
                    {
                        lstClientHolders.Items.Add(lvi);
                    }
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        private ClientHolder[] GetSelectedClients()
        {
            List<ClientHolder> clientHolders = new List<ClientHolder>();

            lock (_lockClientHolders)
            {
                if (lstClientHolders.SelectedIndices.Count == 0) return null;
                int[] items = new int[lstClientHolders.SelectedIndices.Count];
                lstClientHolders.SelectedIndices.CopyTo(items, 0);

                foreach (int index in items)
                {
                    clientHolders.Add(_clientHolders[index]);
                }
            }

            return clientHolders.ToArray();
        }

        private void setIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientHolder[] holders = GetSelectedClients();
            FrmManageClientsSetInterval frmSetInterval = new FrmManageClientsSetInterval(holders);
            frmSetInterval.Show();
        }
    }
}
