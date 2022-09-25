using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PhotoEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Byte[] File { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }

    }
}
