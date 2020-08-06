using System.IO;

namespace AeonLabs.BasicLibraries
{
    public static class FileManagementLib
    {
        public static bool FileInUse(string sFile)
        {
            bool thisFileInUse = false;
            if (File.Exists(sFile))
            {
                try
                {
                    using (var f = new FileStream(sFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        // thisFileInUse = False
                    }
                }
                catch
                {
                    thisFileInUse = true;
                }
            }

            return thisFileInUse;
        }
    }
}