﻿using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ZbW.Testing.Dms.Client.Model;

[assembly: InternalsVisibleTo("ZbW.Testing.Dms.UnitTests")]

namespace ZbW.Testing.Dms.Client.Services
{
    internal class DocumentService : BindableBase
    {
        private const string FileTypeName = "Content";
        private const string MetasataTypeName = "Metadata";
        private readonly string _targetPath;
        private List<MetadataItem> _metadataItems;
        private readonly FileService _fileService;
        private readonly XmlService _xmlService;

        public DocumentService()
        {
            _targetPath = @"C:\Temp"; //System.Configuration.ConfigurationManager.AppSettings["RepositoryDir"]; (Wegen Unit Test)
            _fileService = new FileService();
            _xmlService = new XmlService();
        }

        public List<MetadataItem> MetadataItems
        {
            get => _metadataItems;
            set => SetProperty(ref _metadataItems, value);
        }

        public void AddDocumentToDms(MetadataItem metadataItem)
        {
            var targetPath = _targetPath + "/" + metadataItem.ValueDate.Year;
            var guid = Guid.NewGuid();
            var newFileName = _fileService.GetNewFileName(FileTypeName, metadataItem.FilePath, guid);
            var sourcePath = metadataItem.FilePath;

            metadataItem.FilePath = $@"{targetPath}/{newFileName}";
            _fileService.CreateValutaFolderIfNotExists(targetPath);
            HandleDocument(metadataItem, sourcePath);
            HandleMetadata(metadataItem, targetPath, guid);
        }

        public void OpenFile(MetadataItem metadataItem) => Process.Start(metadataItem.FilePath);

        public List<MetadataItem> GetAllMetadataItems()
        {
            var folderPaths = GetAllFolderPaths(_targetPath);
            var xmlPathsFromAllFoders = new ArrayList();
            var metadataItemList = new ArrayList();

            foreach (var folderPath in folderPaths)
            {
                var xmlPathsFromOneFolder = GetAllXmlPaths(folderPath);
                xmlPathsFromAllFoders.AddRange(xmlPathsFromOneFolder);
            }

            foreach (var xmlPath in xmlPathsFromAllFoders)
            {
                var xmlService = new XmlService();
                metadataItemList.Add(xmlService.DeseralizeMetadataItem((string)xmlPath));
            }

            MetadataItems = metadataItemList.Cast<MetadataItem>().ToList();

            return MetadataItems;
        }

        public List<MetadataItem> FilterMetadataItems(string type, string searchParam)
        {
            if (string.IsNullOrEmpty(searchParam) && string.IsNullOrEmpty(type)) return MetadataItems;
            if (string.IsNullOrEmpty(searchParam)) searchParam = string.Empty;

            var filteredItems = MetadataItems.Where(item => (item.Description.Contains(searchParam) ||
                                                             item.DateOfCreation.ToString(CultureInfo.CurrentCulture).Contains(searchParam) ||
                                                             item.ValueDate.ToString(CultureInfo.CurrentCulture).Contains(searchParam)) &&
                                                            (string.IsNullOrEmpty(type) || item.Type.Equals(type))).ToList();

            return filteredItems;
        }

        public IEnumerable<string> GetAllFolderPaths(string targetPath) => Directory.GetDirectories(targetPath);

        private static ArrayList GetAllXmlPaths(string folderPath)
        {
            var xmlPaths = new ArrayList();
            foreach (var file in Directory.EnumerateFiles(folderPath, "*.xml")) xmlPaths.Add(file);

            return xmlPaths;
        }

        private void HandleDocument(MetadataItem metadataItem, string sourcePath)
        {
            var targetPath = metadataItem.FilePath;
            _fileService.CopyDocumentToTarget(sourcePath, targetPath, metadataItem.IsRemoveFileEnabled);
        }

        private void HandleMetadata(MetadataItem metadataItem, string targetPath, Guid guid)
        {
            var newFileName = _fileService.GetNewFileName(MetasataTypeName, ".xml", guid);
            var newFilePath = targetPath + "/" + newFileName;
            var serializeXml = _xmlService.SeralizeMetadataItem(metadataItem);
            var xmlService = new XmlService();
            xmlService.SaveXml(serializeXml, newFilePath);
        }
    }
}
