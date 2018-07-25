namespace CMSCore.Library.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        [Key]
        public string Id { get; set; }

        public bool Hidden { get; set; }
        public bool MarkedToDelete { get; set; }

        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }

        public string UserId { get; set; }
    }
}