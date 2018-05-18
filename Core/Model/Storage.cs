using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Varasto.Core.Model
{
    public class Storage
    {
        [Key]
        [DisplayName("ID")]
        public int StorageId { get; set; }
        
        public string Name { get; set; }
        
        public virtual ICollection<StorageEntry> StorageEntries { get; set; }
    }
}