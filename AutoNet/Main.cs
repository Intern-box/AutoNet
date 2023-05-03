using System;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutoNet
{
    public partial class Main : Form
    {
        NetworkInterface[] adapters;

        string oldIP;

        string newIP;

        string gw = "192.168.133.10";

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

                    oldIP = addresses.UnicastAddresses[i].Address.ToString();

                    TOutput.Text += $"MASK: {addresses.UnicastAddresses[i].IPv4Mask}\r\n";
                }
            }

            if (addresses.GatewayAddresses.Count > 0) { TOutput.Text += $"GW:   {addresses.GatewayAddresses[0].Address}\r\n"; }

            if (CAdapters.Text != string.Empty && CWorkstation.Text != string.Empty) { ApplyButton.Enabled = true; } else { ApplyButton.Enabled = false; }
        }

        private void CWorkstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CWorkstation.Text == "1") { newIP = "192.168.133.1"; }

            else if (CWorkstation.Text == "2") { newIP = "192.168.133.2"; }

            else if (CWorkstation.Text.Length > 1) { newIP = "192.168.133.2" + CWorkstation.Text; }

            else { newIP = "192.168.133.20" + CWorkstation.Text; }

            TOutput.Text = string.Empty;

            CAdapters_SelectedIndexChanged(sender, e);

            oldIP = oldIP.Substring(0, oldIP.LastIndexOf('.') + 1);

            if (oldIP != "192.168.133.")
            {
                MessageBox.Show("Обнаружены нестандартные сетевые настройки!", "ВНИМАНИЕ!!!", MessageBoxButtons.OK);

                newIP = oldIP + "70";

                gw = oldIP + "2";
            }

            TOutput.Text +=
                
                $"\r\nСтанет:\r\n" +
                $"IP:   {newIP}\r\n" +
                $"MASK: 255.255.255.0\r\n" +
                $"GW:   {gw}\r\n";

            if (CAdapters.Text != string.Empty && CWorkstation.Text != string.Empty) { ApplyButton.Enabled = true; } else { ApplyButton.Enabled = false; }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Данное действие перезапишет сетевые настройки ПК! Продолжить?", "Перезаписать сетевые настройки?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Process cmdProcess = Process.Start("netsh.exe", $"interface ip set address \"{CAdapters.Text}\" static {newIP} 255.255.255.0 {gw}");

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
}