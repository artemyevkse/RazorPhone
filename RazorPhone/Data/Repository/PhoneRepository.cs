using LinqToDB;
using System.Collections.Generic;
using System.Linq;
using RazorPhone.Data.Models;

namespace RazorPhone.Data.Repository
{
    public class PhoneRepository
    {
        public IEnumerable<Phone> ComplexPhones
        {
            get
            {
                using var db = new DbWebMobile();
                var query = from p in db.Phone.LoadWith(u => u.User)
                            orderby p.Number descending
                            select p;

                return query.ToList();
            }
        }


        public bool Add(Phone phone) { return new DbWebMobile().Insert(phone) > 0; }
        public bool Save(Phone phone) { return new DbWebMobile().Update(phone) > 0; }

        public bool IsExists(int id)
        {
            using var db = new DbWebMobile();
            var query = from p in db.Phone
                        where p.Id == id
                        select p;

            return (query.Count() > 0);
        }

        public bool IsNumberExists(string phoneNumber)
        {
            using var db = new DbWebMobile();
            var query = from p in db.Phone.Take(1)
                        where p.Number == phoneNumber
                        select p;

            return (query.Count() > 0);
        }
    }
}