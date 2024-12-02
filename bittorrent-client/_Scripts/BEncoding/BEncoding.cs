using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bittorrent
{
    public static class BEncoding
    {
        //BitTorrent Protocol Specification: http://www.bittorrent.org/beps/bep_0003.html

        //String Format: X:YYYY where X is the length of the string and YYYY is the string
        //NOTES:
        //  Punctuation is also allowed
        //  Whitespace is allowed
        //  **Length of the string is the BYTE length. Some UTF-8 characters use more than 1 byte.
        //EXAMPLES:
        //  Example: 4:spam would be the string "spam"
        //  Example: 34:supercalifragilisticexpialidocious

        //Integer Format: iXXXXe where XXXX is the number to store
        //NOTES:
        //  Negative integers are allowed.
        //  i-0e is invalid (use i0e)
        //  Leading zeros are invalid (except for the case of i0e to represent the number 0)
        private static readonly byte IntegerStart = Encoding.UTF8.GetBytes("i")[0];      //105
        private static readonly byte IntegerEnd = Encoding.UTF8.GetBytes("e")[0];        //101

        //List Format: lXXXXe where XXXX are the (also bencoded) elements of the list
        //EXAMPLES:
        //  Example: l4:milk4:eggs5:bread13:energy drinks
        //  Example: li17ei12ei13e
        private static readonly byte ListStart = Encoding.UTF8.GetBytes("l")[0];         //108
        private static readonly byte ListEnd = Encoding.UTF8.GetBytes("e")[0];           //101

        //Dictionary Format: dWWWXXXYYYZZZe where WWW+XXX and YYY+ZZZ are the key-value pairs to store 
        //NOTES:
        //  Keys MUST be strings
        private static readonly byte DictionaryStart = Encoding.UTF8.GetBytes("d")[0];   //100
        private static readonly byte DictionaryEnd = Encoding.UTF8.GetBytes("e")[0];     //101

        //Separator: Separates prefix from encoded values
        private static readonly byte[] PrefixSeparator = Encoding.UTF8.GetBytes(":");     //58
        private static readonly char PrefixSeparatorChar = ":"[0];


        //Helper. Throw functions in here that we want to test in the console.
        public static void TestingCall()
        {
            string stringToCount = """multi-byte characters 𐀏𐀏𐀀𐀀""";
            Console.WriteLine("IntegerStart: {0}", IntegerStart);
            Console.WriteLine("IntegerEnd: {0}", IntegerEnd);
            Console.WriteLine("ListStart: {0}", ListStart);
            Console.WriteLine("ListEnd: {0}", ListEnd);
            Console.WriteLine("DictionaryStart: {0}", DictionaryStart);
            Console.WriteLine("DictionaryEnd: {0}", DictionaryEnd);
            Console.WriteLine("PrefixDivider: {0}", PrefixSeparator);
            Console.WriteLine("stringToCount Length: {0}", Encoding.UTF8.GetBytes(stringToCount).Length);
        }

        //Encode values to expected bencoded string
        private static string Encode(byte[] bytes)
        {
            return "";
        }

        //Encode string value
        public static string FormatStringItem(string str) 
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append(Encoding.UTF8.GetByteCount(str));
            sb.Append(PrefixSeparatorChar);
            sb.Append(str);

            return sb.ToString();
        }

        private static byte[] ByteArrayBuilder(byte[][] arrays)
        {
            byte[] ret = new byte[arrays.Sum(x => x.Length)];
            int offset = 0;
            foreach (byte[] data in arrays)
            {
                Buffer.BlockCopy(data, 0, ret, offset, data.Length);
                offset += data.Length;
            }
            return ret;
        }

        //public static byte[] BuildDataByteArray(byte[] prefix, byte[] data, byte[]? suffix = null)
        //{
        //    try 
        //    {
        //        //Prefix separator is always the same, so we don't need to pass that in.
        //        //Suffix isn't used for strings
        //        byte[][] paramsToPass = suffix != null ? [prefix, data, suffix] : [prefix, data];
        //        return ByteArrayBuilder(paramsToPass);
        //    }
        //    catch (Exception e) 
        //    {
        //        throw e;
        //    }
        //}

        //public static byte[] BuildDataByteArrayForStringData(string str)
        //{
        //    //Strings should be preceded by a byte-count of the string length
        //    byte[] stringLength = [Convert.ToByte(GetStringByteLength(str))];
        //    byte[] bytes = Encoding.UTF8.GetBytes(str);

        //    return BuildDataByteArray(stringLength, bytes);
        //}
    }
}