using Microsoft.VisualStudio.TestTools.UnitTesting;
using YourAwesomeProject;
using Moq;

namespace TestAwesomeProject
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<DirectoryAccess> directoryAccess;

        [TestMethod]
        public void TestMethodPathFile()
        {
            directoryAccess = new Mock<DirectoryAccess>();
            directoryAccess.Object.SetInitialPath(@"C:\Work\YourAwesomeProject\textfile");
            Assert.AreEqual(@"C:\Work\YourAwesomeProject\textfile", directoryAccess.Object.PathFile);
        }

        [TestMethod]
        public void TestMethodInputWord()
        {
            directoryAccess = new Mock<DirectoryAccess>();
            directoryAccess.Object.SetInitialWord("software");
            Assert.AreEqual("software", directoryAccess.Object.WordToFind);
        }

        [TestMethod]
        public void TestMethodFilePaths()
        {
            directoryAccess = new Mock<DirectoryAccess>(); 
            directoryAccess.Object.SetInitialPath(@"C:\Work\YourAwesomeProject\textfile");

            foreach (var item in directoryAccess.Object.FilePaths)
            {
                Assert.IsNotNull(item);
            }

        }
    }
}
