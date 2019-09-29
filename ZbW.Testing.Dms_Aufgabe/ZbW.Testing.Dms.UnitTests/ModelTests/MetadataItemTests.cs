using NUnit.Framework;
using System;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.UnitTests.ModelTests
{

    [TestFixture]
    internal class MetadataItemTests
    {
        private const string TestType = "Testtyp";
        private const string TestDescription = "Testdescription";
        private const string TestUserName = "Testusername";
        private const string TestFilePath = "Testfilepath";
        private readonly DateTime _testDateTime = DateTime.Now;

        [Test]
        public void MetadataItem_Bezeichnung_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestType) { Description = TestDescription };

            // Act
            var name = metadataItem.Description;
            var valutaDate = metadataItem.ValueDate;
            var type = metadataItem.Type;

            // Assert
            Assert.That(name, Is.EqualTo(TestDescription));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestType));
        }

        [Test]
        public void MetadataItem_Benutzer_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestType) { UserName = TestUserName };

            // Act
            var username = metadataItem.UserName;
            var valutaDate = metadataItem.ValueDate;
            var type = metadataItem.Type;

            // Arrange
            Assert.That(username, Is.EqualTo(TestUserName));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestType));
        }

        [Test]
        public void MetadataItem_FilePath_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestType) { FilePath = TestFilePath };

            // Act
            var filePath = metadataItem.FilePath;
            var valutaDate = metadataItem.ValueDate;
            var type = metadataItem.Type;

            // Assert
            Assert.That(filePath, Is.EqualTo(TestFilePath));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestType));
        }

        [Test]
        public void MetadataItem_SetIsRemoveFileEnabled_GetTrue()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestType) { IsRemoveFileEnabled = true };

            // Act
            var isRemoveEnabled = metadataItem.IsRemoveFileEnabled;
            var valutaDate = metadataItem.ValueDate;
            var type = metadataItem.Type;

            // Assert
            Assert.That(isRemoveEnabled, Is.True);
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestType));
        }

        [Test]
        public void MetadataItem_SetType_GetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestType);

            // Act
            var type = metadataItem.Type;
            var valutaDate = metadataItem.ValueDate;

            // Assert
            Assert.That(type, Is.EqualTo(TestType));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
        }

        [Test]
        public void MetadateItem_Erfassungsdatum_GetTestDateTime()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestType) { DateOfCreation = _testDateTime };

            // Act
            var creationDate = metadataItem.DateOfCreation;
            var type = metadataItem.Type;
            var valutaDate = metadataItem.ValueDate;

            // Assert
            Assert.That(creationDate, Is.EqualTo(_testDateTime));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestType));
        }

        [Test]
        public void MetadataItem_SetValutaDatum_GetTestDateTime()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestType);

            // Act
            var valutaDate = metadataItem.ValueDate;
            var type = metadataItem.Type;

            // Assert
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestType));
        }
        [Test]
        public void MetadataItem_SetStichwoerter_GetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestType);

            // Act
            var valutaDate = metadataItem.ValueDate;
            var type = metadataItem.Type;

            // Assert
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestType));
        }
        [Test]
        public void MetadataItem_FullConstructor_GetTestingTextsAndDates()
        {
            // Arrange and Act
            var metadataItem = new MetadataItem(TestUserName, TestDescription, _testDateTime, _testDateTime, TestFilePath, false, TestType);

            // Assert
            Assert.That(metadataItem.UserName, Is.EqualTo(TestUserName));
            Assert.That(metadataItem.Description, Is.EqualTo(TestDescription));
            Assert.That(metadataItem.DateOfCreation, Is.EqualTo(_testDateTime));
            Assert.That(metadataItem.FilePath, Is.EqualTo(TestFilePath));
            Assert.That(metadataItem.IsRemoveFileEnabled, Is.False);
            Assert.That(metadataItem.Type, Is.EqualTo(TestType));
            Assert.That(metadataItem.ValueDate, Is.EqualTo(_testDateTime));
        }
    }
}
