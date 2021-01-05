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
        List<CustomerOrders> OpenOrders = new List<CustomerOrders>();
        List<Forwarder> ShipmentStatus = new List<Forwarder>();
        List<Warehouse> ShipmentPacking = new List<Warehouse>();

        //public int ido = 0;

        public Form1()
        {
            InitializeComponent();

            //label1.Text = "0";
            timer1.Interval = 5000;
            timer1.Start();
            timer1.Tick += Timer1_Tick;          
            
           
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //ido++;
            //label1.Text = ido.ToString();

            OpenOrders = GetOpenOrders(@"C:\Temp\sales.csv");
            ShipmentStatus = GetShipmentStatus(@"C:\Temp\forwarder.csv");
            ShipmentPacking = GetShipmentPacking(@"C:\Temp\warehouse.csv");
            //dataGridView1.DataSource = ShipmentStatus;
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
                        OrderNumber = int.Parse(line[0]),
                        PackageNumber = int.Parse(line[1]),
                        PickUpDate = int.Parse(line[2])
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
                        DeliveryDate = int.Parse(line[2])
                    });
                }
            }
            return forwarder;
        }

        public List<CustomerOrders> GetOpenOrders(string csvpath)
        {
            List<CustomerOrders> customerOrders = new List<CustomerOrders>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    customerOrders.Add(new CustomerOrders()
                    {
                        CustomerCode = int.Parse(line[0]),
                        OrderNumber = int.Parse(line[1])
                    });
                }
            }
            return customerOrders;
        }
    }
}
