using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PhotoEntity
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Byte[] File { get; set; }
        public bool Active { get; set; }
    }
}
