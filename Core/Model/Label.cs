using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Varasto.Core.Model
{
    public class Label
    {
        [Key]
        [DisplayName("ID")]
        public int LabelId { get; set; }
        public string Description { get; set; }
    }
}