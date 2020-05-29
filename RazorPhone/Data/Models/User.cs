using System;
using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;

namespace RazorPhone.Data.Models
{
    [Table(Name = "User")]
    public class User
    {
        [PrimaryKey, Identity]
        public int Id { set; get; }

        [Column(Name = "FirstName"), NotNull, Required]
        [StringLength(32, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s-]*$")]
        public string FirstName { set; get; }

        [Column(Name = "Surname"), NotNull, Required]
        [StringLength(32, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s-]*$")]
        public string Surname { set; get; }

        [Column(Name = "FatherName"), NotNull, Required]
        [StringLength(32, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s-]*$")]
        public string FatherName { set; get; }

        [Column(Name = "Address"), Nullable]
        [StringLength(256, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z0-9,.'\s-]*$")]
        public string Address { set; get; }


        [NotColumn]
        public string FullName {
            get {
                return this.Surname + ' ' + this.FirstName + ' ' + this.FatherName;
            }
        }
    }
}