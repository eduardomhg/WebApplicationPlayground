using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    using System.Threading;

    using Microsoft.AspNetCore.Http;

    using WebApplication1.Models;
    using WebApplication1.Services;

    public class ThingsModel : PageModel
    {
        private readonly IThingsDataManager thingsDataManager;

        public IEnumerable<Thing> AllThings { get; private set; }

        [BindProperty]
        public Thing NewThing { get; set; }


        [BindProperty]
        public Thing EditedThing { get; set; }
        

        public ThingsModel(IThingsDataManager thingsDataManager)
        {
            this.thingsDataManager = thingsDataManager;
        }

        public void OnGet(int? number)
        {
            this.AllThings = this.thingsDataManager.GetAll();

            if (number.HasValue)
            {
                this.EditedThing = this.AllThings.FirstOrDefault(t => t.Number == number.Value);
            }            
        }

        public IActionResult OnPostCreate()
        {
            this.thingsDataManager.Create(this.NewThing);

            TempData["ToastMessage"] = $"Thing {this.NewThing.Number} created correctly!";

            return RedirectToPage();
        }

        public IActionResult OnPostEdit(int number)
        {
            return RedirectToPage(new { number = number });
        }

        public async Task<IActionResult> OnPostUpdateAsync(int number)
        {
            await Task.Delay(2000);

            this.thingsDataManager.Update(this.EditedThing);

            TempData["ToastMessage"] = $"Thing {this.EditedThing.Number} updated correctly!";

            return RedirectToPage(new { number = number });
        }

        public IActionResult OnPostDelete(int number)
        {
            this.thingsDataManager.Delete(number);

            TempData["ToastMessage"] = $"Thing {number} deleted correctly!";

            return RedirectToPage();
        }
    }
}