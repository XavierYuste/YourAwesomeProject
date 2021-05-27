using Microsoft.VisualStudio.TestTools.UnitTesting;
using YourAwesomeProject;
using Moq;

namespace TestAwesomeProject
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<DirectoryDirector> director;
        private Mock<DirectoryAccess> directoryAccess;

        [TestMethod]
        public void TestMethod1()
        {
            directoryAccess = new Mock<DirectoryAccess>();

            //directoryAccess.Setup(item => item.PathFile).Returns(@"C:\Work\YourAwesomeProject\textfile");

            directoryAccess.Object.SetInitialPath(@"C:\Work\YourAwesomeProject\textfile");

            Assert.AreEqual(@"C:\Work\YourAwesomeProject\textfile", directoryAccess.Object.PathFile);



        }
    }
}
