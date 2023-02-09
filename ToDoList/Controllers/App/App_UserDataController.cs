using Bogus.DataSets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ToDoList.Models.Database;

namespace ToDoList.Controllers.App
{
    public class App_UserDataController : Controller
    {

        private readonly UserManager<UserData> _userManager;
        private readonly SignInManager<UserData> _signInManager;

        public App_UserDataController(
            UserManager<UserData> userManager,
            SignInManager<UserData> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public class InputModel
        {
            [Required]
            [Display(Name = "Korisničko ime: ")]
            public string? Username { get; set; }

            public string? Id { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Ime")]
            public string? FirstName { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Prezime")]
            public string? LastName { get; set; }


            [Display(Name = "Datum rođenja")]
            [DataType(DataType.Date)]
            public DateTime? DOB { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Kratki opis")]
            public string? Bio { get; set; }

            [Phone]
            [Display(Name = "Telefonski broj")]
            public string? PhoneNumber { get; set; }

            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nova lozinka (opcionalno)")]
            public string? NewPassword { get; set; }

            //[DataType(DataType.Password)]
            [Display(Name = "Potvrdite novu lozinku")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }

            public string? StatusMessage { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }

        private async Task LoadAsync(UserData user)
        {
            var id = await _userManager.GetUserIdAsync(user);
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            bool emailconfirmed = await _userManager.IsEmailConfirmedAsync(user);
            string? statusMessage = StatusMessage;

            Input = new InputModel
            {
                Username = userName,
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                PhoneNumber = phoneNumber,
                Bio = user.Bio,
                StatusMessage = statusMessage
            };
        }


        // GET: App_UserDataController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            //var user = await _userManager.FindByIdAsync(id);
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Nemoguće učitati korisnika s Identifikacijskim brojem '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return View(Input);
        }

        // POST: App_UserDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string? id, IFormCollection collection)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Nemoguće učitati korisnika s Identifikacijskim brojem '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return View(Input);
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Error: Nastala je neočekivana greška prilikom postavljanja telefonskog broja";
                    return RedirectToAction("Edit", Input);
                }
            }

            if (Input.Username != user.UserName)
            {
                var setUnameResult = await _userManager.SetUserNameAsync(user, Input.Username);
                if (!setUnameResult.Succeeded)
                {
                    await LoadAsync(user);
                    StatusMessage = "Error: Nastala je neočekivana greška prilikom postavljanja korisničkog imena";
                    return RedirectToAction("Edit");
                }
            }

            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }

            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }

            if (Input.DOB != user.DOB && Input.DOB != null)
            {
                user.DOB = Input.DOB.Value;
            }

            if (Input.NewPassword != null)
            {
                var removePassword = await _userManager.RemovePasswordAsync(user);
                if (removePassword.Succeeded)
                {
                    var addPassword = await _userManager.AddPasswordAsync(user, Input.NewPassword);
                    if (!addPassword.Succeeded)
                    {
                        StatusMessage = "Error: Stara lozinka je uklonjena, ali nastala je greška prilikom postavljanja nove lozinke. Molimo pokušajte ponovo.";
                        return RedirectToAction("Edit");
                    }
                }
                else
                {
                    StatusMessage = "Error: Nastala je neočekivana greška prilikom promjene lozinke. Lozinka nije promijenjena.";
                    return RedirectToAction("Edit");
                }
            }
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Home");
        }

        //// GET: App_UserDataController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: App_UserDataController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
