using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADigiElite.DotNet.Printer
{
    public class AddressPageManager
    {

        public List<AddressPage> AddressPageList { get; set; }

        public List<AddressPage> LoadAddressPage(List<AddressData> addressData)
        {
            List<AddressPage> result = new List<AddressPage>();
            int i = 0;
            int _page = 0;
            AddressPage _AddressPage = null;
            AddressRow _row = null;
            foreach (AddressData _AddressData in addressData)
            {
                _AddressData.BuildAddressString();
                if ((_page % 12) == 0)
                {
                    _AddressPage = new AddressPage();
                    _AddressPage.AddressRow = new List<AddressRow>();
                    result.Add(_AddressPage);
                }
                if ((i % 2) == 0)
                {
                    _row = new AddressRow();
                    _row.AddressData = new List<AddressData>();
                    _AddressPage.AddressRow.Add(_row);
                }
                _row.AddressData.Add(_AddressData);
                i++;
                _page++;
            }
            AddressPageList = result;
            return result;
        }

        public void SaveToFile(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            string _AllPageString = GetAllPageString();
            sb.AppendLine(PrinterHelper.GlobalPrinter.LineHeightChar + "" + PrinterHelper.GlobalPrinter.FontSizeChar);
            //sb.AppendLine("@echo off");
            //sb.AppendLine("call :hex2Char 0x0C char_0C");
            sb.Append(_AllPageString);
            //sb.AppendLine("exit /b");
            //sb.AppendLine(":hex2Char  hexString  rtnVar");
            //sb.AppendLine("  for /f delims^=^ eol^= %%A in (");
            //sb.AppendLine("    'forfiles /p \"%~dp0.\" /m \"%~nx0\" /c \"cmd /c echo(%~1\"'");
            //sb.AppendLine("  ) do set \"%~2=%%A\"");
            //sb.AppendLine("exit /b");

            FileInfo _fileInfo = new FileInfo(filePath);
            if (Directory.Exists(_fileInfo.Directory.FullName) == false)
                Directory.CreateDirectory(_fileInfo.Directory.FullName);

            using (TextWriter tw = new StreamWriter(filePath))
            {
                tw.Write(sb.ToString());
            }
        }

        public string GetAllPageString()
        {
            StringBuilder sb = new StringBuilder();
            if (AddressPageList != null && AddressPageList.Count > 0)
            {
                foreach (var _addressPage in AddressPageList)
                {
                    sb.Append(_addressPage.GetPageString());
                }
            }
            return sb.ToString();
        }

        /*
        public static string SetLineHeight()
        {
            return '\x1B' + "3" + ((char)35).ToString();

        }

        public static string SetFontSize()
        {
            return '\x1B' + "P";

        }

        public static string SetBoldOn()
        {
            return '\x1B' + "E";
        }

        public static string SetBoldOff()
        {
            return '\x1B' + "F";
        }

        public static string SetPageBreak()
        {
            return "  " + '\x0C' + "";
        }
        */

    }
}
