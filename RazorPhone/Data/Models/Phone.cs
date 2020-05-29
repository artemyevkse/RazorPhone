using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;

namespace RazorPhone.Data.Models
{
    [Table(Name = "Phone")]
    public class Phone
    {
        [PrimaryKey, Identity]
        public int Id { set; get; }

        [Column(Name = "Number"), NotNull, Required, StringLength(11)]
        [RegularExpression(@"^[0-9]*$")]
        public string Number { set; get; }

        [Column(Name = "UserId"), NotNull, Required]
        [RegularExpression(@"^[0-9]*$")]
        public int UserId { set; get; }

        [LinqToDB.Mapping.Association(ThisKey = "UserId", OtherKey = "Id", CanBeNull = false)]
        public virtual User User { set; get; }
    }
}