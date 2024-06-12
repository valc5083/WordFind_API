using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordFind.Model
{
    public class AuthToken
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string? token { get; set; }

        [ForeignKey("UserItem")]
        public string? userId { get; set; }

        public virtual UserItem? user { get; set; }
    }
}