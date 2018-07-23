namespace CMSCore.Library.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public sealed class Content : EntityBase
    {
        public Content()
        {
        }

        public Content(string textValue)
        {
           this.AddContentVersion(textValue);
        }

        public string ActiveContentVersionId { get; set; }
        public ICollection<ContentVersion> ContentVersions { get; set; }

        [NotMapped]
        public ContentVersion ActiveContentVersion
        {
            get
            {
                var activeVersion = ContentVersions?.FirstOrDefault(x => x.Id == ActiveContentVersionId);
                return activeVersion;
            }
        }

        [NotMapped]
        public string ActiveContentValue
        {
            get
            {
                var activeVersion = ContentVersions?.FirstOrDefault(x => x.Id == ActiveContentVersionId);
                return activeVersion?.Value;
            }
        }

        public void AddContentVersion(string value)
        {
            if (ContentVersions == null)
            {
                ContentVersions = new List<ContentVersion>();
            }

            var versionNumber = (ContentVersions?.Count() + 1).GetValueOrDefault(1);

            var contentVersion = new ContentVersion
            {
                Value = value,
                VersionNumber = versionNumber,
                Modified = DateTime.Now,
                Created = Created,
                ContentId = this.Id
            };

            ActiveContentVersionId = contentVersion.Id;
            ContentVersions.Add(contentVersion);
        }
    }
}