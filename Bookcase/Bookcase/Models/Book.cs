using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookcase.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [StringLength(32)]
        [Required]
        public string Author { get; set; }

        [StringLength(32)]
        [Required]
        public string Isbn { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
