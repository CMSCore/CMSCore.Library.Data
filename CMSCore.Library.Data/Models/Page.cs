namespace CMSCore.Library.Data.Models
{
    using Extensions;

    public class Page : EntityBase
    {
        public Page()
        {
        }

        public Page(string name, bool feedEnabled)
        {
            Name = name;
            NormalizedName = name.NormalizeToSlug();
            FeedEnabled = feedEnabled;
        }

        public bool FeedEnabled { get; set; } = true;

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string ContentId { get; set; }
        public virtual Content Content { get; set; }

        public string FeedId { get; set; }
        public virtual Feed Feed { get; set; }
    }
}