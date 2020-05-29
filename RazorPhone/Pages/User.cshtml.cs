using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPhone.Data.Models;
using RazorPhone.Data.Repository;

namespace RazorPhone.Pages
{
    public class UserModel : PageModel
    {
        [BindProperty]
        public User UserInfo { get; set; }


        public IActionResult OnGet() { return Redirect("/"); }

        public IActionResult OnPost(int id)
        {
            var userRepository = new UserRepository();

            if (ModelState.IsValid) {
                if (!userRepository.IsUserExists(UserInfo)) {
                    if (id > 0 && userRepository.IsExists(id)) {
                        userRepository.Save(UserInfo);
                    } else {
                        userRepository.Add(UserInfo);
                    }
                }
            }

            return Redirect("/");
        }
    }
}