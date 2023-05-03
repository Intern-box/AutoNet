using System;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutoNet
{
    public partial class Main : Form
    {
        NetworkInterface[] adapters;

        string ip;

        public Main() { InitializeComponent(); }

        private void Main_Load(object sender, EventArgs e)
        {
            adapters = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in adapters) { CAdapters.Items.Add(adapter.Name); }

            for (int i = 1; i < 21; i++) { CWorkstation.Items.Add(i); }
        }

        private void CAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPInterfaceProperties addresses = adapters[CAdapters.Items.IndexOf(CAdapters.Text)].GetIPProperties();

            TOutput.Text = "Сейчас:\r\n";

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
            if (CWorkstation.Text == "1") { ip = "192.168.133.1"; }

            else if (CWorkstation.Text == "2") { ip = "192.168.133.2"; }

            else if (CWorkstation.Text.Length > 1) { ip = "192.168.133.2" + CWorkstation.Text; }

            else { ip = "192.168.133.20" + CWorkstation.Text; }

            TOutput.Text = string.Empty;

            CAdapters_SelectedIndexChanged(sender, e);

            TOutput.Text +=
                
                $"\r\nСтанет:\r\n" +
                $"IP:   {ip}\r\n" +
                $"MASK: 255.255.255.0\r\n" +
                $"GW:   192.168.133.10\r\n";

            if (CAdapters.Text != string.Empty && CWorkstation.Text != string.Empty) { ApplyButton.Enabled = true; } else { ApplyButton.Enabled = false; }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Process cmdProcess = Process.Start("netsh.exe", $"interface ip set address \"{CAdapters.Text}\" static {ip} 255.255.255.0 192.168.133.10");

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