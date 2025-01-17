﻿using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.UnitTests.ViewModelsTests
{
    [TestFixture]
    internal class LoginViewModelTests
    {
        private const string Username = "testuser";
        private readonly string _invalidUsername = string.Empty;

        [Test]
        public void Login_HasUsername_IsTrue()
        {
            //Arrange 
            var loginViewModel = new LoginViewModel(null) {Benutzername = Username };
            //Act
            var ableToLogin = loginViewModel.CmdLogin.CanExecute();
            //Assert
            Assert.That(ableToLogin, Is.True);
        }

        [Test]
        public void Login_NoUsername_IsFalse()
        {
            //Arrange
            var loginViewModel = new LoginViewModel(null){Benutzername = _invalidUsername};
            //Act
            var ableToLogin = loginViewModel.CmdLogin.CanExecute();
            //Assert
            Assert.That(ableToLogin, Is.False);
        }

        [Test]
        public void Login_CmdCancel_IsEnabled()
        {
            //Arrange 
            var loginViewModel = new LoginViewModel(null){Benutzername = Username};
            //Act
            var ableToLogin = loginViewModel.CmdAbbrechen.CanExecute();
            //Assert
            Assert.That(ableToLogin, Is.True);
        }


    }
}
