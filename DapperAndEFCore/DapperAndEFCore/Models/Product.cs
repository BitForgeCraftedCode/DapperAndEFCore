using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//https://stackoverflow.com/questions/8902674/manually-map-column-names-with-class-properties
namespace DapperAndEFCore.Models
{
    [Table("tbl_product")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("product_name")]
        public string product_name { get; set; }

        [Column("product_description")]
        public string product_description { get; set; }

        [Column("product_price")]
        public decimal product_price { get; set; }
    }
}
