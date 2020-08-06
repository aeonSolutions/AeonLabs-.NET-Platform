using System;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.BasicLibraries
{
    public static class Strings
    {
        public static string EncodeString(ref string SourceData, ref string CharSet)
        {
            // get a byte pointer To the source data
            var bSourceData = Encoding.Unicode.GetBytes(SourceData);

            // get destination encoding 
            var OutEncoding = Encoding.GetEncoding(CharSet);

            // Encode the data To destination code page/charset
            var bytes = Encoding.Convert(Encoding.Unicode, OutEncoding, bSourceData);
            return Encoding.Unicode.GetString(bytes);
        }

        public static string AddSpaces(string str, int numChars)
        {
            var builder = new StringBuilder(str);
            int EndIndex = str.Length - str.Length % numChars + 1;
            builder.Insert(str.Length % numChars, ' ');
            for (int i = str.Length % numChars + numChars, loopTo = EndIndex; numChars + 1 >= 0 ? i <= loopTo : i >= loopTo; i += numChars + 1)
                builder.Insert(i + 1, ' ');
            return builder.ToString();
        }

        public static object randomString(object size = 12)
        {
            RandomKeyGenerator KeyGen;
            int NumKeys;
            int i_Keys;
            string RandomKey;
            KeyGen = new RandomKeyGenerator();
            KeyGen.KeyLetters = "abcdefghijklmnopqrstuvwxyz";
            KeyGen.KeyNumbers = "0123456789";
            KeyGen.KeyChars = Conversions.ToInteger(size);
            return KeyGen.Generate();
        }

        public class RandomKeyGenerator
        {
            private string Key_Letters;
            private string Key_Numbers;
            private int Key_Chars;
            private char[] LettersArray;
            private char[] NumbersArray;

            /// WRITE ONLY PROPERTY. HAS TO BE SET BEFORE CALLING GENERATE()
            protected internal string KeyLetters
            {
                set
                {
                    Key_Letters = value;
                }
            }

            /// WRITE ONLY PROPERTY. HAS TO BE SET BEFORE CALLING GENERATE()
            protected internal string KeyNumbers
            {
                set
                {
                    Key_Numbers = value;
                }
            }

            /// WRITE ONLY PROPERTY. HAS TO BE SET BEFORE CALLING GENERATE()
            protected internal int KeyChars
            {
                set
                {
                    Key_Chars = value;
                }
            }

            /// GENERATES A RANDOM STRING OF LETTERS AND NUMBERS.
        /// LETTERS CAN BE RANDOMLY CAPITAL OR SMALL. RETURNS THERANDOMLY GENERATED KEY</returns>
            public string Generate()
            {
                int i_key;
                float Random1;
                short arrIndex;
                var sb = new StringBuilder();
                string RandomLetter;

                /// CONVERT LettersArray & NumbersArray TO CHARACTR ARRAYS
                LettersArray = Key_Letters.ToCharArray();
                NumbersArray = Key_Numbers.ToCharArray();
                var loopTo = Key_Chars;
                for (i_key = 1; i_key <= loopTo; i_key++)
                {
                    /// START THE CLOCK    - LAITH - 27/07/2005 18:01:18 -
                    VBMath.Randomize();
                    Random1 = VBMath.Rnd();
                    arrIndex = -1;
                    /// IF THE VALUE IS AN EVEN NUMBER WE GENERATE A LETTER,
                /// OTHERWISE WE GENERATE A NUMBER
                /// THE NUMBER '111' WAS RANDOMLY CHOSEN. ANY NUMBER
                /// WILL DO, WE JUST NEED TO BRING THE VALUE
                /// ABOVE '0'
                    if (Conversions.ToInteger(Random1 * 111) % 2 == 0)
                    {
                        /// GENERATE A RANDOM INDEX IN THE LETTERS
                    /// CHARACTER ARRAY
                        while (arrIndex < 0)
                            arrIndex = Convert.ToInt16(LettersArray.GetUpperBound(0) * Random1);
                        RandomLetter = Conversions.ToString(LettersArray[arrIndex]);
                        /// CREATE ANOTHER RANDOM NUMBER. IF IT IS ODD,
                    /// WE CAPITALIZE THE LETTER
                        if (Conversions.ToInteger(arrIndex * Random1 * 99) % 2 != 0)
                        {
                            RandomLetter = LettersArray[arrIndex].ToString();
                            RandomLetter = RandomLetter.ToUpper();
                        }

                        sb.Append(RandomLetter);
                    }
                    else
                    {
                        /// GENERATE A RANDOM INDEX IN THE NUMBERS
                    /// CHARACTER ARRAY
                        while (arrIndex < 0)
                            arrIndex = Convert.ToInt16(NumbersArray.GetUpperBound(0) * Random1);
                        sb.Append(NumbersArray[arrIndex]);
                    }
                }

                return sb.ToString();
            }
        }
    }
}