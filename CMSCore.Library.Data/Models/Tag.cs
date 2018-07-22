namespace CMSCore.Library.Data.Models
{
    using Extensions;

    public class Tag : EntityBase
    {
        public Tag() { }

        public Tag(string feedItemId, string name)
        {
            FeedItemId = feedItemId;
            Name = name;
            NormalizedName =  name.NormalizeToSlug();

        }

        public Tag(string name)
        {
            Name = name;
            NormalizedName = name.NormalizeToSlug();
        }

        public string FeedItemId { get; set; }
        public virtual FeedItem FeedItem { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}