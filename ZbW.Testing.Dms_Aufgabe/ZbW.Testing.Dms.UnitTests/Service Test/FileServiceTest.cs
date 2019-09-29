using NUnit.Framework;
using System;
using System.IO;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.UnitTests.ServiceTests
{
    [TestFixture]
    internal class FileServiceTests
    {
        private const string path = @"C:\temp\";
        [Test]
        public void FileService_NewFileNameContent_GenerateReturnsValidFileName()
        {
            // Arrange
            var fileService = new FileService();
            const string fileExtension = "TestExtension";
            const string fileName = "TestFile";
            var guid = new Guid("30c9dcaf-5521-4fba-8dec-93b7caa02364");

            // Act
            var result = fileService.GetNewFileName(fileName, fileExtension, guid);

            // Assert
            Assert.That(result, Is.EqualTo($"{guid}_{fileName}.{fileExtension}"));
        }

        [Test]
        public void FileService_CopyFile_FileCopied()
        {
            // Arrange
            var file = File.Create(path + "Testfile.txt");
            file.Close();
            var fileService = new FileTestable();

            // Act
            fileService.Copy(file.Name, path + "Testpfad.txt", true, false);

            // Assert
            FileAssert.Exists(path + "Testpfad.txt");
        }
    }
}