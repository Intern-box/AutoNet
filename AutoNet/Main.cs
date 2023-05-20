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

        public Main() { InitializeComponent(); }

        private void Main_Load(object sender, EventArgs e)
        {
            // Читаю список адаптеров в системе
            adapters = NetworkInterface.GetAllNetworkInterfaces();

            // Заполняю список с адаптерами в программе
            foreach (NetworkInterface adapter in adapters) { AdaptersList.Items.Add(adapter.Name); }

            // Заполняю списоки с кассами
            for (int i = 1; i < 21; i++) { WorkstationsList.Items.Add(i); }

            for (int i = 1; i < 21; i++) { Workstation.Items.Add(i); }
        }

        private void AdaptersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Errors.Items.Clear(); NowGW.Text = string.Empty;

            WorkstationsList.Enabled = NowIP.Enabled = NowMask.Enabled = NowGW.Enabled = true;

            WillBeIP.Text = WillBeMask.Text = WillBeGW.Text = WorkstationsList.Text = string.Empty;

            // Читаю параметры выбранного адаптера
            IPInterfaceProperties addresses = adapters[AdaptersList.Items.IndexOf(AdaptersList.Text)].GetIPProperties();

            // Начинаю заполнять поля вывода информации...
            NowIP.Items.Clear(); NowMask.Items.Clear(); NowGW.Items.Clear();

            for (int i = 0; i < addresses.UnicastAddresses.Count; i++)
            {
                if (addresses.UnicastAddresses[i].Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    // Вывожу в поле IP
                    NowIP.Items.Add(addresses.UnicastAddresses[i].Address.ToString());

                    // Вывожу в поле маску сети
                    NowMask.Items.Add(addresses.UnicastAddresses[i].IPv4Mask.ToString());
                }
            }

            // Вывожу в поле шлюз
            if (addresses.GatewayAddresses.Count > 0) { NowGW.Items.Add(addresses.GatewayAddresses[0].Address.ToString()); }

            // Заполняю поля вывода первыми элементами
            if (NowIP.Items.Count > 0) { NowIP.SelectedIndex = 0; }

            if (NowMask.Items.Count > 0) { NowMask.SelectedIndex = 0; }

            if (NowGW.Items.Count > 0) { NowGW.SelectedIndex = 0; NowGW.Enabled = true; } else { NowGW.Enabled = false; }

            // Если IP НЕ из подсети 192.168.133.0/24, - вывожу сообщение о нестандартных настройках
            if (NowIP.Text.Substring(0, NowIP.Text.LastIndexOf('.') + 1) != "192.168.133.")
            {
                Errors.Items.Add("Обнаружены нестандартные сетевые настройки!");

                // Если IP из диапазона Automatic Private IP Addressing (APIPA), - вывожу сообщение об этом
                if (NowIP.Text.Substring(0, NowIP.Text.IndexOf('.')) == "169")
                {
                    Errors.Items.Clear(); Errors.Items.Add("IP из диапазона Automatic Private IP Addressing (APIPA)!");
                }

                // Если IP из диапазона 127.0.0.0/8, - вывожу сообщение об этом
                if (NowIP.Text.Substring(0, NowIP.Text.IndexOf('.')) == "127")
                {
                    Errors.Items.Clear(); Errors.Items.Add("Адрес локального компьютера!");
                }
            }
        }

        private void WorkstationsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WillBeIP.Enabled = WillBeMask.Enabled = WillBeGW.Enabled = CheckIP.Enabled = ApplyButton.Enabled = true;

            Workstation.Enabled = PingIP.Enabled = PingHostname.Enabled = true;

            // Заполняю поля с новыми настройками
            if (WorkstationsList.Text == "1") { WillBeIP.Text = NowIP.Text.Substring(0, NowIP.Text.LastIndexOf('.') + 1) + "1"; }

            else if (WorkstationsList.Text == "2") { WillBeIP.Text = NowIP.Text.Substring(0, NowIP.Text.LastIndexOf('.') + 1) + "2"; }

            else if (WorkstationsList.Text.Length < 2) { WillBeIP.Text = NowIP.Text.Substring(0, NowIP.Text.LastIndexOf('.') + 1) + "20" + WorkstationsList.Text; }

            else { WillBeIP.Text = NowIP.Text.Substring(0, NowIP.Text.LastIndexOf('.') + 1) + "2" + WorkstationsList.Text; }

            WillBeMask.Text = NowMask.Text;

            if (NowGW.Text != string.Empty) { WillBeGW.Text = NowGW.Text; WillBeGW.Enabled = true; } else { WillBeGW.Enabled = false; }
        }

        // Пинг ЛЮБОГО IP
        private void PingIP_Click(object sender, EventArgs e) { if (WorkstationIP.Text != string.Empty) { ChkIP(WorkstationIP.Text); } }

        // Пинг кассы по имени
        private void PingHostname_Click(object sender, EventArgs e)
        {
            if (Workstation.Text != string.Empty)
            {
                Errors.Items.Clear();

                string secondPC = null;

                try { secondPC = Dns.GetHostEntry($"kassa{Workstation.Text}").AddressList[0].ToString(); }

                catch (Exception) { Errors.Items.Add($"Касса {Workstation.Text} НЕ найдена!"); }

                finally { if (secondPC != null) { Errors.Items.Add($"IP кассы {Workstation.Text}: {secondPC}"); } }
            }
        }

        // Уравниваю значения полей IP-сейчас и IP для пинга кассы
        private void EquIP_Click(object sender, EventArgs e) { WorkstationIP.Text = NowIP.Text; }

        // Проверка пингом нового IP
        private void CheckIP_Click(object sender, EventArgs e) { if (WillBeIP.Text != string.Empty) { ChkIP(WillBeIP.Text); } }

        // Метод для пинга
        private bool ChkIP(string ip)
        {
            Errors.Items.Clear();

            bool match = false;

            if (new Ping().Send(ip) != null)
            {
                for (int i = 0; i < 4; i++) { if (new Ping().Send(ip).Status == IPStatus.TimedOut) { match = true; } }
            }

            if (match) { Errors.Items.Add($"Адрес {ip} НЕ отвечает!"); return true; }

            else { Errors.Items.Add($"Адрес {ip} ДОСТУПЕН!"); return false; }
        }

        // Применяю новые настройки
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            // Если новый IP не пингуется, - вывожу запрос на изменение настроек
            if (WillBeIP.Text != string.Empty)
            {
                if (ChkIP(WillBeIP.Text))
                {
                    DialogResult result = MessageBox.Show("Данное действие перезапишет сетевые настройки ПК! Продолжить?", "Перезапись настроек", MessageBoxButtons.YesNo);

                    // При положительном ответе применяю настройки
                    if (result == DialogResult.Yes)
                    {
                        string newIP = WillBeIP.Text;

                        string mask = WillBeMask.Text;

                        string gw = WillBeGW.Text;

                        Process cmdProcess = Process.Start("netsh.exe", $"interface ip set address \"{AdaptersList.Text}\" static {newIP} {mask} {gw}");

                        cmdProcess = Process.Start("netsh.exe", $"interface ip delete dnsservers \"{AdaptersList.Text}\" all");

                        cmdProcess = Process.Start("netsh.exe", $"interface ip add dnsservers validate=no \"{AdaptersList.Text}\" 10.0.0.203");

                        cmdProcess = Process.Start("netsh.exe", $"interface ip add dnsservers validate=no \"{AdaptersList.Text}\" 10.0.0.201 index=2");

                        cmdProcess = Process.Start("netsh.exe", $"interface ip add dnsservers validate=no \"{AdaptersList.Text}\" {gw} index=3");

                        cmdProcess.Dispose();
                    }
                }
            }
        }
    }
}