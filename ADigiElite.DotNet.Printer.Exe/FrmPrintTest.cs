using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADigiElite.DotNet.Printer;

namespace ADigiElite.DotNet.Printer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<AddressData> _data = new List<AddressData>();
            for (int i = 0; i < 10; i++)
            {
                _data.Add(new AddressData()
                {
                    GroupId = "GroupId" + i.ToString(),
                    CloseDay = "CloseDay" + i.ToString(),
                    SubNo = "SubNo" + i.ToString(),
                    NoOfCopy = "NoOfCopy" + i.ToString(),
                    Name = "Name" + i.ToString(),
                    Name2 = "Name2" + i.ToString(),
                    Address1 = "Address1" + i.ToString(),
                    Address2 = "Address2" + i.ToString(),
                    City = "City" + i.ToString(),
                    District = "District" + i.ToString(),
                    Pincode = "GroupId" + i.ToString(),
                });
            }

            PrinterHelper _PrinterHelper = new PrinterHelper();
            _PrinterHelper.Print(_data);
        }
    }
}