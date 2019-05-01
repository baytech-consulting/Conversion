namespace Prime.Testing
{
    using System.Text.RegularExpressions;
    using Conversion;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ss = Regex.IsMatch("714 222-2232", @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

            Assert.IsTrue("714 222-2232".IsUsaPhone());
        }
    }
}