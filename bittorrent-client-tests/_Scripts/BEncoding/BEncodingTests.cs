using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bittorrent;

namespace BitTorrentTests
{
    [TestClass]
    public class BEncodingTests
    {
        #region Encoding/Decoding Tests

        #region Test Values
        private Dictionary<string, string> EncodingStringsTestValues = new Dictionary<string, string>()
        {
            {"test", "4:test" },
            {"strings with spaces", "19:strings with spaces" },
            {"""punctuation check!@#$%^&*()_+-=,./;'[]\<>?:"{}|""", """47:punctuation check!@#$%^&*()_+-=,./;'[]\<>?:"{}|"""},
            {"iwonderhowlongthestringsyoucanencodeare?istherealimit?", "54:iwonderhowlongthestringsyoucanencodeare?istherealimit?" },
            {"""multi-byte characters 𐀏𐀏𐀀𐀀""",  """38:multi-byte characters 𐀏𐀏𐀀𐀀"""}

        };
        #endregion

        
        #endregion
    }
}
