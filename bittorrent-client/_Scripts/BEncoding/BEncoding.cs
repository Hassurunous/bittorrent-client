using System;
using System.Text;

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
        private static byte IntegerStart = Encoding.UTF8.GetBytes("i")[0];      //105
        private static byte IntegerEnd = Encoding.UTF8.GetBytes("e")[0];        //101

        //List Format: lXXXXe where XXXX are the (also bencoded) elements of the list
        //EXAMPLES:
        //  Example: l4:milk4:eggs5:bread13:energy drinks
        //  Example: li17ei12ei13e
        private static byte ListStart = Encoding.UTF8.GetBytes("l")[0];         //108
        private static byte ListEnd = Encoding.UTF8.GetBytes("e")[0];           //101

        //Dictionary Format: dWWWXXXYYYZZZe where WWW+XXX and YYY+ZZZ are the key-value pairs to store 
        private static byte DictionaryStart = Encoding.UTF8.GetBytes("d")[0];   //100
        private static byte DictionaryEnd = Encoding.UTF8.GetBytes("e")[0];     //101


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
            Console.WriteLine("stringToCount Length: {0}", Encoding.UTF8.GetBytes(stringToCount).Length);
        }
    }
}