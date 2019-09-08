using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    //public class Movie
    //{
    //    public int ID { get; set; }
    //    public string Title { get; set; }

    //    [Display(Name = "Release Date")]
    //    [DataType(DataType.Date)]
    //    public DateTime ReleaseDate { get; set; }
    //    public string Genre { get; set; }

    //    [Column(TypeName = "decimal(18, 2)")]
    //    public decimal Price { get; set; }
    //    public string Rating { get; set; }
    //}
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        //[StringLength(5)]
        //[Required]
        public string Rating { get; set; }
    }
}

                        //Title = "When Harry Met Sally",
                        //ReleaseDate = DateTime.Parse("1989-2-12"),
                        //Price = 7.99M,
                        //Genre = "Romantic Comedy",
                        //Rating = 