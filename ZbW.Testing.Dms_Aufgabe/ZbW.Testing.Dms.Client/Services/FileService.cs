using System;
using System.IO;
using ZbW.Testing.Dms.Client.Exceptions;

namespace ZbW.Testing.Dms.Client.Services
{
    internal class FileService
    {
        public FileTestable FileTestable { get; set; }

        public void CreateValutaFolderIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public FileService() => FileTestable = new FileTestable();

        public void CopyDocumentToTarget(string sourcePath, string targetPath, bool isRevomeFileEnabled)
        {
            try
            {
                FileTestable.Copy(sourcePath, targetPath, true, isRevomeFileEnabled);
            }
            catch (Exception e)
            {
                throw new CouldNotCopyFileException("File konnte nicht kopiert werden", e);
            }
        }

        public string GetNewFileName(string typeName, string fileName, Guid guid)
        {
            var fileExtension = GetFileExtension(fileName);
            return $"{guid}_{typeName}.{fileExtension}";
        }

        public static string GetFileExtension(string fileName)
        {
            var splittedByPoint = fileName.Split('.');
            return splittedByPoint[splittedByPoint.Length - 1];
        }
    }
}