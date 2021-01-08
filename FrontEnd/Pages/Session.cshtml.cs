using System;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FrontEnd.Pages
{
    public class SessionModel : PageModel
    {
        private readonly ILogger<SessionModel> _logger;
        private readonly IApiClient _apiClient;

        public SessionModel(IApiClient apiClient, ILogger<SessionModel> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }
        public SessionResponse Session { get; set; }

        public int? DayOffset { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Session = await _apiClient.GetSessionAsync(id);

            if (Session == null)
            {
                return RedirectToPage("/Index");
            }

            var allSessions = await _apiClient.GetSessionsAsync();

            var startDate = allSessions.Min(s => s.StartTime?.Date);

            DayOffset = Session.StartTime?.Subtract(startDate ?? DateTimeOffset.MinValue).Days;

            return Page();
        }
    }
}