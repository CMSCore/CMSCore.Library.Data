namespace CMSCore.Library.Data.Models
{
    using Extensions;

    public class Page : EntityBase
    {
        public Page()
        {
        }

        public Page(string name)
        {
            Name = name;
        }

        public Page(string name, bool feedEnabled) : this(name)
        {
            FeedEnabled = feedEnabled;
        }


        public bool FeedEnabled { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NormalizedName = NormalizedName ?? value.NormalizeToSlug(); }
        }

        public string NormalizedName { get; set; }

        public string ContentId { get; set; }
        public virtual Content Content { get; set; }

        public string FeedId { get; set; }
        public virtual Feed Feed { get; set; }
    }
}