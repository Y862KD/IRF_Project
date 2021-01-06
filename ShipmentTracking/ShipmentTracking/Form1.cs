using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShipmentTracking.Entities;

namespace ShipmentTracking
{
    public partial class Form1 : Form
    {
        List<Forwarder> ShipmentStatus = new List<Forwarder>();
        List<Warehouse> ShipmentPacking = new List<Warehouse>();


        public Form1()
        {
            InitializeComponent();

            //label1.Text = "0";


        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            ShipmentStatus = GetShipmentStatus(textBoxForwarder.Text);
            ShipmentPacking = GetShipmentPacking(textBoxWarehouse.Text);

            for (int z = ShipmentPacking.Count - 1; z >= 0; z--)
            {
                if (ShipmentPacking[z].PickUpDate.ToString() == "0")
                {
                    ShipmentPacking.RemoveAt(z);
                }
            }

            for (int i = ShipmentPacking.Count - 1; i >= 0; i--)
            {
                for (int s = 0; s < ShipmentStatus.Count; s++)
                {
                    if (ShipmentPacking[i].PackageNumber.ToString() == ShipmentStatus[s].PackageNumber.ToString())
                    {
                        if (ShipmentStatus[s].DeliveryStatus == "no")
                        {
                            ShipmentPacking.RemoveAt(i);
                        }
                    }
                }
            }

            dataGridView1.DataSource = ShipmentPacking;
        }

        public List<Warehouse> GetShipmentPacking(string csvpath)
        {
            List<Warehouse> warehouse = new List<Warehouse>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    warehouse.Add(new Warehouse()
                    {
                        CustomerCode = int.Parse(line[0]),
                        OrderNumber = int.Parse(line[1]),
                        PackageNumber = int.Parse(line[2]),
                        PickUpDate = line[3]
                    });
                }
            }
            return warehouse;
        }

        public List<Forwarder> GetShipmentStatus(string csvpath)
        {

            List<Forwarder> forwarder = new List<Forwarder>();
            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    forwarder.Add(new Forwarder()
                    {
                        PackageNumber = int.Parse(line[0]),
                        DeliveryStatus = line[1],
                        DeliveryDate = line[2]
                    });
                }
            }
            return forwarder;
        }

        private void buttonWarehouse_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    textBoxWarehouse.Text = filePath;
                }
            }
        }

        private void buttonForwarder_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    textBoxForwarder.Text = filePath;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxForwarder.Text) && string.IsNullOrEmpty(textBoxWarehouse.Text))
            {
                MessageBox.Show("Hiányzó csv fájl elérés!");
                return;
            }

            timer1.Interval = 2000;
            timer1.Start();
            timer1.Tick += Timer1_Tick;
  
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
