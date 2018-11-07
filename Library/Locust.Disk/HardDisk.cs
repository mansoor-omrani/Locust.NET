using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Disk
{
    // source: https://www.codeproject.com/Articles/6077/How-to-Retrieve-the-REAL-Hard-Drive-Serial-Number

    public static class HardDisk
    {
        private static List<HardDrive> hdCollection = new List<HardDrive>();
        private static void GetDrives()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                var hd = new HardDrive();
                hd.Name = wmi_HD["Name"].ToString().Trim();
                hd.Model = wmi_HD["Model"].ToString().Trim();
                hd.Type = wmi_HD["InterfaceType"].ToString().Trim();
                hdCollection.Add(hd);
            }

            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            int i = 0;
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hard drive from collection
                // using index
                if (hdCollection.Count <= i)
                    break; 
                HardDrive hd = (HardDrive)hdCollection[i];

                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] == null)
                    hd.SerialNo = "None";
                else
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString().Trim();

                ++i;
            }
        }

        public static List<HardDrive> Drives
        {
            get
            {
                if (hdCollection.Count == 0)
                {
                    GetDrives();
                }

                return hdCollection;
            }
        }
    }
}
