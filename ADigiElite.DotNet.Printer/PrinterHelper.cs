using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADigiElite.DotNet.Printer
{
    public class PrinterHelper
    {
        public static DotMatrixPrinter GlobalPrinter { get; set; }

        public  PrinterHelper()
        {
            GlobalPrinter = new DotMatrixPrinter();
            GlobalPrinter.LoadConfig();
        }

        public void Print(List<AddressData> addressData)
        {
            AddressPageManager _AddressPageManager = new AddressPageManager();
            _AddressPageManager.LoadAddressPage(addressData);
            string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            tempPath = tempPath + string.Format("\\ADigiElite.DotNet.Printer\\tmp_print_{0}.txt",DateTime.Now.Ticks.ToString());
            _AddressPageManager.SaveToFile(tempPath);
            GlobalPrinter.PrintFile(tempPath);
        }
    }
}
