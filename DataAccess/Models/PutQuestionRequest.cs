using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class PutQuestionRequest
    {
        [StringLength(255)]
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}