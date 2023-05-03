using System;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;

namespace AutoNet
{
    public partial class Main : Form
    {
        NetworkInterface[] adapters;

        string oldIP;

        string newIP;

        string gw = "192.168.133.10";

        string secondPC;

        bool trueSettings = true;

        bool matchIP = false;

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

            if (oldIP == null) { MessageBox.Show("На ПК не обнаружен IP-адрес!", "ВНИМАНИЕ!!!", MessageBoxButtons.OK); }

            oldIP = oldIP.Substring(0, oldIP.LastIndexOf('.') + 1);

            if (oldIP != "192.168.133.") { MessageBox.Show("Обнаружены нестандартные сетевые настройки!", "ВНИМАНИЕ!!!", MessageBoxButtons.OK); trueSettings = false; }

            DialogResult result = MessageBox.Show("Пытаемся найти кассу 2?", "Поиск кассы 2?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                TOutput.Text += $"\r\nПоиск кассы 2...\r\n";

                try
                {
                    secondPC = Dns.GetHostByName("kassa2").AddressList[0].ToString();
                }
                catch (Exception)
                {
                    TOutput.Text += $"Касса 2 НЕ найдена!\r\n";
                }
                finally
                {
                    if (secondPC != null) { TOutput.Text += $"Касса 2 найдена, IP: {secondPC}\r\n"; }
                }
            }

            if (CAdapters.Text != string.Empty && CWorkstation.Text != string.Empty) { ApplyButton.Enabled = true; } else { ApplyButton.Enabled = false; }
        }

        private void CWorkstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CWorkstation.Text == "1") { newIP = oldIP + "1"; }

            else if (CWorkstation.Text == "2") { newIP = oldIP + "2"; }

            else if (CWorkstation.Text.Length < 2) { newIP = $"{oldIP}20{CWorkstation.Text}"; }

            else { newIP = $"{oldIP}2{CWorkstation.Text}"; }

            TOutput.Text = string.Empty;

            CAdapters_SelectedIndexChanged(sender, e);

            TOutput.Text +=

                $"\r\nСтанет:\r\n" +
                $"IP:   {newIP}\r\n" +
                $"MASK: 255.255.255.0\r\n";

            if (trueSettings) { TOutput.Text += $"GW:   {gw}"; } else { if (secondPC != null) { gw = secondPC; } }

            if (CAdapters.Text != string.Empty && CWorkstation.Text != string.Empty) { ApplyButton.Enabled = true; } else { ApplyButton.Enabled = false; }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Ping ping = new Ping();
            
            for (int i = 0; i < 4; i++) { if (ping.Send(newIP).Status != IPStatus.TimedOut) { matchIP = true; } }

            if (!matchIP)
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
            else
            {
                MessageBox.Show("Обнаружено совпадение IP! Выберите другой № кассы!", "ВНИМАНИЕ!!!", MessageBoxButtons.OK);

                matchIP = false;
            }
        }
    }
}