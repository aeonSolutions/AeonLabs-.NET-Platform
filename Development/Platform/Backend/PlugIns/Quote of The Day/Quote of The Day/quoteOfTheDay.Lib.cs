using System;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;

namespace AeonLabs.Backend.PlugIns
{
    public static class quoteOfTheDayLib
    {
        public static string loadSentenceQuoteOfTheDay()
        {
            var state = new environmentVarsCore();
            string fileName = Path.Combine(state.libraryPath, "quotes.eon");
            var quotesFile = new FileInfo(fileName);
            var sArray = default(string[]);
            int Index = 0;
            Array.Resize(ref sArray, Index + 1);
            bool found = false;
            quotesFile.Refresh();
            if (quotesFile.Exists)
            {
                try
                {
                    // with Array
                    var fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    var sReader = new StreamReader(fStream, Encoding.UTF8);
                    while (sReader.Peek() >= 0)
                    {
                        string line = sReader.ReadLine();
                        if (Information.IsNothing(line))
                        {
                            continue;
                        }

                        if (line.Equals(""))
                        {
                            continue;
                        }

                        Array.Resize(ref sArray, Index + 1);
                        sArray[Index] = line;
                        Index += 1;
                    }

                    fStream.Close();
                    sReader.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                var rnd = new Random();
                VBMath.Randomize();
                return sArray[rnd.Next(0, sArray.Length - 1)];
            }
            else
            {
                return "quotes file not found";
            }
        }
    }
}