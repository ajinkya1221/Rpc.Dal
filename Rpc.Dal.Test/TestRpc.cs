using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rpc.Dal.Test
{
    [TestClass]
    public class TestRpc
    {
        [TestMethod]
        public void TestIsRecordExists()
        {
            var rpcObj = new Rpc();
            var res = rpcObj.IsRecordExists("test");
            Assert.IsTrue(res);
        }
    }
}
