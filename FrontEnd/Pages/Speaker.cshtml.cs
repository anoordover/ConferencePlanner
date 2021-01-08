using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FrontEnd.Pages
{
    public class SpeakerModel : PageModel
    {
        private readonly ILogger<SpeakerModel> _logger;
        private readonly IApiClient _apiClient;

        public SpeakerModel(IApiClient apiClient, ILogger<SpeakerModel> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public SpeakerResponse Speaker { get; set; }
        
        public async Task<IActionResult> OnGet(int id)
        {
            Speaker = await _apiClient.GetSpeakerAsync(id);

            if (Speaker == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}