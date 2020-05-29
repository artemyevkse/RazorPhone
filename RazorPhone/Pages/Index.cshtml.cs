using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPhone.Data.Models;
using RazorPhone.Data.Repository;

namespace RazorPhone.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Phone> AllPhones { get; set; }
        public IEnumerable<User> AllUsers { get; set; }

        [BindProperty]
        public Phone Phone { get; set; }


        public void OnGet()
        {
            var userRepository = new UserRepository();
            var phoneRepository = new PhoneRepository();

            this.AllPhones = phoneRepository.ComplexPhones;
            this.AllUsers = userRepository.AllUsers;
        }

        public IActionResult OnPost(int id)
        {
            var userRepository = new UserRepository();
            var phoneRepository = new PhoneRepository();

            if (ModelState.IsValid) {
                if (!phoneRepository.IsNumberExists(Phone.Number)
                    && userRepository.IsExists(Phone.UserId)
                ) {
                    if (id > 0 && phoneRepository.IsExists(id)) {
                        phoneRepository.Save(Phone);
                    } else {
                        phoneRepository.Add(Phone);
                    }
                }
            }

            return Redirect("/");
        }
    }
}