using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.Connectivity.SmartCards
{
    public class smartCard
    {
        private int retCode;
        private int hCard;
        private IntPtr hContext;
        private int Protocol;
        public bool connActive = false;
        private string readername = "ACS ACR122 0";
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        public SCARD_READERSTATE RdrState;
        public SCARD_IO_REQUEST pioSendRequest;
        public int blockSize = 4; // max byte length of block
        public string errorMessage = "";
        private string readedString = "";
        private string cardUID = "";

        public string getCardUIDString()
        {
            return cardUID;
        }

        public string getReadedString()
        {
            return readedString;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SCARD_IO_REQUEST
        {
            public int dwProtocol;
            public int cbPciLength;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct APDURec
        {
            public byte bCLA;
            public byte bINS;
            public byte bP1;
            public byte bP2;
            public byte bP3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] Data;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SW;
            public bool IsSend;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SCARD_READERSTATE
        {
            public string RdrName;
            public int UserData;
            public int RdrCurrState;
            public int RdrEventState;
            public int ATRLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 37)]
            public byte[] ATRValue;
        }

        public const int SCARD_S_SUCCESS = 0;
        public const int SCARD_ATR_LENGTH = 33;
        public const int CT_MCU = 0x0;
        public const int CT_IIC_Auto = 0x1;
        public const int CT_IIC_1K = 0x2;
        public const int CT_IIC_2K = 0x3;
        public const int CT_IIC_4K = 0x4;
        public const int CT_IIC_8K = 0x5;
        public const int CT_IIC_16K = 0x6;
        public const int CT_IIC_32K = 0x7;
        public const int CT_IIC_64K = 0x8;
        public const int CT_IIC_128K = 0x9;
        public const int CT_IIC_256K = 0xA;
        public const int CT_IIC_512K = 0xB;
        public const int CT_IIC_1024K = 0xC;
        public const int CT_AT88SC153 = 0xD;
        public const int CT_AT88SC1608 = 0xE;
        public const int CT_SLE4418 = 0xF;
        public const int CT_SLE4428 = 0x10;
        public const int CT_SLE4432 = 0x11;
        public const int CT_SLE4442 = 0x12;
        public const int CT_SLE4406 = 0x13;
        public const int CT_SLE4436 = 0x14;
        public const int CT_SLE5536 = 0x15;
        public const int CT_MCUT0 = 0x16;
        public const int CT_MCUT1 = 0x17;
        public const int CT_MCU_Auto = 0x18;
        public const int SCARD_SCOPE_USER = 0;
        public const int SCARD_SCOPE_TERMINAL = 1;
        public const int SCARD_SCOPE_SYSTEM = 2;
        public const int SCARD_STATE_UNAWARE = 0x0;
        public const int SCARD_STATE_IGNORE = 0x1;
        public const int SCARD_STATE_CHANGED = 0x2;
        public const int SCARD_STATE_UNKNOWN = 0x4;
        public const int SCARD_STATE_UNAVAILABLE = 0x8;
        public const int SCARD_STATE_EMPTY = 0x10;
        public const int SCARD_STATE_PRESENT = 0x20;
        public const int SCARD_STATE_ATRMATCH = 0x40;
        public const int SCARD_STATE_EXCLUSIVE = 0x80;
        public const int SCARD_STATE_INUSE = 0x100;
        public const int SCARD_STATE_MUTE = 0x200;
        public const int SCARD_STATE_UNPOWERED = 0x400;
        public const int SCARD_SHARE_EXCLUSIVE = 1;
        public const int SCARD_SHARE_SHARED = 2;
        public const int SCARD_SHARE_DIRECT = 3;
        public const int SCARD_LEAVE_CARD = 0;
        public const int SCARD_RESET_CARD = 1;
        public const int SCARD_UNPOWER_CARD = 2;
        public const int SCARD_EJECT_CARD = 3;
        public const long FILE_DEVICE_SMARTCARD = 0x310000;
        public const long IOCTL_SMARTCARD_DIRECT = FILE_DEVICE_SMARTCARD + 2050 * 4;
        public const long IOCTL_SMARTCARD_SELECT_SLOT = FILE_DEVICE_SMARTCARD + 2051 * 4;
        public const long IOCTL_SMARTCARD_DRAW_LCDBMP = FILE_DEVICE_SMARTCARD + 2052 * 4;
        public const long IOCTL_SMARTCARD_DISPLAY_LCD = FILE_DEVICE_SMARTCARD + 2053 * 4;
        public const long IOCTL_SMARTCARD_CLR_LCD = FILE_DEVICE_SMARTCARD + 2054 * 4;
        public const long IOCTL_SMARTCARD_READ_KEYPAD = FILE_DEVICE_SMARTCARD + 2055 * 4;
        public const long IOCTL_SMARTCARD_READ_RTC = FILE_DEVICE_SMARTCARD + 2057 * 4;
        public const long IOCTL_SMARTCARD_SET_RTC = FILE_DEVICE_SMARTCARD + 2058 * 4;
        public const long IOCTL_SMARTCARD_SET_OPTION = FILE_DEVICE_SMARTCARD + 2059 * 4;
        public const long IOCTL_SMARTCARD_SET_LED = FILE_DEVICE_SMARTCARD + 2060 * 4;
        public const long IOCTL_SMARTCARD_LOAD_KEY = FILE_DEVICE_SMARTCARD + 2062 * 4;
        public const long IOCTL_SMARTCARD_READ_EEPROM = FILE_DEVICE_SMARTCARD + 2065 * 4;
        public const long IOCTL_SMARTCARD_WRITE_EEPROM = FILE_DEVICE_SMARTCARD + 2066 * 4;
        public const long IOCTL_SMARTCARD_GET_VERSION = FILE_DEVICE_SMARTCARD + 2067 * 4;
        public const long IOCTL_SMARTCARD_GET_READER_INFO = FILE_DEVICE_SMARTCARD + 2051 * 4;
        public const long IOCTL_SMARTCARD_SET_CARD_TYPE = FILE_DEVICE_SMARTCARD + 2060 * 4;
        public const long IOCTL_SMARTCARD_ACR128_ESCAPE_COMMAND = FILE_DEVICE_SMARTCARD + 2079 * 4;
        public const int SCARD_F_INTERNAL_ERROR = -2146435071;
        public const int SCARD_E_CANCELLED = -2146435070;
        public const int SCARD_E_INVALID_HANDLE = -2146435069;
        public const int SCARD_E_INVALID_PARAMETER = -2146435068;
        public const int SCARD_E_INVALID_TARGET = -2146435067;
        public const int SCARD_E_NO_MEMORY = -2146435066;
        public const int SCARD_F_WAITED_TOO_LONG = -2146435065;
        public const int SCARD_E_INSUFFICIENT_BUFFER = -2146435064;
        public const int SCARD_E_UNKNOWN_READER = -2146435063;
        public const int SCARD_E_TIMEOUT = -2146435062;
        public const int SCARD_E_SHARING_VIOLATION = -2146435061;
        public const int SCARD_E_NO_SMARTCARD = -2146435060;
        public const int SCARD_E_UNKNOWN_CARD = -2146435059;
        public const int SCARD_E_CANT_DISPOSE = -2146435058;
        public const int SCARD_E_PROTO_MISMATCH = -2146435057;
        public const int SCARD_E_NOT_READY = -2146435056;
        public const int SCARD_E_INVALID_VALUE = -2146435055;
        public const int SCARD_E_SYSTEM_CANCELLED = -2146435054;
        public const int SCARD_F_COMM_ERROR = -2146435053;
        public const int SCARD_F_UNKNOWN_ERROR = -2146435052;
        public const int SCARD_E_INVALID_ATR = -2146435051;
        public const int SCARD_E_NOT_TRANSACTED = -2146435050;
        public const int SCARD_E_READER_UNAVAILABLE = -2146435049;
        public const int SCARD_P_SHUTDOWN = -2146435048;
        public const int SCARD_E_PCI_TOO_SMALL = -2146435047;
        public const int SCARD_E_READER_UNSUPPORTED = -2146435046;
        public const int SCARD_E_DUPLICATE_READER = -2146435045;
        public const int SCARD_E_CARD_UNSUPPORTED = -2146435044;
        public const int SCARD_E_NO_SERVICE = -2146435043;
        public const int SCARD_E_SERVICE_STOPPED = -2146435042;
        public const int SCARD_W_UNSUPPORTED_CARD = -2146435041;
        public const int SCARD_W_UNRESPONSIVE_CARD = -2146435040;
        public const int SCARD_W_UNPOWERED_CARD = -2146435039;
        public const int SCARD_W_RESET_CARD = -2146435038;
        public const int SCARD_W_REMOVED_CARD = -2146435037;
        public const int SCARD_PROTOCOL_UNDEFINED = 0x0;
        public const int SCARD_PROTOCOL_T0 = 0x1;
        public const int SCARD_PROTOCOL_T1 = 0x2;
        public const int SCARD_PROTOCOL_RAW = 0x10000;
        public const int SCARD_UNKNOWN = 0;
        public const int SCARD_ABSENT = 1;
        public const int SCARD_PRESENT = 2;
        public const int SCARD_SWALLOWED = 3;
        public const int SCARD_POWERED = 4;
        public const int SCARD_NEGOTIABLE = 5;
        public const int SCARD_SPECIFIC = 6;

        [DllImport("winscard.dll")]
        public static extern int SCardEstablishContext(int dwScope, int pvReserved1, int pvReserved2, ref int phContext);
        [DllImport("winscard.dll")]
        public static extern int SCardReleaseContext(int phContext);
        [DllImport("winscard.dll")]
        public static extern int SCardConnect(int hContext, string szReaderName, int dwShareMode, int dwPrefProtocol, ref int phCard, ref int ActiveProtocol);
        [DllImport("winscard.dll")]
        public static extern int SCardBeginTransaction(int hCard);
        [DllImport("winscard.dll")]
        public static extern int SCardDisconnect(int hCard, int Disposition);
        [DllImport("winscard.dll")]
        public static extern int SCardListReaderGroups(int hContext, ref string mzGroups, ref int pcchGroups);
        [DllImport("winscard.DLL", EntryPoint = "SCardListReadersA", CharSet = CharSet.Ansi)]
        public static extern int SCardListReaders(int hContext, byte[] Groups, byte[] Readers, ref int pcchReaders);
        [DllImport("winscard.dll")]
        public static extern int SCardStatus(int hCard, string szReaderName, ref int pcchReaderLen, ref int stateCore, ref int Protocol, ref byte ATR, ref int ATRLen);
        [DllImport("winscard.dll")]
        public static extern int SCardEndTransaction(int hCard, int Disposition);
        [DllImport("winscard.dll")]
        public static extern int SCardState(int hCard, ref uint stateCore, ref uint Protocol, ref byte ATR, ref uint ATRLen);
        [DllImport("WinScard.dll")]
        public static extern int SCardTransmit(IntPtr hCard, ref SCARD_IO_REQUEST pioSendPci, ref byte[] pbSendBuffer, int cbSendLength, ref SCARD_IO_REQUEST pioRecvPci, ref byte[] pbRecvBuffer, ref int pcbRecvLength);
        [DllImport("winscard.dll")]
        public static extern int SCardTransmit(int hCard, ref SCARD_IO_REQUEST pioSendRequest, ref byte SendBuff, int SendBuffLen, ref SCARD_IO_REQUEST pioRecvRequest, ref byte RecvBuff, ref int RecvBuffLen);
        [DllImport("winscard.dll")]
        public static extern int SCardTransmit(int hCard, ref SCARD_IO_REQUEST pioSendRequest, ref byte[] SendBuff, int SendBuffLen, ref SCARD_IO_REQUEST pioRecvRequest, ref byte[] RecvBuff, ref int RecvBuffLen);
        [DllImport("winscard.dll")]
        public static extern int SCardControl(int hCard, uint dwControlCode, ref byte SendBuff, int SendBuffLen, ref byte RecvBuff, int RecvBuffLen, ref int pcbBytesReturned);
        [DllImport("winscard.dll")]
        public static extern int SCardGetStatusChange(int hContext, int TimeOut, ref SCARD_READERSTATE ReaderState, int ReaderCount);

        public static string GetScardErrMsg(int ReturnCode)
        {
            switch (ReturnCode)
            {
                case SCARD_E_CANCELLED:
                    {
                        return "The action was canceled by an SCardCancel request.";
                    }

                case SCARD_E_CANT_DISPOSE:
                    {
                        return "The system could not dispose of the media in the requested manner.";
                    }

                case SCARD_E_CARD_UNSUPPORTED:
                    {
                        return "The smart card does not meet minimal requirements for support.";
                    }

                case SCARD_E_DUPLICATE_READER:
                    {
                        return "The reader driver didn't produce a unique reader name.";
                    }

                case SCARD_E_INSUFFICIENT_BUFFER:
                    {
                        return "The data buffer for returned data is too small for the returned data.";
                    }

                case SCARD_E_INVALID_ATR:
                    {
                        return "An ATR string obtained from the registry is not a valid ATR string.";
                    }

                case SCARD_E_INVALID_HANDLE:
                    {
                        return "The supplied handle was invalid.";
                    }

                case SCARD_E_INVALID_PARAMETER:
                    {
                        return "One or more of the supplied parameters could not be properly interpreted.";
                    }

                case SCARD_E_INVALID_TARGET:
                    {
                        return "Registry startup information is missing or invalid.";
                    }

                case SCARD_E_INVALID_VALUE:
                    {
                        return "One or more of the supplied parameter values could not be properly interpreted.";
                    }

                case SCARD_E_NOT_READY:
                    {
                        return "The reader or card is not ready to accept commands.";
                    }

                case SCARD_E_NOT_TRANSACTED:
                    {
                        return "An attempt was made to end a non-existent transaction.";
                    }

                case SCARD_E_NO_MEMORY:
                    {
                        return "Not enough memory available to complete this command.";
                    }

                case SCARD_E_NO_SERVICE:
                    {
                        return "The smart card resource manager is not running.";
                    }

                case SCARD_E_NO_SMARTCARD:
                    {
                        return "The operation requires a smart card, but no smart card is currently in the device.";
                    }

                case SCARD_E_PCI_TOO_SMALL:
                    {
                        return "The PCI receive buffer was too small.";
                    }

                case SCARD_E_PROTO_MISMATCH:
                    {
                        return "The requested protocols are incompatible with the protocol currently in use with the card.";
                    }

                case SCARD_E_READER_UNAVAILABLE:
                    {
                        return "The specified reader is not currently available for use.";
                    }

                case SCARD_E_READER_UNSUPPORTED:
                    {
                        return "The reader driver does not meet minimal requirements for support.";
                    }

                case SCARD_E_SERVICE_STOPPED:
                    {
                        return "The smart card resource manager has shut down.";
                    }

                case SCARD_E_SHARING_VIOLATION:
                    {
                        return "The smart card cannot be accessed because of other outstanding connections.";
                    }

                case SCARD_E_SYSTEM_CANCELLED:
                    {
                        return "The action was canceled by the system, presumably to log off or shut down.";
                    }

                case SCARD_E_TIMEOUT:
                    {
                        return "The user-specified timeout value has expired.";
                    }

                case SCARD_E_UNKNOWN_CARD:
                    {
                        return "The specified smart card name is not recognized.";
                    }

                case SCARD_E_UNKNOWN_READER:
                    {
                        return "The specified reader name is not recognized.";
                    }

                case SCARD_F_COMM_ERROR:
                    {
                        return "An internal communications error has been detected.";
                    }

                case SCARD_F_INTERNAL_ERROR:
                    {
                        return "An internal consistency check failed.";
                    }

                case SCARD_F_UNKNOWN_ERROR:
                    {
                        return "An internal error has been detected, but the source is unknown.";
                    }

                case SCARD_F_WAITED_TOO_LONG:
                    {
                        return "An internal consistency timer has expired.";
                    }

                case SCARD_S_SUCCESS:
                    {
                        return "No error was encountered.";
                    }

                case SCARD_W_REMOVED_CARD:
                    {
                        return "The smart card has been removed, so that further communication is not possible.";
                    }

                case SCARD_W_RESET_CARD:
                    {
                        return "The smart card has been reset, so any shared stateCore information is invalid.";
                    }

                case SCARD_W_UNPOWERED_CARD:
                    {
                        return "Power has been removed from the smart card, so that further communication is not possible.";
                    }

                case SCARD_W_UNRESPONSIVE_CARD:
                    {
                        return "The smart card is not responding to a reset.";
                    }

                case SCARD_W_UNSUPPORTED_CARD:
                    {
                        return "The reader cannot communicate with the card, due to ATR string configuration conflicts.";
                    }

                default:
                    {
                        return "unknown error";
                    }
            }
        }

        public object getStatus()
        {
            string szReaderList = "";
            var ATR = default(byte);
            var ATRLen = default(long);
            var stateCore = default(long);
            var Protocol = default(long);
            int localSCardStatus() { int argpcchReaderLen = 255; int argstateCore = Conversions.ToInteger(stateCore); int argProtocol = Conversions.ToInteger(Protocol); int argATRLen = Conversions.ToInteger(ATRLen); var ret = SCardStatus(hCard, szReaderList, ref argpcchReaderLen, ref argstateCore, ref argProtocol, ref ATR, ref argATRLen); return ret; }

            retCode = localSCardStatus();
            switch (stateCore)
            {
                case SCARD_ABSENT:
                    {
                        errorMessage = "No card is currently inserted.";
                        break;
                    }

                case SCARD_PRESENT:
                    {
                        errorMessage = "A card is inserted.";
                        break;
                    }

                case SCARD_SWALLOWED:
                    {
                        errorMessage = "A card is inserted and the reader is swallowed.";
                        break;
                    }

                case SCARD_POWERED:
                    {
                        errorMessage = "The card is powered but the reader.";
                        break;
                    }

                case SCARD_NEGOTIABLE:
                    {
                        errorMessage = "A card is inserted and awaits protocol negotiation.";
                        break;
                    }

                case SCARD_SPECIFIC:
                    {
                        errorMessage = "A card is inserted and a protocol has been selected.";
                        break;
                    }

                default:
                    {
                        errorMessage = stateCore.ToString();
                        break;
                    }
            }

            return true;
        }

        public bool SelectDevice()
        {
            var availableReaders = ListReaders();
            if (!Information.IsNothing(availableReaders) && availableReaders.Count > 0)
            {
                RdrState = new SCARD_READERSTATE();
                readername = availableReaders[0].ToString();
                RdrState.RdrName = readername;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> ListReaders()
        {
            errorMessage = "";
            uint ReaderCount = 0;
            var AvailableReaderList = new List<string>();
            int localSCardListReaders() { int argpcchReaders = Conversions.ToInteger(ReaderCount); var ret = SCardListReaders((int)hContext, null, null, ref argpcchReaders); return ret; }

            retCode = localSCardListReaders();
            if (retCode != SCARD_S_SUCCESS)
            {
                errorMessage = GetScardErrMsg(retCode);
                return AvailableReaderList;
            }

            var ReadersList = new byte[ReaderCount - (long)1 + 1];
            int localSCardListReaders1() { int argpcchReaders = Conversions.ToInteger(ReaderCount); var ret = SCardListReaders((int)hContext, null, ReadersList, ref argpcchReaders); return ret; }

            retCode = localSCardListReaders1();
            if (retCode != SCARD_S_SUCCESS)
            {
                errorMessage = GetScardErrMsg(retCode);
                return AvailableReaderList;
            }

            string rName = "";
            int indx = 0;
            if (ReaderCount > (long)0)
            {
                while (ReadersList[indx] != 0)
                {
                    while (ReadersList[indx] != 0)
                    {
                        rName = rName + (char)ReadersList[indx];
                        indx = indx + 1;
                    }

                    AvailableReaderList.Add(rName);
                    rName = "";
                    indx = indx + 1;
                }
            }

            return AvailableReaderList;
        }

        public int GetAvailableReaders(out List<string> smartCardReaders, out string errMsg)
        {
            var culture = CultureInfo.InvariantCulture;
            try
            {
                int localSCardEstablishContext() { int argphContext = (int)hContext; var ret = SCardEstablishContext(SCARD_SCOPE_USER, (int)IntPtr.Zero, (int)IntPtr.Zero, ref argphContext); return ret; }

                retCode = localSCardEstablishContext();
                if (retCode != SCARD_S_SUCCESS)
                {
                    errMsg = "WinSCard GetPCSCReader: EstablishContext Error: " + retCode.ToString();
                    return retCode;
                }

                byte[] readersList = null;
                uint byteCnt = 0;
                int localSCardListReaders() { int argpcchReaders = Conversions.ToInteger(byteCnt); var ret = SCardListReaders((int)hContext, null, null, ref argpcchReaders); return ret; }

                retCode = localSCardListReaders();
                if (retCode != SCARD_S_SUCCESS)
                {
                    errMsg = "WinSCard GetPCSCReader: ListReaders Error: " + retCode.ToString();
                    return Conversions.ToInteger(false);
                }

                readersList = new byte[byteCnt - (long)1 + 1];
                int localSCardListReaders1() { int argpcchReaders = Conversions.ToInteger(byteCnt); var ret = SCardListReaders((int)hContext, null, readersList, ref argpcchReaders); return ret; }

                retCode = localSCardListReaders1();
                if (retCode != SCARD_S_SUCCESS)
                {
                    errMsg = "WinSCard GetPCSCReader: ListReaders Error: " + retCode.ToString();
                    return Conversions.ToInteger(false);
                }

                int indx = 0;
                string readerName = string.Empty;
                int i = 0;
                while (readersList[indx] != 0)
                {
                    while (readersList[indx] != 0)
                        readerName = readerName + (char)readersList[Math.Min(System.Threading.Interlocked.Increment(ref indx), indx - 1)];
                    smartCardReaders.Add(readerName);
                    i += 1;
                    readerName = "";
                    indx += 1;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return Conversions.ToInteger(false);
            }
            finally
            {
            }

            return Conversions.ToInteger(true);
        }

        public bool establishContext()
        {
            int localSCardEstablishContext() { int argphContext = (int)hContext; var ret = SCardEstablishContext(SCARD_SCOPE_USER, (int)IntPtr.Zero, (int)IntPtr.Zero, ref argphContext); return ret; }

            retCode = localSCardEstablishContext();
            if (retCode != SCARD_S_SUCCESS)
            {
                errorMessage = "Check your device and please restart again";
                connActive = false;
                return false;
            }

            return true;
        }

        public bool connectCard()
        {
            connActive = true;
            retCode = SCardConnect((int)hContext, readername, SCARD_SHARE_SHARED, SCARD_PROTOCOL_T0 | SCARD_PROTOCOL_T1, ref hCard, ref Protocol);
            if (retCode != SCARD_S_SUCCESS)
            {
                errorMessage = GetScardErrMsg(retCode);
                connActive = false;
                return false;
            }

            return true;
        }

        // disconnect card reader connection
        public void Close()
        {
            if (connActive)
            {
                SCardReleaseContext((int)hContext);
                retCode = SCardDisconnect(hCard, SCARD_UNPOWER_CARD);
                ClearBuffers();
            }
        }

        // clear memory buffers
        private void ClearBuffers()
        {
            long indx;
            for (indx = 0; indx <= 262; indx++)
            {
                RecvBuff[Conversions.ToInteger(indx)] = 0;
                SendBuff[Conversions.ToInteger(indx)] = 0;
            }
        }

        public bool readCardUID()
        {
            var receivedUID = new byte[256];
            var request = new SCARD_IO_REQUEST();
            request.dwProtocol = SCARD_PROTOCOL_T1;
            request.cbPciLength = Marshal.SizeOf(typeof(SCARD_IO_REQUEST));
            var sendBytes = new byte[] { 0xFF, 0xCA, 0x0, 0x0, 0x0 };
            int outBytes = receivedUID.Length;
            int status = SCardTransmit(hCard, ref request, ref sendBytes[0], sendBytes.Length, ref request, ref receivedUID[0], ref outBytes);
            if (status != SCARD_S_SUCCESS)
            {
                cardUID = "Error";
                return false;
            }
            else
            {
                receivedUID = RemoveEmptyBytes16DigitsDecimal(receivedUID);
                cardUID = BitConverter.ToString(receivedUID.ToArray()).Replace("-", string.Empty).ToLower();
            }

            return true;
        }

        private byte[] RemoveEmptyBytes16DigitsDecimal(byte[] packet)
        {
            int i = packet.Length - 1;
            while (packet[i] == 0)
                i -= 1;
            var temp = new byte[i]; // for full hex string should be i + 1 - 1 trimmed to 0+6=7 bytes for a number up to 16 digits
            Array.Copy(packet, temp, i); // should be i+1
            return temp;
        }

        // block authentication
        private bool authenticateBlock(string block)
        {
            ClearBuffers();
            SendBuff[0] = 0xFF;                          // CLASS same for all source types, current value:255
            SendBuff[1] = 0x82;                          // INS, current value:
            SendBuff[2] = 0x0;                           // key structure P1, current value:0
            SendBuff[3] = 0x0;                           // key number P2, current value:0
            SendBuff[4] = 0x6;                           // LC, current value:
                                                         // data in 6 bytes
            SendBuff[5] = 0x1;                           // byte 1, version number, current value:1
            SendBuff[6] = 0x0;                           // byte 2, current value:0
            SendBuff[7] = Conversions.ToByte(int.Parse(block));   // byte 3: sector number for stored key input, current value: block
            SendBuff[8] = 0x60;                          // byte 4: Key A for stored key input, current value: 96
            SendBuff[9] = Conversions.ToByte(int.Parse("1"));     // byte 5: session key for non-volatile memory, current value:1  
            SendBuff[10] = 0x0;                          // byte 6: ??
            SendLen = 0xB;                               // 11
            RecvLen = 0x2;                               // 2
            retCode = SendAPDUandDisplay(0);
            if (retCode != SCARD_S_SUCCESS)
            {
                return false;
            }

            return true;
        }

        // send application protocol data unit : communication unit between a smart card reader And a smart card
        private int SendAPDUandDisplay(int reqType)
        {
            int indx;
            string tmpStr = "";
            pioSendRequest.dwProtocol = Aprotocol;
            pioSendRequest.cbPciLength = 8;
            var loopTo = SendLen - 1;
            for (indx = 0; indx <= loopTo; indx++)
                tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuff[indx]);
            retCode = SCardTransmit(hCard, ref pioSendRequest, ref SendBuff[0], SendLen, ref pioSendRequest, ref RecvBuff[0], ref RecvLen);
            if (retCode != SCARD_S_SUCCESS)
            {
                return retCode;
            }
            else
            {
                try
                {
                    tmpStr = "";
                    switch (reqType)
                    {
                        case 0:
                            {
                                var loopTo1 = RecvLen - 1;
                                for (indx = RecvLen - 2; indx <= loopTo1; indx++)
                                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                                if (tmpStr.Trim() != "90 00")
                                {
                                    return -202;
                                }

                                break;
                            }

                        case 1:
                            {
                                var loopTo2 = RecvLen - 1;
                                for (indx = RecvLen - 2; indx <= loopTo2; indx++)
                                    tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[indx]);
                                if (tmpStr.Trim() != "90 00")
                                {
                                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                                }
                                else
                                {
                                    tmpStr = "ATR : ";
                                    var loopTo3 = RecvLen - 3;
                                    for (indx = 0; indx <= loopTo3; indx++)
                                        tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                                }

                                break;
                            }

                        case 2:
                            {
                                var loopTo4 = RecvLen - 1;
                                for (indx = 0; indx <= loopTo4; indx++)
                                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                                break;
                            }
                    }
                }
                catch (IndexOutOfRangeException __unusedIndexOutOfRangeException1__)
                {
                    return -200;
                }
            }

            return retCode;
        }

        public bool SaveStringOnCard(string Text, string Block)
        {
            string str = "";
            int counter = 1;
            string blockPos = Block;
            for (int i = 0, loopTo = Text.Length - 1; i <= loopTo; i++)
            {
                str = str + Text[counter - 1];
                if (counter % blockSize == 0)
                {
                    if (!SaveStringBlockOnCard(str, Conversions.ToInteger(blockPos)))
                    {
                        return false;
                    }

                    blockPos += (double)1;
                    str = "";
                }

                counter += 1;
            }

            return true;
        }

        public bool SaveStringBlockOnCard(string Text, int Block) // Please make sure you do not write data into these Authentication Blocks 0,3,7,11,15.
        {
            string tmpStr = Text;
            int indx;
            if (authenticateBlock(Block.ToString()))
            {
                ClearBuffers();
                SendBuff[0] = 0xFF;                  // CLASS
                SendBuff[1] = 0xD6;                  // INS
                SendBuff[2] = 0x0;                   // P1
                SendBuff[3] = Conversions.ToByte(Block);          // P2: starting block
                SendBuff[4] = Conversions.ToByte(blockSize);      // P3: data length
                var loopTo = tmpStr.Length - 1;
                for (indx = 0; indx <= loopTo; indx++)
                    SendBuff[indx + 5] = Convert.ToByte(tmpStr[indx]);
                SendLen = SendBuff[4] + 5;
                RecvLen = 0x2;
                retCode = SendAPDUandDisplay(2);
                if (retCode != SCARD_S_SUCCESS)
                {
                    errorMessage = "Fail Write";
                    return false;
                }
                else
                {
                    errorMessage = "Write Success";
                    return true;
                }
            }
            else
            {
                errorMessage = "Fail Authentication";
                return false;
            }
        }

        public string readCard(int Block)
        {
            string value = "";
            if (connectCard())
            {
                value = Conversions.ToString(readBlockOnCard(Block));
            }

            value = value.Split(new char[] { Constants.vbNullChar }, 2, StringSplitOptions.None)[0].ToString();
            return value;
        }

        public bool readStringOnCard(int strSize, int startingBlock)
        {
            if (!connectCard())
            {
                errorMessage = "Card readed not connected";
                return false;
            }

            string readedStr = "";
            int numBlocks;
            numBlocks = Conversions.ToInteger(strSize % blockSize == 0 ? Math.Floor(strSize / (double)blockSize) - 1 : Math.Floor(strSize / (double)blockSize));
            for (int i = startingBlock, loopTo = startingBlock + numBlocks; i <= loopTo; i++)
            {
                if (!readBlockOnCard(i))
                {
                    return false;
                }

                readedStr = readedStr + readedString.Split(new char[] { Constants.vbNullChar }, 2, StringSplitOptions.None)[0].ToString().Replace(Conversions.ToString('\u0090'), "");
            }

            readedString = readedStr;
            return true;
        }

        public bool readBlockOnCard(int Block)
        {
            string tmpStr = "";
            int indx;
            if (authenticateBlock(Block.ToString()))
            {
                ClearBuffers();
                SendBuff[0] = 0xFF;
                SendBuff[1] = 0xB0;
                SendBuff[2] = 0x0;
                SendBuff[3] = Conversions.ToByte(Block);
                SendBuff[4] = Conversions.ToByte(blockSize);
                SendLen = 5;
                RecvLen = SendBuff[4] + 2;
                retCode = SendAPDUandDisplay(2);
                if (retCode == -200)
                {
                    readedString = "";
                    errorMessage = "out of range exception";
                    return false;
                }

                if (retCode == -202)
                {
                    readedString = "";
                    errorMessage = "Bytes Not Acceptable";
                    return false;
                }

                if (retCode != SCARD_S_SUCCESS)
                {
                    readedString = "";
                    errorMessage = "Fail Read";
                    return false;
                }

                var loopTo = RecvLen - 1;
                for (indx = 0; indx <= loopTo; indx++)
                    tmpStr += Conversions.ToString(Convert.ToChar(RecvBuff[indx]));
                readedString = tmpStr;
                return true;
            }
            else
            {
                readedString = "";
                errorMessage = "Fail Authentication";
                return false;
            }
        }
    }
}