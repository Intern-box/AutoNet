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

        string oldIP, mask, newIP, secondPC;

        string gw = "192.168.133.10";

        bool matchIP = false;

        public Main() { InitializeComponent(); }

        private void Main_Load(object sender, EventArgs e)
        {
            // Читаю список адаптеров в системе
            adapters = NetworkInterface.GetAllNetworkInterfaces();

            // Заполняю список с адаптерами в программе
            foreach (NetworkInterface adapter in adapters) { CAdapters.Items.Add(adapter.Name); }

            // Заполняю список с кассами
            for (int i = 1; i < 21; i++) { CWorkstation.Items.Add(i); }
        }

        private void CAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            // При выборе строки с адаптером
            // становится активным список касс,
            // чистится поле с кассой,
            // кнопка Применить НЕ активна,
            // "обнуляется" IP кассы 2
            CWorkstation.Enabled = true;  CWorkstation.Text = string.Empty; ApplyButton.Enabled = false; secondPC = null;

            // Читаю параметры выбранного адаптера
            IPInterfaceProperties addresses = adapters[CAdapters.Items.IndexOf(CAdapters.Text)].GetIPProperties();

            // Начинаю заполнять поле вывода информации...
            TOutput.Text = "Сейчас:\r\n";

            for (int i = 0; i < addresses.UnicastAddresses.Count; i++)
            {
                if (addresses.UnicastAddresses[i].Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    // Вывожу в поле IP
                    TOutput.Text += $"IP:   {addresses.UnicastAddresses[i].Address}\r\n";

                    // Сохраняю старый IP
                    oldIP = addresses.UnicastAddresses[i].Address.ToString();

                    // Вывожу в поле маску сети
                    TOutput.Text += $"MASK: {addresses.UnicastAddresses[i].IPv4Mask}\r\n";

                    // Сохраняю маску сети
                    mask = addresses.UnicastAddresses[i].IPv4Mask.ToString();
                }
            }

            if (addresses.GatewayAddresses.Count > 0)
            {
                // Если есть шлюз, вывожу в поле...
                TOutput.Text += $"GW:   {addresses.GatewayAddresses[0].Address}\r\n";

                // и сохраняю
                gw = addresses.GatewayAddresses[0].Address.ToString();
            }

            // Если нет IP, вывожу сообщение об ошибке
            if (oldIP == null) { MessageBox.Show("На ПК не обнаружен IP-адрес!", "ВНИМАНИЕ!!!", MessageBoxButtons.OK); }
        }

        private void CWorkstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Перезаполняю поле вывода информации
            TOutput.Text = $"Сейчас:\r\nIP:   {oldIP}\r\nMASK: {mask}\r\n"; if (gw != null) { TOutput.Text += $"GW:   {gw}\r\n"; }

            // Если IP НЕ из подсети 192.168.133.0/24, - вывожу сообщение о нестандартных настройках
            if (oldIP.Substring(0, oldIP.LastIndexOf('.') + 1) != "192.168.133.")
            {
                MessageBox.Show("Обнаружены нестандартные сетевые настройки!", "ВНИМАНИЕ!!!", MessageBoxButtons.OK);
            }

            // Запрос на поиск кассы 2
            DialogResult result = MessageBox.Show("Пытаемся найти кассу 2?", "Поиск кассы 2", MessageBoxButtons.YesNo);

            // Если ответ утвердительный...
            if (result == DialogResult.Yes)
            {
                // вывожу в поле информацию о поиске и его результаты...
                TOutput.Text += $"\r\nПоиск кассы 2...\r\n";

                // Поиск кассы 2 осуществляется по ИМЕНИ!
                try { secondPC = Dns.GetHostEntry("kassa2").AddressList[0].ToString(); }

                catch (Exception) { TOutput.Text += $"Касса 2 НЕ найдена!\r\n"; }

                finally { if (secondPC != null) { TOutput.Text += $"Касса 2 найдена,\r\nIP: {secondPC}\r\n"; } }
            }

            // Так как выбран номер кассы, заполняю и вывожу значения нового IP, маски, шлюза (если есть)
            if (CWorkstation.Text == "1") { newIP = oldIP.Substring(0, oldIP.LastIndexOf('.') + 1) + "1"; }

            else if (CWorkstation.Text == "2") { newIP = oldIP.Substring(0, oldIP.LastIndexOf('.') + 1) + "2"; }

            else if (CWorkstation.Text.Length < 2) { newIP = $"{oldIP.Substring(0, oldIP.LastIndexOf('.') + 1)}20{CWorkstation.Text}"; }

            else { newIP = $"{oldIP.Substring(0, oldIP.LastIndexOf('.') + 1)}2{CWorkstation.Text}"; }

            TOutput.Text += $"\r\nСтанет:\r\nIP:   {newIP}\r\nMASK: {mask}\r\n";

            TOutput.Text += $"GW:   {gw}";

            // Активация кнопки Применить
            ApplyButton.Enabled = true;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            // Проверка пингом нового IP
            if (new Ping().Send(newIP) != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    // Если адрес пингуется, фиксируется совпадение адреса
                    if (new Ping().Send(newIP).Status != IPStatus.TimedOut) { matchIP = true; }
                }
            }

            if (matchIP)
            {
                // При совпадении адреса вывожу ошибку
                MessageBox.Show("Обнаружено совпадение IP! Выберите другой № кассы!", "ВНИМАНИЕ!!!", MessageBoxButtons.OK);

                matchIP = false;
            }
            else
            {
                // Если новый IP не пингуется, - вывожу запрос на изменение настроек
                DialogResult result = MessageBox.Show("Данное действие перезапишет сетевые настройки ПК! Продолжить?", "Перезапись настроек", MessageBoxButtons.YesNo);

                // При положительном ответе применяю настройки
                if (result == DialogResult.Yes)
                {
                    Process cmdProcess = Process.Start("netsh.exe", $"interface ip set address \"{CAdapters.Text}\" static {newIP} {mask} {gw}");

                    cmdProcess = Process.Start("netsh.exe", $"interface ip delete dnsservers \"{CAdapters.Text}\" all");

                    cmdProcess = Process.Start("netsh.exe", $"interface ip add dnsservers validate=no \"{CAdapters.Text}\" 10.0.0.203");

                    cmdProcess = Process.Start("netsh.exe", $"interface ip add dnsservers validate=no \"{CAdapters.Text}\" 10.0.0.201 index=2");

                    cmdProcess = Process.Start("netsh.exe", $"interface ip add dnsservers validate=no \"{CAdapters.Text}\" {gw} index=3");

                    cmdProcess.Dispose();

                    // После применения новых настроек, - моментальный выход из программы!
                    Application.Exit();
                }
            }
        }
    }
}