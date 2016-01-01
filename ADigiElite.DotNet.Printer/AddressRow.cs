using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADigiElite.DotNet.Printer
{

    public class AddressRow
    {
        public List<AddressData> AddressData { get; set; }

        public string GetAddressString()
        {
            StringBuilder sb = new StringBuilder();
            AddressData left = new AddressData();
            AddressData right = new AddressData();
            if (AddressData != null && AddressData.Count > 0)
                left = AddressData[0];
            if (AddressData != null && AddressData.Count > 1)
                right = AddressData[1];

            string line1 = string.Format(PrinterHelper.GlobalPrinter.BoldStartChar + "{0,-40} {1,-40}" + PrinterHelper.GlobalPrinter.BoldEndChar, left.GetAddressLine(0), right.GetAddressLine(0));
            string line2 = string.Format("{0,-40} {1,-40}", left.GetAddressLine(1), right.GetAddressLine(1));
            string line3 = string.Format("{0,-40} {1,-40}", left.GetAddressLine(2), right.GetAddressLine(2));
            string line4 = string.Format("{0,-40} {1,-40}", left.GetAddressLine(3), right.GetAddressLine(3));
            string line5 = string.Format("{0,-40} {1,-40}", left.GetAddressLine(4), right.GetAddressLine(4));
            string line6 = string.Format("{0,-40} {1,-40}", left.GetAddressLine(5), right.GetAddressLine(5));
            string line7 = string.Format("{0,-40} {1,-40}", left.GetAddressLine(6), right.GetAddressLine(6));
            /*
             string line1 = GetFormattedLine(left.GetAddressLine(0), right.GetAddressLine(0));
             string line2 = GetFormattedLine(left.GetAddressLine(1), right.GetAddressLine(1));
             string line3 = GetFormattedLine(left.GetAddressLine(2), right.GetAddressLine(2));
             string line4 = GetFormattedLine(left.GetAddressLine(3), right.GetAddressLine(3));
             string line5 = GetFormattedLine(left.GetAddressLine(4), right.GetAddressLine(4));
             string line6 = GetFormattedLine(left.GetAddressLine(5), right.GetAddressLine(5));
             string line7 = GetFormattedLine(left.GetAddressLine(6), right.GetAddressLine(6));
                */
            sb.AppendLine(line1);
            sb.AppendLine(line2);
            sb.AppendLine(line3);
            sb.AppendLine(line4);
            sb.AppendLine(line5);
            sb.AppendLine(line6);
            sb.AppendLine(line7);
            return sb.ToString();
        }

        string GetFormattedLine(string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) && string.IsNullOrWhiteSpace(str2))
                return "echo. > LPT1";
            else
                return string.Format("echo {0,-40} {1,-40} > LPT1", str1, str2);
        }
    }

}
