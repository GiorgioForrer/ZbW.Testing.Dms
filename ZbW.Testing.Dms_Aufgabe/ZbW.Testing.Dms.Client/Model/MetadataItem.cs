using System;

namespace ZbW.Testing.Dms.Client.Model
{
    internal class MetadataItem
    {
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime ValueDate { get; set; }
        public string FilePath { get; set; }
        public bool IsRemoveFileEnabled { get; set; }
        public string Type { get; set; }

        public MetadataItem() { }

        public MetadataItem(DateTime valueDate, string type)
        {
            ValueDate = valueDate;
            Type = type;
        }

        public MetadataItem(string userName, string description, DateTime dateOfCreation, DateTime valueDate, string filePath, bool isRemoveFileEnabled, string type)
        {
            UserName = userName;
            Description = description;
            DateOfCreation = dateOfCreation;
            ValueDate = valueDate;
            FilePath = filePath;
            IsRemoveFileEnabled = isRemoveFileEnabled;
            Type = type;
        }

   
    }
}
