using LinqToDB;
using System.Collections.Generic;
using System.Linq;
using RazorPhone.Data.Models;

namespace RazorPhone.Data.Repository
{
    public class UserRepository
    {
        public IEnumerable<User> AllUsers
        {
            get
            {
                using var db = new DbWebMobile();
                var query = from u in db.User
                            orderby u.Id ascending
                            select u;

                return query.ToList();
            }
        }


        public bool Add(User user) { return new DbWebMobile().Insert(user) > 0; }
        public bool Save(User user) { return new DbWebMobile().Update(user) > 0; }

        public bool IsExists(int id)
        {
            using var db = new DbWebMobile();
            var query = from u in db.User
                        where u.Id == id
                        select u;

            return (query.Count() > 0);
        }

        public bool IsUserExists(User user)
        {
            using var db = new DbWebMobile();
            var users = from u in db.User.Take(1)
                        where u.FirstName == user.FirstName
                        where u.Surname == user.Surname
                        where u.FatherName == user.FatherName
                        where u.Address == user.Address
                        select u;

            return (users.Count() > 0);
        }
    }
}