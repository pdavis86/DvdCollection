using System;

namespace DvdCollection.Data.Models
{
    public class MediaDetails
    {
        public Guid Id { get; set; }
        public Guid MediaFileId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
