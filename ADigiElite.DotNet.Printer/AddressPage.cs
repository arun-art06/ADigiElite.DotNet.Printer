using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADigiElite.DotNet.Printer
{

    public class AddressPage
    {
        public List<AddressRow> AddressRow { get; set; }

        public string GetPageString()
        {
            StringBuilder sb = new StringBuilder();
            if (AddressRow != null && AddressRow.Count > 0)
            {
                for (int i = 0; i < AddressRow.Count; i++)
                {
                    var _addressRow = AddressRow[i];
                    sb.Append(_addressRow.GetAddressString());
                    //page break will be added if its a last line
                    if (i == (AddressRow.Count - 1))
                    {
                        sb.AppendLine("");
                        sb.AppendLine("");
                        sb.Append(PrinterHelper.GlobalPrinter.PageBreakChar);
                        //sb.AppendLine("echo. > LPT1");
                        //sb.AppendLine("echo %char_0C% > LPT1");

                    }
                    else
                    {
                        sb.AppendLine("");
                        sb.AppendLine("");
                        sb.AppendLine("");
                        //sb.AppendLine("echo. > LPT1");
                        //sb.AppendLine("echo. > LPT1");
                    }

                }

            }
            return sb.ToString();
        }
    }


}
