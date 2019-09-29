using Microsoft.SqlServer.Server;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.UnitTests.ViewModelsTests
{
    [TestFixture]
    internal class MainViewModelTests
    {
        private const string Username = "testuser";

        [Test]
        public void MainView_getLoggedInUser_ValidUser()
        {
            //Arrange 
            var mainViewModel = new MainViewModel(Username);
            //Act
            var username = mainViewModel.Benutzer;
            //Assert
            Assert.That(username, Is.EqualTo(Username));
        }
    }




}
