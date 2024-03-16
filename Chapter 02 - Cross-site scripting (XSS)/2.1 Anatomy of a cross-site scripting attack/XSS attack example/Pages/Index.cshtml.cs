using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XSS_attack_example.Pages
{
    public class IndexModel() : PageModel
    {
        public string Result { get; set; } = string.Empty;

        public void OnGet(string searchTerm)
        {
            this.Result = string.IsNullOrEmpty(searchTerm) ?
                "" :
                $"Your search for <i>{searchTerm}</i> did not yield any results.";
        }
    }
}
