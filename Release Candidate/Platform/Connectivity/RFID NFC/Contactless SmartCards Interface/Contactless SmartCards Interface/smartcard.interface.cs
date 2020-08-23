using System.Collections.Generic;

namespace AeonLabs.Connectivity.SmartCards.Interface
{
    public interface IsmartCard
    {
        string getCardUIDString();
        string getReadedString();
        object getStatus();
        bool SelectDevice();
        List<string> ListReaders();
        int GetAvailableReaders(out List<string> smartCardReaders, out string errMsg);
        bool establishContext();
        bool connectCard();
        void Close();
        bool readCardUID();
        bool SaveStringOnCard(string Text, string Block);
        bool SaveStringBlockOnCard(string Text, int Block); // Please make sure you do not write data into these Authentication Blocks 0,3,7,11,15.
        string readCard(int Block);
        bool readStringOnCard(int strSize, int startingBlock);
        bool readBlockOnCard(int Block);
    }
}