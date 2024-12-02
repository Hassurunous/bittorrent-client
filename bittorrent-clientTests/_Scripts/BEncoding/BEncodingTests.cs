using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bittorrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTorrentTests
{
    [TestClass]
    public class BEncodingTests
    {
        #region Encoding/Decoding Tests

        #region Test Values
        private readonly Dictionary<string, string> EncodingStringsTestValues = new Dictionary<string, string>()
        {
            {"test", "4:test" },
            {"strings with spaces", "19:strings with spaces" },
            {"""punctuation check!@#$%^&*()_+-=,./;'[]\<>?:"{}|""", """47:punctuation check!@#$%^&*()_+-=,./;'[]\<>?:"{}|"""},
            {"iwonderhowlongthestringsyoucanencodeare?istherealimit?", "54:iwonderhowlongthestringsyoucanencodeare?istherealimit?" },
            {"""multi-byte characters 𐀏𐀏𐀀𐀀""",  """38:multi-byte characters 𐀏𐀏𐀀𐀀"""},
            {"", "" }
        };

        private readonly Dictionary<string, string> EncodingIntegersTestValues = new Dictionary<string, string>()
        {

        };

        private readonly Dictionary<string, string> EncodingListsTestValues = new Dictionary<string, string>()
        {

        };

        private readonly Dictionary<string, string> EncodingDictionaryStringIntTestValues = new Dictionary<string, string>()
        {
        };

        private readonly Dictionary<string, string> EncodingDictionaryStringListTestValues = new Dictionary<string, string>()
        {
            { """d4:spaml1:a1:bee {'spam': ['a', 'b']}""", """{'spam': ['a', 'b']}""" }
        };

        #endregion

        [TestMethod]
        public void FormatStringItem_Test()
        {
            string encodedString;
            foreach (KeyValuePair<string, string> stringToTest in EncodingStringsTestValues)
            {
                Console.WriteLine($"Testing string: {stringToTest.Key}");
                Console.WriteLine($"Expected Value: {stringToTest.Value}");
                encodedString = BEncoding.FormatStringItem(stringToTest.Key);
                Assert.IsNotNull(encodedString);
                Assert.AreEqual(stringToTest.Value, encodedString);
            }
        }
        #endregion
    }
}