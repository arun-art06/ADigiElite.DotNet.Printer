using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADigiElite.DotNet.Printer
{
    public class AddressData
    {
        public string GroupId { get; set; }
        public string SubNo { get; set; }
        public string CloseDay { get; set; }
        public string NoOfCopy { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Pincode { get; set; }


        public List<string> AddressString { get; set; }

      

        public AddressData()
        {
            /*
            if (row.IsGROUP_IDNull() == false)
                this.GROUP_ID = row.GROUP_ID;
            if (row.IsSUB_NONull() == false)
                this.SUB_NO = row.SUB_NO;
            if (row.IsCLOSE_DAYNull() == false)
                this.CLOSE_DAY = row.CLOSE_DAY.ToString("MMM-yyyy");
            if (row.IsNO_OF_COPYNull() == false)
                this.NO_OF_COPY = row.NO_OF_COPY.ToString();
            if (row.IsNAMENull() == false)
                this.NAME = row.NAME;
            if (row.IsNAME_2Null() == false)
                this.NAME_2 = row.NAME_2;
            if (row.IsADDRESS1Null() == false)
                this.ADDRESS1 = row.ADDRESS1;
            if (row.IsADDRESS2Null() == false)
                this.ADDRESS2 = row.ADDRESS2;
            if (row.IsCITYNull() == false)
                this.CITY = row.CITY;
            if (row.IsDISTRICTNull() == false)
                this.DISTRICT = row.DISTRICT;
            if (row.IsPINCODENull() == false)
                this.PINCODE = row.PINCODE.ToString();
                */

            BuildAddressString();

        }

        public void BuildAddressString()
        {
            AddressString = new List<string>();
            AddressString.Add(string.Format("{0,-15}{1}", this.GroupId + this.SubNo, string.Format("({0}){1}", this.CloseDay, this.NoOfCopy)));
            //AddressString.Add(string.Format('\x1B' + "(s3B " + "{0,-15}{1} " + '\x1B'+"(s0B", this.GROUP_ID + this.SUB_NO, string.Format("({0}){1}", this.CLOSE_DAY, this.NO_OF_COPY)));
            if (string.IsNullOrWhiteSpace(this.Name) == false)
                AddressString.Add(this.Name);
            if (string.IsNullOrWhiteSpace(this.Name2) == false)
                AddressString.Add(this.Name2);
            if (string.IsNullOrWhiteSpace(this.Address1) == false)
                AddressString.Add(this.Address1);
            if (string.IsNullOrWhiteSpace(this.Address2) == false)
                AddressString.Add(this.Address2);
            if (string.IsNullOrWhiteSpace(this.City) == false)
                AddressString.Add(this.City);
            if (string.IsNullOrWhiteSpace(this.District) == false || string.IsNullOrWhiteSpace(this.Pincode) == false)
            {
                string pincode = this.Pincode;
                if (string.IsNullOrWhiteSpace(pincode) == false)
                    pincode = " - " + pincode;
                AddressString.Add(string.Format("{0}{1}", this.District, pincode));
            }
        }

        public string GetAddressLine(int index)
        {
            string result = "";
            if (AddressString != null)
            {
                if (AddressString.Count > index)
                    return this.AddressString.ElementAt(index);
            }
            return result;
        }
    }



}
