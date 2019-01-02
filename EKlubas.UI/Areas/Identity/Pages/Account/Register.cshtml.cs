using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EKlubas.Contracts.Abstractions;
using EKlubas.Domain.CityNS;
using EKlubas.Domain.Users;
using EKlubas.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace EKlubas.UI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<EKlubasUser> _signInManager;
        private readonly UserManager<EKlubasUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<EKlubasUser> userManager,
            SignInManager<EKlubasUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public List<SelectListItem> CityListItems { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "{0} laukas privalomas.")]
            [EmailAddress]
            [Display(Name = "El. Paštas")]
            public string Email { get; set; }

            [Required(ErrorMessage = "{0} laukas privalomas.")]
            [StringLength(100, ErrorMessage = "{0} turi būti bent {2} ir daugiausiai {1} simbolių ilgio.", MinimumLength = 6)]
            [Display(Name = "Naudotojo vardas")]
            public string Nickname { get; set; }

            [Required(ErrorMessage = "{0} laukas privalomas.")]
            [StringLength(100, ErrorMessage = "{0} turi būti bent {2} ir daugiausiai {1} simbolių ilgio.", MinimumLength = 6)]
            [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Slaptažodis privalo turėti bent 1 didžiąją, mažąją raides, bent 1 simbolį ir skaičių.")]
            [DataType(DataType.Password)]
            [Display(Name = "Slaptažodis")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Patvirtinti slaptažodį")]
            [Compare("Password", ErrorMessage = "Įvesti slaptažodžiai nesutampa.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "{0} laukas privalomas.")]
            [Display(Name = "Miestas")]
            [Range(1, int.MaxValue, ErrorMessage = "Pasirinkite miestą.")]
            public int CityId { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            SetCityDropDown();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new EKlubasUser { UserName = Input.Email,
                                                Email = Input.Email,
                                                Nickname = Input.Nickname,
                                                CreatedTime = DateTime.Now,
                                                LastLogin = DateTime.Now,
                                                CityId = Input.CityId };

                var result = await _userManager.CreateAsync(user, Input.Password);
                var createdUser = await _userManager.FindByNameAsync(user.UserName);

                await _userManager.AddClaimAsync(createdUser, 
                                                    new Claim("base_role", "scholar"));
                if (result.Succeeded)
                {
                    _logger.LogInformation("Naujas naudotojas sukurtas su pateiktais duomenimis.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Prašome patvirtinti paskyrą <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>spustelėdami čia</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form

            SetCityDropDown();

            return Page();
        }

        private void SetCityDropDown()
        {
            var cities = _context.Cities
                            .OrderBy(c => c.Id)
                            .ToList();

            CityListItems = new List<SelectListItem>()
            {
                new SelectListItem("-Miestas-","0")
            };

            CityListItems.AddRange(cities
                            .Select(c => new SelectListItem()
                            {
                                Text = c.Name,
                                Value = c.Id.ToString()
                            })
                            .ToList());
        }
    }
}
