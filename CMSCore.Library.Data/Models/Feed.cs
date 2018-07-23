namespace CMSCore.Library.Data.Models
{
    using System.Collections.Generic;
    using Extensions;

    public class Feed : EntityBase
    {
        public Feed()
        {
        }

        public Feed(string pageId, string name)
        {
            PageId = pageId;
            Name = name;
            NormalizedName = name.NormalizeToSlug();
        }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string PageId { get; set; }
        public virtual Page Page { get; set; }

        public virtual ICollection<FeedItem> FeedItems { get; set; }
    }
}