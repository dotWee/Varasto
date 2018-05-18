using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Varasto.Core.Model
{
    public class StorageEntry
    {
        [Key]
        [DisplayName("ID")]
        public int StorageEntryId { get; set; }
        
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}