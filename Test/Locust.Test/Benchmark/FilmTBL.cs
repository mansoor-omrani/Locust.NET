namespace Locust.Test.Benchmark
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FilmTBL")]
    public partial class FilmTBL
    {
        public int FilmCode { get; set; }

        [Required]
        [StringLength(70)]
        public string FilmDesc { get; set; }

        public bool? Iranian { get; set; }

        [StringLength(100)]
        public string Director { get; set; }

        [StringLength(3000)]
        public string Summary { get; set; }

        [StringLength(10)]
        public string ReleaseDate { get; set; }

        [StringLength(50)]
        public string RunningTime { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [StringLength(200)]
        public string Trailer { get; set; }

        [StringLength(4)]
        public string Year { get; set; }

        [StringLength(100)]
        public string Producer { get; set; }

        [StringLength(3000)]
        public string Casting { get; set; }

        [StringLength(3000)]
        public string Credits { get; set; }

        [StringLength(100)]
        public string Filmimage { get; set; }

        [Key]
        public long Film_id { get; set; }

        public int? Category_Id { get; set; }

        public DateTime date { get; set; }

        [StringLength(100)]
        public string FilmHorizontalImage { get; set; }

        [StringLength(50)]
        public string distribution { get; set; }

        public bool? ShowSale { get; set; }

        [StringLength(250)]
        public string Film_Field1 { get; set; }

        [StringLength(250)]
        public string Film_Field2 { get; set; }

        public int? Film_Order { get; set; }

        public double? Rating { get; set; }

        public int? Rating_Users { get; set; }

        [StringLength(250)]
        public string Film_Field3 { get; set; }
    }
}
