using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Client
{
    public partial class Connect : Form
    {
        private string IPAddress;

        public Connect()
        {
            InitializeComponent();
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            btnConnection.Enabled = false;
            var wifiInterface = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(nic => nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && nic.OperationalStatus == OperationalStatus.Up);

            if (wifiInterface != null)
            {
                var ipv4Address = wifiInterface.GetIPProperties().UnicastAddresses
                    .FirstOrDefault(addr => addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.Address;

                if (ipv4Address != null)
                {
                    this.IPAddress = ipv4Address.ToString();
                    lbIP.Text = "YOUR IP ADDRESS IS: " + this.IPAddress;
                    btnConnection.Enabled = true;
                }
                else
                {
                    lbIP.Text = "ERROR MESSAGE";
                }
            }
            else
            {
                lbIP.Text = "Wi-Fi adapter not found.";
            }
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IPAddress))
            {
                MessageBox.Show("No IP address available.");
                return;
            }

            Crud crud = new Crud();
            crud.SetData(tbName.Text, this.IPAddress, 1729);
            new SharedScreen(this.IPAddress, 1729).Show();
        }

        private void Disconnect(object sender, FormClosingEventArgs e)
        {
            //delete from firebase the user details
        }
    }
}
