namespace CMSCore.Library.Data.Models
{
    using System.Collections.Generic;
    using Extensions;

    public class FeedItem : EntityBase
    {
 
        public FeedItem()
        {
        }

        public FeedItem(string feedId, string title)
        {
            FeedId = feedId;
            Title = title;
            NormalizedTitle = title.NormalizeToSlug();
        }

 

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NormalizedTitle = NormalizedTitle ?? value.NormalizeToSlug();
            }
        }

        public string NormalizedTitle { get; set; }


        public bool CommentsEnabled { get; set; } = true;
        public string Description { get; set; }

        public string ContentId { get; set; }
        public virtual Content Content { get; set; }

        public string FeedId { get; set; }
        public virtual Feed Feed { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}