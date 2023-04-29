using System;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutoNet
{
    public partial class Main : Form
    {
        public Main() { InitializeComponent(); }

        private void Main_Load(object sender, EventArgs e)
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
                if (addresses.UnicastAddresses[i].Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    TOutput.Text += $"IP:   {addresses.UnicastAddresses[i].Address}\r\n";

                    TOutput.Text += $"MASK: {addresses.UnicastAddresses[i].IPv4Mask}\r\n";
                }
            }

            if (addresses.GatewayAddresses.Count > 0) { TOutput.Text += $"GW:   {addresses.GatewayAddresses[0].Address}\r\n"; }

            if (CAdapters.Text != string.Empty && CWorkstation.Text != string.Empty) { ApplyButton.Enabled = true; } else { ApplyButton.Enabled = false; }
        }

        private void CWorkstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CAdapters.Text != string.Empty && CWorkstation.Text != string.Empty) { ApplyButton.Enabled = true; } else { ApplyButton.Enabled = false; }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Process cmdProcess = Process.Start("netsh.exe", $"interface ip set address \"{CAdapters.Text}\" static 192.168.133.203 255.255.255.0 192.168.133.10");

            cmdProcess = Process.Start("netsh.exe", $"interface ip delete dnsservers \"{CAdapters.Text}\" all");

            cmdProcess = Process.Start("netsh.exe", $"interface ip add dnsservers validate=no \"{CAdapters.Text}\" 10.0.0.203");

            cmdProcess = Process.Start("netsh.exe", $"interface ip add dnsservers validate=no \"{CAdapters.Text}\" 10.0.0.201  index=2");

            cmdProcess = Process.Start("netsh.exe", $"interface ip add dnsservers validate=no \"{CAdapters.Text}\" 192.168.133.10  index=3");

            cmdProcess.Dispose();

            CAdapters.SelectedItem = CAdapters.Text;

            CAdapters_SelectedIndexChanged(sender, e);
        }
    }
}