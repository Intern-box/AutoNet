using System;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace AutoNet
{
    public partial class Main : Form
    {
        public Main() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in adapters) { CAdapters.Items.Add(adapter.Name); }

            for (int i = 1; i < 21; i++) { CWorkstation.Items.Add(i); }
        }

        private void CAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            IPInterfaceProperties addresses = adapters[CAdapters.Items.IndexOf(CAdapters.Text)].GetIPProperties();

            TOutput.Text = string.Empty;

            for (int i = 0; i < addresses.UnicastAddresses.Count; i++)
            {
                if (i % 2 == 1)
                {
                    TOutput.Text += $"IP:   {addresses.UnicastAddresses[i].Address}\r\n";
                    TOutput.Text += $"MASK: {addresses.UnicastAddresses[i].IPv4Mask}\r\n";
                }
            }

            if (addresses.GatewayAddresses.Count > 0) { TOutput.Text += $"GW:   {addresses.GatewayAddresses[0].Address}\r\n"; }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {

        }
    }
}