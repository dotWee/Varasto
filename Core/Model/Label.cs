using System.ComponentModel.DataAnnotations;

namespace Varasto.Core.Model
{
    public class Label
    {
        [Key]
        public int LabelId { get; set; }
        public string Description { get; set; }
    }
}