using System.Management;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Security
{
    public class FingerPrint
    {
        private static string fingerPrint = string.Empty;

        public string Value()
        {
            if (string.IsNullOrEmpty(fingerPrint))
            {
                fingerPrint = GetHash("CPU >> " + cpuId() + Constants.vbLf + "BIOS >> " + biosId() + Constants.vbLf + "BASE >> " + baseId());
            }

            return fingerPrint;
        }

        private static string GetHash(string s)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            var enc = new ASCIIEncoding();
            var bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }

        private static string GetHexString(byte[] bt)
        {
            string s = string.Empty;
            for (int i = 0, loopTo = bt.Length - 1; i <= loopTo; i++)
            {
                byte b = bt[i];
                int n, n1, n2;
                n = b;
                n1 = n & 15;
                n2 = Conversions.ToInteger((n >> 4).ToString() + 15);
                if (n2 > 9)
                {
                    s += (n2 - 10 + Strings.Asc("A")).ToString();
                }
                else
                {
                    s += n2.ToString();
                }

                if (n1 > 9)
                {
                    s += (n1 - 10 + Strings.Asc("A")).ToString();
                }
                else
                {
                    s += n1.ToString();
                }

                if (i + 1 != bt.Length && (i + 1) % 2 == 0)
                    s += "-";
            }

            return s;
        }

        private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";
            var mc = new ManagementClass(wmiClass);
            var moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    if (string.IsNullOrEmpty(result))
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return result;
        }

        private static string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            var mc = new ManagementClass(wmiClass);
            var moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (string.IsNullOrEmpty(result))
                {
                    try
                    {
                        if (mo[wmiProperty] is object)
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return result;
        }

        private static string cpuId()
        {
            string retVal = identifier("Win32_Processor", "UniqueId");
            if (string.IsNullOrEmpty(retVal))
            {
                retVal = identifier("Win32_Processor", "ProcessorId");
                if (string.IsNullOrEmpty(retVal))
                {
                    retVal = identifier("Win32_Processor", "Name");
                    if (string.IsNullOrEmpty(retVal))
                    {
                        retVal = identifier("Win32_Processor", "Manufacturer");
                    }

                    retVal += identifier("Win32_Processor", "MaxClockSpeed");
                }
            }

            return retVal;
        }

        private static string biosId()
        {
            return identifier("Win32_BIOS", "Manufacturer") + identifier("Win32_BIOS", "SMBIOSBIOSVersion") + identifier("Win32_BIOS", "IdentificationCode") + identifier("Win32_BIOS", "SerialNumber") + identifier("Win32_BIOS", "ReleaseDate") + identifier("Win32_BIOS", "Version");
        }

        private static string diskId()
        {
            return identifier("Win32_DiskDrive", "Model") + identifier("Win32_DiskDrive", "Manufacturer") + identifier("Win32_DiskDrive", "Signature") + identifier("Win32_DiskDrive", "TotalHeads");
        }

        private static string baseId()
        {
            return identifier("Win32_BaseBoard", "Model") + identifier("Win32_BaseBoard", "Manufacturer") + identifier("Win32_BaseBoard", "Name") + identifier("Win32_BaseBoard", "SerialNumber");
        }

        private static string videoId()
        {
            return identifier("Win32_VideoController", "DriverVersion") + identifier("Win32_VideoController", "Name");
        }

        private static string macId()
        {
            return identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }
    }
}